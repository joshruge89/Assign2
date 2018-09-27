﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PositionAndSizeFrame();

            PopulateStudentBox();
            PopulateCourseBox();
        }

        private void PositionAndSizeFrame()
        {
            int h = Screen.PrimaryScreen.WorkingArea.Height - 200;
            int w = Screen.PrimaryScreen.WorkingArea.Width / 2;
            Size = new Size(w, h);

            CenterToScreen();
        }

        private void PopulateStudentBox()
        {
            Program.BuildStudentPool();
            foreach (Student s in Program.studentPool)
            {
                StudentBox.Items.Add(s.BuildStudentListing());
            }
        }

        private void PopulateCourseBox()
        {
            Program.BuildCoursePool();
            foreach (Course c in Program.coursePool)
            {         
                CourseBox.Items.Add(c.BuildCourseListing());
            }
        }

        private void PrintRosterButton_Click(object sender, EventArgs e)
        {
            string[] foo = { "Matched Course Roster Here", "This should display on the next line",
                            "So we can be sure the list will display properly"};
            MainOutputBox.Text = String.Join(Environment.NewLine, foo); 
        }

        private void StudentBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CourseBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EnrollStudentButton_Click(object sender, EventArgs e)
        {

        }
    }
}
