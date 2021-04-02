namespace ActivityScheduling
{
    partial class Update_page
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Update_page));
            this.tcMainWindow = new System.Windows.Forms.TabControl();
            this.tpCourses = new System.Windows.Forms.TabPage();
            this.gvCourseRecords = new System.Windows.Forms.DataGridView();
            this.TeacherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lecture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditHour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayOfWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtExcelFilename = new System.Windows.Forms.TextBox();
            this.btnLoadExcel = new System.Windows.Forms.Button();
            this.tbRooms = new System.Windows.Forms.TabPage();
            this.gvRooms = new System.Windows.Forms.DataGridView();
            this.roomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpScheduler = new System.Windows.Forms.TabPage();
            this.btnExcelTimetable = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gvInvalidCourseRecords = new System.Windows.Forms.DataGridView();
            this.gvNoRoomCourseRecords = new System.Windows.Forms.DataGridView();
            this.gvScheduledCourseRecords = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tcMainWindow.SuspendLayout();
            this.tpCourses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCourseRecords)).BeginInit();
            this.tbRooms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRooms)).BeginInit();
            this.tpScheduler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvInvalidCourseRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNoRoomCourseRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvScheduledCourseRecords)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tcMainWindow
            // 
            this.tcMainWindow.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tcMainWindow.Controls.Add(this.tpCourses);
            this.tcMainWindow.Controls.Add(this.tbRooms);
            this.tcMainWindow.Controls.Add(this.tpScheduler);
            this.tcMainWindow.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMainWindow.Location = new System.Drawing.Point(2, 170);
            this.tcMainWindow.Name = "tcMainWindow";
            this.tcMainWindow.SelectedIndex = 0;
            this.tcMainWindow.Size = new System.Drawing.Size(1356, 514);
            this.tcMainWindow.TabIndex = 1;
            // 
            // tpCourses
            // 
            this.tpCourses.BackgroundImage = global::ActivityScheduling.Properties.Resources.stickers_abstract_triangle_background_light_blue_pink_and_white_colour_jpg;
            this.tpCourses.Controls.Add(this.gvCourseRecords);
            this.tpCourses.Controls.Add(this.txtExcelFilename);
            this.tpCourses.Controls.Add(this.btnLoadExcel);
            this.tpCourses.Location = new System.Drawing.Point(4, 29);
            this.tpCourses.Name = "tpCourses";
            this.tpCourses.Padding = new System.Windows.Forms.Padding(3);
            this.tpCourses.Size = new System.Drawing.Size(1348, 481);
            this.tpCourses.TabIndex = 0;
            this.tpCourses.Text = "Courses";
            this.tpCourses.UseVisualStyleBackColor = true;
            // 
            // gvCourseRecords
            // 
            this.gvCourseRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvCourseRecords.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvCourseRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCourseRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TeacherName,
            this.Subject,
            this.Lecture,
            this.CreditHour,
            this.DayOfWeek,
            this.StartTime,
            this.EndTime});
            this.gvCourseRecords.Location = new System.Drawing.Point(40, 82);
            this.gvCourseRecords.Name = "gvCourseRecords";
            this.gvCourseRecords.Size = new System.Drawing.Size(1270, 370);
            this.gvCourseRecords.TabIndex = 2;
            // 
            // TeacherName
            // 
            this.TeacherName.HeaderText = "Teacher Name";
            this.TeacherName.Name = "TeacherName";
            // 
            // Subject
            // 
            this.Subject.HeaderText = "Subject";
            this.Subject.Name = "Subject";
            // 
            // Lecture
            // 
            this.Lecture.HeaderText = "Lecture";
            this.Lecture.Name = "Lecture";
            // 
            // CreditHour
            // 
            this.CreditHour.HeaderText = "Credit Hour";
            this.CreditHour.Name = "CreditHour";
            // 
            // DayOfWeek
            // 
            this.DayOfWeek.HeaderText = "Day Of Week";
            this.DayOfWeek.Name = "DayOfWeek";
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "Start Time";
            this.StartTime.Name = "StartTime";
            // 
            // EndTime
            // 
            this.EndTime.HeaderText = "End Time";
            this.EndTime.Name = "EndTime";
            // 
            // txtExcelFilename
            // 
            this.txtExcelFilename.Location = new System.Drawing.Point(40, 20);
            this.txtExcelFilename.Multiline = true;
            this.txtExcelFilename.Name = "txtExcelFilename";
            this.txtExcelFilename.Size = new System.Drawing.Size(1062, 42);
            this.txtExcelFilename.TabIndex = 1;
            // 
            // btnLoadExcel
            // 
            this.btnLoadExcel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLoadExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadExcel.Image")));
            this.btnLoadExcel.Location = new System.Drawing.Point(1124, 20);
            this.btnLoadExcel.Name = "btnLoadExcel";
            this.btnLoadExcel.Size = new System.Drawing.Size(186, 44);
            this.btnLoadExcel.TabIndex = 0;
            this.btnLoadExcel.Text = "Load Excel";
            this.btnLoadExcel.UseVisualStyleBackColor = true;
            this.btnLoadExcel.Click += new System.EventHandler(this.btnLoadExcel_Click);
            // 
            // tbRooms
            // 
            this.tbRooms.BackgroundImage = global::ActivityScheduling.Properties.Resources.stickers_abstract_triangle_background_light_blue_pink_and_white_colour_jpg;
            this.tbRooms.Controls.Add(this.gvRooms);
            this.tbRooms.Location = new System.Drawing.Point(4, 29);
            this.tbRooms.Name = "tbRooms";
            this.tbRooms.Padding = new System.Windows.Forms.Padding(3);
            this.tbRooms.Size = new System.Drawing.Size(1348, 481);
            this.tbRooms.TabIndex = 1;
            this.tbRooms.Text = "Rooms";
            this.tbRooms.UseVisualStyleBackColor = true;
            // 
            // gvRooms
            // 
            this.gvRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvRooms.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRooms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.roomName});
            this.gvRooms.Location = new System.Drawing.Point(56, 38);
            this.gvRooms.Name = "gvRooms";
            this.gvRooms.Size = new System.Drawing.Size(1234, 419);
            this.gvRooms.TabIndex = 0;
            // 
            // roomName
            // 
            this.roomName.HeaderText = "Room Name";
            this.roomName.Name = "roomName";
            // 
            // tpScheduler
            // 
            this.tpScheduler.BackgroundImage = global::ActivityScheduling.Properties.Resources.stickers_abstract_triangle_background_light_blue_pink_and_white_colour_jpg;
            this.tpScheduler.Controls.Add(this.btnExcelTimetable);
            this.tpScheduler.Controls.Add(this.label3);
            this.tpScheduler.Controls.Add(this.label2);
            this.tpScheduler.Controls.Add(this.label1);
            this.tpScheduler.Controls.Add(this.gvInvalidCourseRecords);
            this.tpScheduler.Controls.Add(this.gvNoRoomCourseRecords);
            this.tpScheduler.Controls.Add(this.gvScheduledCourseRecords);
            this.tpScheduler.Controls.Add(this.btnExport);
            this.tpScheduler.Controls.Add(this.btnSchedule);
            this.tpScheduler.Location = new System.Drawing.Point(4, 29);
            this.tpScheduler.Name = "tpScheduler";
            this.tpScheduler.Size = new System.Drawing.Size(1348, 481);
            this.tpScheduler.TabIndex = 2;
            this.tpScheduler.Text = "Scheduler";
            this.tpScheduler.UseVisualStyleBackColor = true;
            // 
            // btnExcelTimetable
            // 
            this.btnExcelTimetable.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcelTimetable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExcelTimetable.Image = ((System.Drawing.Image)(resources.GetObject("btnExcelTimetable.Image")));
            this.btnExcelTimetable.Location = new System.Drawing.Point(1120, 6);
            this.btnExcelTimetable.Name = "btnExcelTimetable";
            this.btnExcelTimetable.Size = new System.Drawing.Size(182, 36);
            this.btnExcelTimetable.TabIndex = 11;
            this.btnExcelTimetable.Text = "Excel Timetable";
            this.btnExcelTimetable.UseVisualStyleBackColor = true;
            this.btnExcelTimetable.Click += new System.EventHandler(this.btnExcelTimetable_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F);
            this.label3.Location = new System.Drawing.Point(24, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "Invalid Course Records";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F);
            this.label2.Location = new System.Drawing.Point(24, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "Unscheduled Courses";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F);
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "Scheduled Courses";
            // 
            // gvInvalidCourseRecords
            // 
            this.gvInvalidCourseRecords.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvInvalidCourseRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvInvalidCourseRecords.Location = new System.Drawing.Point(24, 369);
            this.gvInvalidCourseRecords.Name = "gvInvalidCourseRecords";
            this.gvInvalidCourseRecords.Size = new System.Drawing.Size(1279, 107);
            this.gvInvalidCourseRecords.TabIndex = 7;
            // 
            // gvNoRoomCourseRecords
            // 
            this.gvNoRoomCourseRecords.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvNoRoomCourseRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvNoRoomCourseRecords.Location = new System.Drawing.Point(24, 213);
            this.gvNoRoomCourseRecords.Name = "gvNoRoomCourseRecords";
            this.gvNoRoomCourseRecords.Size = new System.Drawing.Size(1279, 122);
            this.gvNoRoomCourseRecords.TabIndex = 6;
            // 
            // gvScheduledCourseRecords
            // 
            this.gvScheduledCourseRecords.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvScheduledCourseRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvScheduledCourseRecords.Location = new System.Drawing.Point(24, 46);
            this.gvScheduledCourseRecords.Name = "gvScheduledCourseRecords";
            this.gvScheduledCourseRecords.Size = new System.Drawing.Size(1279, 134);
            this.gvScheduledCourseRecords.TabIndex = 5;
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(932, 7);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(182, 36);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export To Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSchedule
            // 
            this.btnSchedule.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchedule.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSchedule.Image = ((System.Drawing.Image)(resources.GetObject("btnSchedule.Image")));
            this.btnSchedule.Location = new System.Drawing.Point(739, 5);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(187, 38);
            this.btnSchedule.TabIndex = 3;
            this.btnSchedule.Text = "Schedule";
            this.btnSchedule.UseVisualStyleBackColor = true;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::ActivityScheduling.Properties.Resources.label5_Image;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1356, 159);
            this.panel1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::ActivityScheduling.Properties.Resources.label5_Image;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(1215, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 42);
            this.button2.TabIndex = 32;
            this.button2.Text = "Logout";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::ActivityScheduling.Properties.Resources.label6_Image;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Image = global::ActivityScheduling.Properties.Resources.label5_Image;
            this.button1.Location = new System.Drawing.Point(1215, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 42);
            this.button1.TabIndex = 31;
            this.button1.Text = "Home";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Sitka Banner", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(718, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 39);
            this.label7.TabIndex = 2;
            this.label7.Text = "Brooke Brid.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Sitka Banner", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(389, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(378, 39);
            this.label6.TabIndex = 1;
            this.label6.Text = "Always Schedule your Comeback.";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ActivityScheduling.Properties.Resources.pictureBox11;
            this.pictureBox2.Location = new System.Drawing.Point(0, -8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(189, 167);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // Update_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1370, 692);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tcMainWindow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Update_page";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdatePage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form5_Load);
            this.tcMainWindow.ResumeLayout(false);
            this.tpCourses.ResumeLayout(false);
            this.tpCourses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCourseRecords)).EndInit();
            this.tbRooms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvRooms)).EndInit();
            this.tpScheduler.ResumeLayout(false);
            this.tpScheduler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvInvalidCourseRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNoRoomCourseRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvScheduledCourseRecords)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMainWindow;
        private System.Windows.Forms.TabPage tpCourses;
        private System.Windows.Forms.DataGridView gvCourseRecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeacherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lecture;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayOfWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.TextBox txtExcelFilename;
        private System.Windows.Forms.Button btnLoadExcel;
        private System.Windows.Forms.TabPage tbRooms;
        private System.Windows.Forms.DataGridView gvRooms;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomName;
        private System.Windows.Forms.TabPage tpScheduler;
        private System.Windows.Forms.Button btnExcelTimetable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvInvalidCourseRecords;
        private System.Windows.Forms.DataGridView gvNoRoomCourseRecords;
        private System.Windows.Forms.DataGridView gvScheduledCourseRecords;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}