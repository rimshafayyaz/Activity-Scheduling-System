using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ActivityScheduling
{
    public partial class Update_page : Form
    {
        private List<CourseRecord> courseRecords;
        private List<Room> rooms;
        private List<CourseRecord> noroomCourseRecords;
        private List<CourseRecord> invalidCourseRecords;

        public Update_page()
        {
            InitializeComponent();
        }
        string Path = Home_Page.filePath;

        private void btnLoadExcel_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog(); //this prompts the user to open a file
            openFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";   //opens only excel files
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            //Get the path of specified file
            string filePath = openFileDialog.FileName;
            loadInputExcel(filePath);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            loadInputExcel(Path);

        }

        public void loadInputExcel(string filePath)
        {
            //////////////////////////
            // Adding Course Records
            //////////////////////////
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(filePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


            gvCourseRecords.Rows.Clear();

            for (int i = 2; true; i++)
            {
                if (xlWorkSheet.Cells[i, 1].Value is null) break;
                string teacherName = xlWorkSheet.Cells[i, 1].Value.ToString();
                if (teacherName == "") break;

                string subject = xlWorkSheet.Cells[i, 2].Value.ToString();
                string creditHour = xlWorkSheet.Cells[i, 3].Value.ToString();
                string lecture = xlWorkSheet.Cells[i, 4].Value.ToString();
                string day = (string)xlWorkSheet.Cells[i, 5].Value.ToString();

                string sStartTime = xlWorkSheet.Cells[i, 6].Text.ToString();
                //DateTime startTime = DateTime.ParseExact(sStartTime, "h:mm:ss tt",
                //    System.Globalization.CultureInfo.InvariantCulture);
                //startTime = CourseRecord.getDateTimeForDOW(day, startTime);

                string sEndTime = (string)xlWorkSheet.Cells[i, 7].Text.ToString();
                //DateTime endTime = DateTime.ParseExact(sEndTime, "h:mm:ss tt",
                //    System.Globalization.CultureInfo.InvariantCulture);
                //endTime = CourseRecord.getDateTimeForDOW(day, endTime);

                DataGridViewRow row = (DataGridViewRow)gvCourseRecords.RowTemplate.Clone();
                row.CreateCells(gvCourseRecords);

                row.Cells[0].Value = teacherName;
                row.Cells[1].Value = subject;
                row.Cells[2].Value = lecture;
                row.Cells[3].Value = creditHour;
                row.Cells[4].Value = day;
                row.Cells[5].Value = sStartTime;
                row.Cells[6].Value = sEndTime;
                gvCourseRecords.Rows.Add(row);
            }

            /////////////////////
            // Adding Rooms
            /////////////////////
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2); ;

            for (int i = 2; true; i++)
            {
                if (xlWorkSheet.Cells[i, 1].Value is null) break;

                DataGridViewRow row = (DataGridViewRow)gvRooms.RowTemplate.Clone();
                row.CreateCells(gvRooms);
                row.Cells[0].Value = (string)xlWorkSheet.Cells[i, 1].Value;
                gvRooms.Rows.Add(row);
            }

            txtExcelFilename.Text = filePath;

            xlWorkBook.Close();
            xlApp.Quit();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {

            this.noroomCourseRecords = new List<CourseRecord>();
            this.invalidCourseRecords = new List<CourseRecord>();

            this.courseRecords = CourseRecord.getCourseRecordListFromDGV(gvCourseRecords, this.invalidCourseRecords);
            this.rooms = Room.getRoomListFromDGV(gvRooms);


            ActivityScheduler scheduler = new ActivityScheduler(courseRecords, rooms);
            scheduler.ScheduleCourses(invalidCourseRecords, noroomCourseRecords);

            CourseRecord.loadCourseRecordListToDGV(courseRecords, gvScheduledCourseRecords, true, true);
            CourseRecord.loadCourseRecordListToDGV(noroomCourseRecords, gvNoRoomCourseRecords, false);
            CourseRecord.loadInvalidCourseRecordListToDGV(invalidCourseRecords, gvInvalidCourseRecords);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel |*.xlsx";
            saveFileDialog.Title = "Save an Image File";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                exportToExcel(saveFileDialog.FileName);
            }
        }

        private void exportToExcel(string filename)
        {
            try
            {
                // open excel document 
                //Excel.Application xlApp = new Excel.Application();
                //Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(filename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                object misValue = System.Reflection.Missing.Value;
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);

                // save scheduled courses to sheet1  
                Excel.Worksheet xlNewSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlNewSheet.Name = "Scheduled Courses";
                CourseRecord.exportToSheet(courseRecords, xlNewSheet);

                // save unscheduled courses to sheet2
                xlNewSheet = (Excel.Worksheet)xlWorkBook.Sheets.Add();
                xlNewSheet.Name = "Unscheduled Courses";
                CourseRecord.exportToSheet(noroomCourseRecords, xlNewSheet);

                // save invalid courses to sheet3
                xlNewSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Add();
                xlNewSheet.Name = "Invalid Courses";
                CourseRecord.exportToSheet(invalidCourseRecords, xlNewSheet);

                object missing = Type.Missing;
                xlWorkBook.SaveAs(filename, Excel.XlFileFormat.xlOpenXMLWorkbook,
                missing, missing, missing, missing,
                Excel.XlSaveAsAccessMode.xlNoChange,
                missing, missing, missing, missing, missing);
                xlWorkBook.Close(missing, missing, missing);
                xlApp.UserControl = true;
                xlApp.Quit();

                MessageBox.Show(this, "Report saved successfully!", "Activity Scheduler", MessageBoxButtons.OK);
            }
            catch
            {
                MessageBox.Show(this, "You can not Generate timetable until all the activities are not scheduled." +
                    "Create more rooms to schedule all remaining courses and then Generate TimeTable", "Activity Scheduler", MessageBoxButtons.OK);

            }
        }

        private void btnExcelTimetable_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel |*.xlsx";
            saveFileDialog.Title = "Save an Image File";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                exportExcelTimetable(saveFileDialog.FileName);
            }
    }

        private void exportExcelTimetable(string filename)
        {
            int timetableReportFontSize = 14;
            // open excel document 
            //Excel.Application xlApp = new Excel.Application();
            //Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(filename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);

            int Total_Rooms = gvRooms.Rows.Count;
            int total_records = gvCourseRecords.Rows.Count;

            Excel.Worksheet xlNewSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlNewSheet.Name = "TimeTable";


            // Prepare DOW Row Header    
            xlNewSheet.Cells[1, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue);
            int i = 2;
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek))
                                .OfType<DayOfWeek>()
                                .ToList())
            {
                xlNewSheet.Cells[1, i].Value = day.ToString();
                xlNewSheet.Cells[1, i].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue);
                xlNewSheet.Cells[1, i].Style.Font.Size = timetableReportFontSize;
                i++;
            }

            // Prepare Hour Column Header
            for (i = 8; i <= 20; i++)
            {
                int ri = i - 8 + 2;
                DateTime dt = DateTime.Today;
                TimeSpan hr = new TimeSpan(i, 0, 0);
                dt += hr;
                xlNewSheet.Cells[ri, 1].Value = dt.TimeOfDay.ToString();
                xlNewSheet.Cells[ri, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue);
                xlNewSheet.Cells[ri, 1].Style.Font.Size = timetableReportFontSize;
            }

            // pin each course record
            int rowOffset = 2 - 8, colOffset = 2;
            Dictionary<string, System.Drawing.Color> subject2color = new Dictionary<string, System.Drawing.Color>()
                            {
                                 { "Database", System.Drawing.Color.SlateGray }, { "OS", System.Drawing.Color.Thistle },
                                 { "AOA", System.Drawing.Color.MistyRose}, { "OSLab", System.Drawing.Color.Azure },
                                 { "TOA", System.Drawing.Color.PeachPuff}, { "Calculus", System.Drawing.Color.Aquamarine },
                                 { "DBLab", System.Drawing.Color.RosyBrown}, { "Break", System.Drawing.Color.MediumOrchid},
                            };

            foreach (CourseRecord cr in courseRecords)
            {
                TimeSpan min5 = new TimeSpan(0, 5, 0);
                int sr = (cr.startTime).Hour + rowOffset;
                int er = (cr.endTime - min5).Hour + rowOffset;
                int c = (int)cr.startTime.DayOfWeek + colOffset;

                xlNewSheet.Cells[sr, c] = String.Format("{0} {2} (by. {1}) ", cr.subject, cr.teacherName, cr.room.Rooms);
                Excel.Range xlRange = xlNewSheet.Range[xlNewSheet.Cells[sr, c], xlNewSheet.Cells[er, c]].Cells;
                System.Drawing.Color color;
                try
                {
                    subject2color.TryGetValue(cr.subject, out color);
                }
                catch
                {
                    color = System.Drawing.Color.Aqua;
                }
                xlRange.Interior.Color = color;
                xlRange.Columns.AutoFit();
            }

            object missing = Type.Missing;
            xlWorkBook.SaveAs(filename);
            xlWorkBook.Close(missing, missing, missing);
            //xlApp.UserControl = true;
            xlApp.Quit();
            MessageBox.Show(this, "Report saved successfully!", "Activity Scheduler", MessageBoxButtons.OK);
        }


        private object excelIndex(int er, int c)
        {
            string retval = String.Format("{0}{1}", (char)er + 'A', c);
            return retval;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home_Page p2 = new Home_Page();
            p2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login_Page p2 = new Login_Page();
            p2.Show();
            this.Hide();
        }
    }
}
