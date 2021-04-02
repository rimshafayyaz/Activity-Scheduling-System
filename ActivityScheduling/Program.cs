using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Globalization;
using System.Runtime.Serialization;

namespace ActivityScheduling
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            //Form1 form1 = new Form1();
            //form1.initGUI();
            //form1.loadInputExcel(@"C:\temp\course_records.xlsx"); 
            //for running the project correctly make a temp folder in C drive and place the course_records.xlsx file in it....this is foe auto connection
            System.Windows.Forms.Application.Run(new Login_Page());
        }
    }

    class ActivityScheduler
    {
        List<CourseRecord> courseRecords;
        List<Room> rooms;

        public ActivityScheduler()
        {
        }

        public ActivityScheduler(List<CourseRecord> courseRecords, List<Room> rooms)
        {
            this.courseRecords = courseRecords;
            this.rooms = rooms;
        }
        public void ScheduleCourses(List<CourseRecord> invalidCourseRecords,
            List<CourseRecord> unscheduledCourseRecords)
        {
            CourseRecord.bubbleSort(courseRecords);
            foreach (CourseRecord cr in courseRecords)
            {
                if (!cr.hasValidStartEndTime())
                {
                    cr.errorMessage = "Invalid start time should be before end time.";
                    invalidCourseRecords.Add(cr);
                    continue;
                };
                bool scheduled = false;
                foreach (Room room in rooms)
                {
                    try
                    {
                        room.bookCourseTimeslot(cr);
                        scheduled = true;
                        break;
                    }
                    catch (Room.InvalidTimeslotExecption exc)
                    {
                        throw exc;
                    }
                    catch (Room.TimeslotTakenAlreadyExecption)
                    {
                        continue;
                    }
                    catch (Room.NoTimeslotAvailableException)
                    {
                        continue;
                    }
                }
                if (!scheduled) { unscheduledCourseRecords.Add(cr); };
            }
        }
    }

    //class Room
    //{
    //    internal static readonly string DTC_Rooms="Room Name";
    //    internal static readonly string DTC_Rooms_CN = DTC_Rooms.Replace(" ", "");
    //    public String Rooms;
    //    List<CourseRecord> bookedCourses = new List<CourseRecord>();
    //    public void bookCourseTimeslot(CourseRecord cr) 
    //    {
    //        bool canFitAfterPerv = true;
    //        foreach (CourseRecord bcr in bookedCourses)
    //        {
    //            bool canFitBeforCur = false;
    //            bool canFitAfterCur = false;

    //            if (cr.endTime <= cr.startTime)
    //            {
    //                throw new InvalidTimeslotExecption(String.Format("Invalid Timeslot start-end time: {0}", cr));
    //            }
    //            else if (bcr.startTime < cr.startTime && cr.startTime < bcr.endTime ||
    //              bcr.startTime < cr.endTime && cr.endTime < bcr.endTime)
    //            {
    //                throw new TimeslotTakenAlreadyExecption(String.Format("Time overlap: {0}", bcr));
    //            }

    //            // can fit beore?
    //            if (cr.startTime < bcr.startTime && cr.endTime <= bcr.startTime)
    //            {
    //                canFitBeforCur = true;
    //            }

    //            // can fit after
    //            if (cr.startTime >= bcr.endTime && cr.endTime > bcr.endTime)
    //            {
    //                canFitAfterCur = true;
    //            }

    //            if (canFitAfterPerv && canFitBeforCur)
    //            {
    //                bookedCourses[bookedCourses.IndexOf(bcr)] = cr;
    //                cr.room = this;
    //                return;
    //            }

    //            canFitAfterPerv = canFitAfterCur;
    //        }
    //        if (canFitAfterPerv)
    //        {
    //            bookedCourses.Add(cr);
    //            cr.room = this;
    //        }
    //        else throw new NoTimeslotAvailableException();
    //    }
    //    override public String ToString()
    //    {

    //        String retval = "";
    //        retval += "===================";
    //        retval += String.Format("\t{0}", Rooms);
    //        retval += String.Format("===================");
    //        foreach (CourseRecord br in bookedCourses)
    //        {
    //            retval += br + "\n";
    //        }
    //        retval += String.Format("===================");
    //        return retval;
    //    }
    //    public class TimeslotTakenAlreadyExecption : Exception {
    //        public TimeslotTakenAlreadyExecption(string msg) : base(msg) { }
    //    }
    //    public class InvalidTimeslotExecption : Exception {
    //        public InvalidTimeslotExecption(string msg) : base(msg) { }
    //    }
    //    public class NoTimeslotAvailableException : Exception {
    //        public NoTimeslotAvailableException() : base() { }
    //    }

    //    internal static List<Room> getRoomListFromDGV(DataGridView gvRooms)
    //    {
    //        List<Room> rooms = new List<Room>();
    //        foreach (DataGridViewRow row in gvRooms.Rows)
    //        {
    //            Room r = new Room();
    //            //r.Rooms = (string) row.Cells[Room.DTC_Rooms_CN].Value;
    //            //if (r.Rooms != null && r.Rooms.Length > 0)
    //            r.Rooms = (string)row.Cells[Room.DTC_Rooms_CN].Value;
    //            if (r.Rooms != null && r.Rooms.Length > 0)
    //                rooms.Add(r);
    //            else continue;
    //        }
    //        return rooms;
    //    }
    //};
    class Room
    {
        internal static readonly string DTC_Rooms = "Room Name";
        internal static readonly string DTC_Rooms_CN = DTC_Rooms.Replace(" ", "");
        public String Rooms;
        List<CourseRecord> bookedCourses = new List<CourseRecord>();
        public void bookCourseTimeslot(CourseRecord cr)
        {
            bool canFitAfterPerv = true;
            foreach (CourseRecord bcr in bookedCourses)
            {
                bool canFitBeforCur = false;
                bool canFitAfterCur = false;

                if (cr.endTime <= cr.startTime)
                {
                    throw new InvalidTimeslotExecption(String.Format("Invalid Timeslot start-end time: {0}", cr));
                }
                else if (bcr.startTime < cr.startTime && cr.startTime < bcr.endTime ||
                  bcr.startTime < cr.endTime && cr.endTime < bcr.endTime)
                {
                    throw new TimeslotTakenAlreadyExecption(String.Format("Time overlap: {0}", bcr));
                }

                // can fit beore?
                if (cr.startTime < bcr.startTime && cr.endTime <= bcr.startTime)
                {
                    canFitBeforCur = true;
                }

                // can fit after
                if (cr.startTime >= bcr.endTime && cr.endTime > bcr.endTime)
                {
                    canFitAfterCur = true;
                }

                if (canFitAfterPerv && canFitBeforCur)
                {
                    bookedCourses[bookedCourses.IndexOf(bcr)] = cr;
                    cr.room = this;
                    return;
                }

                canFitAfterPerv = canFitAfterCur;
            }
            if (canFitAfterPerv)
            {
                bookedCourses.Add(cr);
                cr.room = this;
            }
            else throw new NoTimeslotAvailableException();
        }
        override public String ToString()
        {

            String retval = "";
            retval += "===================";
            retval += String.Format("\t{0}", Rooms);
            retval += String.Format("===================");
            foreach (CourseRecord br in bookedCourses)
            {
                retval += br + "\n";
            }
            retval += String.Format("===================");
            return retval;
        }
        public class TimeslotTakenAlreadyExecption : Exception
        {
            public TimeslotTakenAlreadyExecption(string msg) : base(msg) { }
        }
        public class InvalidTimeslotExecption : Exception
        {
            public InvalidTimeslotExecption(string msg) : base(msg) { }
        }
        public class NoTimeslotAvailableException : Exception
        {
            public NoTimeslotAvailableException() : base() { }
        }

        internal static List<Room> getRoomListFromDGV(DataGridView gvRooms)
        {
            List<Room> rooms = new List<Room>();
            foreach (DataGridViewRow row in gvRooms.Rows)
            {
                Room r = new Room();
                //r.Rooms = (string) row.Cells[Room.DTC_Rooms_CN].Value;
                //if (r.Rooms != null && r.Rooms.Length > 0)
                r.Rooms = (string)row.Cells[Room.DTC_Rooms_CN].Value;
                if (r.Rooms != null && r.Rooms.Length > 0)
                    rooms.Add(r);
                else continue;
            }
            return rooms;
        }
    };

    class CourseRecord
    {
        public static readonly string DTC_TeacherName = "Teacher Name";
        public static readonly string DTC_Subject = "Subject";
        public static readonly string DTC_CreditHour = "Credit Hour";
        public static readonly string DTC_Lecture = "Lecture";
        public static readonly string DTC_StartTime = "Start Time";

        internal static void loadInvalidCourseRecordListToDGV(List<CourseRecord> invalidCourseRecords, DataGridView gv)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add(DTC_TeacherName);
            dt.Columns.Add(DTC_Subject);
            dt.Columns.Add(DTC_Lecture);
            dt.Columns.Add(DTC_CreditHour);
            dt.Columns.Add(DTC_DayOfWeek);
            dt.Columns.Add(DTC_StartTime);
            dt.Columns.Add(DTC_EndTime);
            dt.Columns.Add(DTC_ErrorMessage);

            foreach (CourseRecord cr in invalidCourseRecords)
            {
                DataRow row = dt.NewRow();
                row[CourseRecord.DTC_TeacherName] = cr.teacherName;
                row[CourseRecord.DTC_Subject] = cr.subject;
                row[CourseRecord.DTC_Lecture] = cr.lecture;
                row[CourseRecord.DTC_CreditHour] = cr.creditHour;
                row[CourseRecord.DTC_DayOfWeek] = cr.startTime.DayOfWeek.ToString();
                row[CourseRecord.DTC_StartTime] = cr.startTime;
                row[CourseRecord.DTC_EndTime] = cr.endTime;
                row[CourseRecord.DTC_ErrorMessage] = cr.errorMessage;
                dt.Rows.Add(row);
            }
            gv.DataSource = dt;
            gv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gv.AutoResizeColumns();
        }

        public static readonly string DTC_EndTime = "End Time";
        public static readonly string DTC_Room = "Room";
        internal static readonly string DTC_DayOfWeek = "Day Of Week";
        private static readonly string DTC_ErrorMessage = "Error Message";

        internal static List<CourseRecord> getCourseRecordListFromDGV(DataGridView gvCourseRecords,
            List<CourseRecord> invalidCourseRecords)
        {
            List<CourseRecord> courseRecords = new List<CourseRecord>();
            foreach (DataGridViewRow row in gvCourseRecords.Rows)
            {
                if (row.Cells[CourseRecord.DTC_TeacherName_CN].Value == null) continue;
                try
                {
                    string dayofweek =
                        (string)row.Cells[CourseRecord.DTC_DayOfWeek_CN].Value;
                    CourseRecord cr = new CourseRecord(
                        (string)row.Cells[CourseRecord.DTC_TeacherName_CN].Value,
                        (string)row.Cells[CourseRecord.DTC_Subject_CN].Value,
                        (string)row.Cells[CourseRecord.DTC_Lecture_CN].Value,
                        (string)row.Cells[CourseRecord.DTC_CreditHour_CN].Value,
                        (DateTime)CourseRecord.parseDateTime(dayofweek, (string)row.Cells[CourseRecord.DTC_StartTime_CN].Value),
                        (DateTime)CourseRecord.parseDateTime(dayofweek, (string)row.Cells[CourseRecord.DTC_EndTime_CN].Value));
                    courseRecords.Add(cr);
                }
                catch (CourseRecord.IncorrectDayTimeFormatException e)
                {
                    CourseRecord cr = new CourseRecord(
                        (string)row.Cells[CourseRecord.DTC_TeacherName_CN].Value,
                        (string)row.Cells[CourseRecord.DTC_Subject_CN].Value,
                        (string)row.Cells[CourseRecord.DTC_Lecture_CN].Value,
                        (string)row.Cells[CourseRecord.DTC_CreditHour_CN].Value,
                        DateTime.Today,
                        DateTime.Today);
                    cr.errorMessage = e.Message.ToString();
                    invalidCourseRecords.Add(cr);
                }
            }
            return courseRecords;

        }

        private static DateTime parseDateTime(string day, string time)
        {
            DateTime datetime;
            try
            {
                datetime = DateTime.ParseExact(time, "h:mm:ss tt",
                    System.Globalization.CultureInfo.InvariantCulture);
            } catch
            {
                try
                {
                    datetime = DateTime.ParseExact(time, "h:mm tt",
                        System.Globalization.CultureInfo.InvariantCulture);
                }
                catch
                {
                    throw new Exception();
                }
            }
            datetime = CourseRecord.getDateTimeForDOW(day, datetime);
            return datetime;
        }

        internal static void loadCourseRecordListToDGV(List<CourseRecord> courseRecords, DataGridView gv, bool showRoom = true, bool showOnlyIfHasRoom = false)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add(DTC_TeacherName);
            dt.Columns.Add(DTC_Subject);
            dt.Columns.Add(DTC_Lecture);
            dt.Columns.Add(DTC_CreditHour);
            dt.Columns.Add(DTC_DayOfWeek);
            dt.Columns.Add(DTC_StartTime);
            dt.Columns.Add(DTC_EndTime);
            if (showRoom) dt.Columns.Add(DTC_Room);

            foreach (CourseRecord cr in courseRecords)
            {
                if (showOnlyIfHasRoom && cr.room == null) continue;
                DataRow row = dt.NewRow();
                row[CourseRecord.DTC_TeacherName] = cr.teacherName;
                row[CourseRecord.DTC_Subject] = cr.subject;
                row[CourseRecord.DTC_Lecture] = cr.lecture;
                row[CourseRecord.DTC_CreditHour] = cr.creditHour;
                if (showRoom) row[CourseRecord.DTC_Room] = (cr.room != null) ? cr.room.Rooms : "";
                row[CourseRecord.DTC_DayOfWeek] = cr.startTime.DayOfWeek.ToString();
                row[CourseRecord.DTC_StartTime] = cr.startTime;
                row[CourseRecord.DTC_EndTime] = cr.endTime;
                dt.Rows.Add(row);
            }
            gv.DataSource = dt;
            gv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gv.AutoResizeColumns();

        }

        internal static void exportToSheet(List<CourseRecord> invalidCourseRecords, Worksheet xlNewSheet)
        {
            // wirte the header
            xlNewSheet.Cells[1, 1].Value = DTC_TeacherName; xlNewSheet.Cells[1, 2].Value = DTC_Subject; xlNewSheet.Cells[1, 3].Value = DTC_Room;
            xlNewSheet.Cells[1, 4].Value = DTC_StartTime; xlNewSheet.Cells[1, 5].Value = DTC_EndTime; xlNewSheet.Cells[1, 6].Value = DTC_Lecture;
            xlNewSheet.Cells[1, 7].Value = DTC_CreditHour;

            int i = 2;
            foreach (CourseRecord cr in invalidCourseRecords)
            {
                xlNewSheet.Cells[i, 1].Value = cr.teacherName; xlNewSheet.Cells[i, 2].Value = cr.subject;
                if (cr.room != null) xlNewSheet.Cells[i, 3].Value = cr.room.Rooms;
                xlNewSheet.Cells[i, 4].Value = cr.startTime; xlNewSheet.Cells[i, 5].Value = cr.endTime; xlNewSheet.Cells[i, 6].Value = cr.lecture;
                xlNewSheet.Cells[i, 7].Value = cr.creditHour;
                i++;
            }
        }

        public string teacherName, subject, lecture, creditHour;
        public DateTime startTime, endTime;
        public Room room;
        public string errorMessage;

        public static string DTC_TeacherName_CN { get { return DTC_TeacherName.Replace(" ", ""); } internal set { } }
        public static string DTC_Subject_CN { get { return DTC_Subject.Replace(" ", ""); } internal set { } }
        public static string DTC_Lecture_CN { get { return DTC_Lecture.Replace(" ", ""); } internal set { } }
        public static string DTC_CreditHour_CN { get { return DTC_CreditHour.Replace(" ", ""); } internal set { } }
        public static string DTC_DayOfWeek_CN { get { return DTC_DayOfWeek.Replace(" ", ""); } internal set { } }
        public static string DTC_StartTime_CN { get { return DTC_StartTime.Replace(" ", ""); } internal set { } }
        public static string DTC_EndTime_CN { get { return DTC_EndTime.Replace(" ", ""); } internal set { } }



        public CourseRecord(
            string teacherName, string subject, string lecture, 
            string creditHour, DateTime startTime, DateTime endTime)
        {
            this.teacherName = teacherName;
            this.subject = subject;
            this.lecture = lecture;
            this.creditHour = creditHour;
            this.startTime = startTime;
            this.endTime = endTime;
        }
        public static int SortCourseRecordByEndTimeHelper(CourseRecord a, CourseRecord b)
        {
            CourseRecord c1 = (CourseRecord)a;
            CourseRecord c2 = (CourseRecord)b;

            if (c1.endTime > c2.endTime)
                return 1;

            if (c1.endTime < c2.endTime)
                return -1;

            else
                return 0;
        }
        override public String ToString()
        {
            return String.Format("<<tn: {0}, sub: {1}, lec:{2}, CH: {3}, ST: {4}, ET: {5}>>", 
                        teacherName, subject, lecture, creditHour, startTime, endTime);
        }

        internal bool hasValidStartEndTime()
        {
            return startTime < endTime;
        }

        internal static DateTime getDateTimeForDOW(string DOW, DateTime time)
        {
            DateTime today = DateTime.Today;
            int todayNum = (int) today.DayOfWeek;
            int dayNum = Array.FindIndex(CultureInfo.CurrentCulture.DateTimeFormat.DayNames, x => x.StartsWith(DOW));
            DateTime day = today.AddDays(dayNum - todayNum);
            TimeSpan todayTime = time - today;
            day += todayTime;
            return day;
        }

        internal static void bubbleSort(List<CourseRecord> courseRecords)
        {
            for (int i = 0; i < courseRecords.Count; i++)
            {
                for (int j = 0; j < courseRecords.Count; j++)
                {
                    if (CourseRecord.SortCourseRecordByEndTimeHelper(courseRecords[i], courseRecords[j]) < 0)
                    {
                        CourseRecord tmp = courseRecords[i];
                        courseRecords[i] = courseRecords[j];
                        courseRecords[j] = tmp;
                    }
                }
            }
        }

        [Serializable]
        private class IncorrectDayTimeFormatException : Exception
        {
            public IncorrectDayTimeFormatException()
            {
            }

            public IncorrectDayTimeFormatException(string message) : base(message)
            {
            }

            public IncorrectDayTimeFormatException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected IncorrectDayTimeFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}

