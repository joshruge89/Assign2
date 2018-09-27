using System.Drawing;
using System.Windows.Forms;

namespace SchoolApp
{
    partial class SchoolForm
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
            this.PrintRosterButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.DropStudentButton = new System.Windows.Forms.Button();
            this.EnrollStudentButton = new System.Windows.Forms.Button();
            this.NiuBanner = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchStudentBox = new System.Windows.Forms.TextBox();
            this.SearchCourseBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.ZidBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MainOutputBox = new System.Windows.Forms.RichTextBox();
            this.CourseBox = new System.Windows.Forms.ListBox();
            this.StudentBox = new System.Windows.Forms.ListBox();
            this.MajorBox = new System.Windows.Forms.ComboBox();
            this.YearComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AddCourseButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.DeptComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SectionBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CourseNumBox = new System.Windows.Forms.TextBox();
            this.AddStudentButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.MaxCapacityBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.MaxCapacityBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PrintRosterButton
            // 
            this.PrintRosterButton.Location = new System.Drawing.Point(28, 129);
            this.PrintRosterButton.Margin = new System.Windows.Forms.Padding(7);
            this.PrintRosterButton.Name = "PrintRosterButton";
            this.PrintRosterButton.Size = new System.Drawing.Size(296, 62);
            this.PrintRosterButton.TabIndex = 0;
            this.PrintRosterButton.Text = "Print Course Roster";
            this.PrintRosterButton.UseVisualStyleBackColor = true;
            this.PrintRosterButton.Click += new System.EventHandler(this.PrintRosterButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(28, 357);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(7);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(296, 62);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "Apply Search Criteria";
            this.SearchButton.UseVisualStyleBackColor = true;
            // 
            // DropStudentButton
            // 
            this.DropStudentButton.Location = new System.Drawing.Point(28, 281);
            this.DropStudentButton.Margin = new System.Windows.Forms.Padding(7);
            this.DropStudentButton.Name = "DropStudentButton";
            this.DropStudentButton.Size = new System.Drawing.Size(296, 62);
            this.DropStudentButton.TabIndex = 2;
            this.DropStudentButton.Text = "Drop Student";
            this.DropStudentButton.UseVisualStyleBackColor = true;
            // 
            // EnrollStudentButton
            // 
            this.EnrollStudentButton.Location = new System.Drawing.Point(28, 205);
            this.EnrollStudentButton.Margin = new System.Windows.Forms.Padding(7);
            this.EnrollStudentButton.Name = "EnrollStudentButton";
            this.EnrollStudentButton.Size = new System.Drawing.Size(296, 62);
            this.EnrollStudentButton.TabIndex = 3;
            this.EnrollStudentButton.Text = "Enroll Student";
            this.EnrollStudentButton.UseVisualStyleBackColor = true;
            this.EnrollStudentButton.Click += new System.EventHandler(this.EnrollStudentButton_Click);
            // 
            // NiuBanner
            // 
            this.NiuBanner.AutoSize = true;
            this.NiuBanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NiuBanner.Location = new System.Drawing.Point(259, -4);
            this.NiuBanner.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.NiuBanner.Name = "NiuBanner";
            this.NiuBanner.Size = new System.Drawing.Size(1276, 85);
            this.NiuBanner.TabIndex = 4;
            this.NiuBanner.Text = "NIU Enrollment Management System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 129);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Search Student (by Z-ID)";
            // 
            // SearchStudentBox
            // 
            this.SearchStudentBox.Location = new System.Drawing.Point(397, 165);
            this.SearchStudentBox.Margin = new System.Windows.Forms.Padding(7);
            this.SearchStudentBox.Name = "SearchStudentBox";
            this.SearchStudentBox.Size = new System.Drawing.Size(279, 35);
            this.SearchStudentBox.TabIndex = 6;
            // 
            // SearchCourseBox
            // 
            this.SearchCourseBox.Location = new System.Drawing.Point(397, 308);
            this.SearchCourseBox.Margin = new System.Windows.Forms.Padding(7);
            this.SearchCourseBox.Name = "SearchCourseBox";
            this.SearchCourseBox.Size = new System.Drawing.Size(279, 35);
            this.SearchCourseBox.TabIndex = 7;
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(28, 504);
            this.NameBox.Margin = new System.Windows.Forms.Padding(7);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(291, 35);
            this.NameBox.TabIndex = 8;
            // 
            // ZidBox
            // 
            this.ZidBox.Location = new System.Drawing.Point(397, 504);
            this.ZidBox.Margin = new System.Windows.Forms.Padding(7);
            this.ZidBox.Name = "ZidBox";
            this.ZidBox.Size = new System.Drawing.Size(247, 35);
            this.ZidBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(390, 272);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(274, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "Filter Courses ( by Dept)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 468);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(258, 29);
            this.label4.TabIndex = 11;
            this.label4.Text = "Last Name, First Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(390, 468);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 29);
            this.label5.TabIndex = 12;
            this.label5.Text = "Z-ID";
            // 
            // MainOutputBox
            // 
            this.MainOutputBox.Location = new System.Drawing.Point(28, 1008);
            this.MainOutputBox.Margin = new System.Windows.Forms.Padding(7);
            this.MainOutputBox.Name = "MainOutputBox";
            this.MainOutputBox.Size = new System.Drawing.Size(1756, 305);
            this.MainOutputBox.TabIndex = 13;
            this.MainOutputBox.Text = "";
            // 
            // CourseBox
            // 
            this.CourseBox.FormattingEnabled = true;
            this.CourseBox.ItemHeight = 29;
            this.CourseBox.Location = new System.Drawing.Point(1337, 129);
            this.CourseBox.Margin = new System.Windows.Forms.Padding(7);
            this.CourseBox.Name = "CourseBox";
            this.CourseBox.Size = new System.Drawing.Size(447, 816);
            this.CourseBox.TabIndex = 16;
            this.CourseBox.SelectedIndexChanged += new System.EventHandler(this.CourseBox_SelectedIndexChanged);
            // 
            // StudentBox
            // 
            this.StudentBox.FormattingEnabled = true;
            this.StudentBox.ItemHeight = 29;
            this.StudentBox.Location = new System.Drawing.Point(789, 129);
            this.StudentBox.Margin = new System.Windows.Forms.Padding(7);
            this.StudentBox.Name = "StudentBox";
            this.StudentBox.Size = new System.Drawing.Size(447, 816);
            this.StudentBox.TabIndex = 17;
            this.StudentBox.SelectedIndexChanged += new System.EventHandler(this.StudentBox_SelectedIndexChanged);
            // 
            // MajorBox
            // 
            this.MajorBox.FormattingEnabled = true;
            this.MajorBox.Location = new System.Drawing.Point(28, 587);
            this.MajorBox.Margin = new System.Windows.Forms.Padding(7);
            this.MajorBox.Name = "MajorBox";
            this.MajorBox.Size = new System.Drawing.Size(291, 37);
            this.MajorBox.TabIndex = 18;
            // 
            // YearComboBox
            // 
            this.YearComboBox.FormattingEnabled = true;
            this.YearComboBox.Location = new System.Drawing.Point(397, 587);
            this.YearComboBox.Margin = new System.Windows.Forms.Padding(7);
            this.YearComboBox.Name = "YearComboBox";
            this.YearComboBox.Size = new System.Drawing.Size(247, 37);
            this.YearComboBox.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(390, 555);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 29);
            this.label1.TabIndex = 21;
            this.label1.Text = "Academic Year";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 555);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 29);
            this.label6.TabIndex = 20;
            this.label6.Text = "Major";
            // 
            // AddCourseButton
            // 
            this.AddCourseButton.Location = new System.Drawing.Point(28, 919);
            this.AddCourseButton.Margin = new System.Windows.Forms.Padding(7);
            this.AddCourseButton.Name = "AddCourseButton";
            this.AddCourseButton.Size = new System.Drawing.Size(194, 47);
            this.AddCourseButton.TabIndex = 22;
            this.AddCourseButton.Text = "Add Course";
            this.AddCourseButton.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 743);
            this.label7.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 29);
            this.label7.TabIndex = 24;
            this.label7.Text = "DepartmentCode";
            // 
            // DeptComboBox
            // 
            this.DeptComboBox.FormattingEnabled = true;
            this.DeptComboBox.Location = new System.Drawing.Point(28, 774);
            this.DeptComboBox.Margin = new System.Windows.Forms.Padding(7);
            this.DeptComboBox.Name = "DeptComboBox";
            this.DeptComboBox.Size = new System.Drawing.Size(291, 37);
            this.DeptComboBox.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 825);
            this.label8.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 29);
            this.label8.TabIndex = 26;
            this.label8.Text = "Section Number";
            // 
            // SectionBox
            // 
            this.SectionBox.Location = new System.Drawing.Point(28, 861);
            this.SectionBox.Margin = new System.Windows.Forms.Padding(7);
            this.SectionBox.Name = "SectionBox";
            this.SectionBox.Size = new System.Drawing.Size(291, 35);
            this.SectionBox.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(390, 743);
            this.label9.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(184, 29);
            this.label9.TabIndex = 28;
            this.label9.Text = "Course Number";
            // 
            // CourseNumBox
            // 
            this.CourseNumBox.Location = new System.Drawing.Point(397, 779);
            this.CourseNumBox.Margin = new System.Windows.Forms.Padding(7);
            this.CourseNumBox.Name = "CourseNumBox";
            this.CourseNumBox.Size = new System.Drawing.Size(247, 35);
            this.CourseNumBox.TabIndex = 27;
            // 
            // AddStudentButton
            // 
            this.AddStudentButton.Location = new System.Drawing.Point(28, 647);
            this.AddStudentButton.Margin = new System.Windows.Forms.Padding(7);
            this.AddStudentButton.Name = "AddStudentButton";
            this.AddStudentButton.Size = new System.Drawing.Size(194, 47);
            this.AddStudentButton.TabIndex = 29;
            this.AddStudentButton.Text = "Add Student";
            this.AddStudentButton.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(390, 832);
            this.label10.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 29);
            this.label10.TabIndex = 31;
            this.label10.Text = "Capacity";
            // 
            // MaxCapacityBox
            // 
            this.MaxCapacityBox.Location = new System.Drawing.Point(397, 868);
            this.MaxCapacityBox.Margin = new System.Windows.Forms.Padding(7);
            this.MaxCapacityBox.Name = "MaxCapacityBox";
            this.MaxCapacityBox.Size = new System.Drawing.Size(252, 35);
            this.MaxCapacityBox.TabIndex = 32;
            // 
            // SchoolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1867, 1350);
            this.Controls.Add(this.MaxCapacityBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.AddStudentButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CourseNumBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.SectionBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DeptComboBox);
            this.Controls.Add(this.AddCourseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.YearComboBox);
            this.Controls.Add(this.MajorBox);
            this.Controls.Add(this.StudentBox);
            this.Controls.Add(this.CourseBox);
            this.Controls.Add(this.MainOutputBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ZidBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.SearchCourseBox);
            this.Controls.Add(this.SearchStudentBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NiuBanner);
            this.Controls.Add(this.EnrollStudentButton);
            this.Controls.Add(this.DropStudentButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.PrintRosterButton);
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.MaxCapacityBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PrintRosterButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button DropStudentButton;
        private System.Windows.Forms.Button EnrollStudentButton;
        private System.Windows.Forms.Label NiuBanner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SearchStudentBox;
        private System.Windows.Forms.TextBox SearchCourseBox;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox ZidBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox MainOutputBox;
        private System.Windows.Forms.ListBox CourseBox;
        private System.Windows.Forms.ListBox StudentBox;
        private System.Windows.Forms.ComboBox MajorBox;
        private System.Windows.Forms.ComboBox YearComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button AddCourseButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox DeptComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox SectionBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox CourseNumBox;
        private System.Windows.Forms.Button AddStudentButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown MaxCapacityBox;
    }
}

