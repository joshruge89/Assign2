using System;
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
            PopulateStudentBox();
            PopulateCourseBox();
        }

        private void PopulateStudentBox()
        {
            Program.BuildStudentPool();
            foreach (Student s in Program.studentPool)
            {
                string nextStudent = "z" + s.Zid + " -- " + s.LastName + ", " + s.FirstName;
                studentBox.Items.Add(nextStudent);
            }
        }

        private void PopulateCourseBox()
        {
            Program.BuildCoursePool();
            foreach (Course c in Program.coursePool)
            {
                StringBuilder sb = new StringBuilder(c.DeptCode + " ");
                sb.Append(c.CourseNum + "-" + c.SectionNum);
                sb.Append(" (" + c.NumEnrolled + "/" + c.MaxCapacity + ")");
                courseBox.Items.Add(sb.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void studentBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void courseBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
