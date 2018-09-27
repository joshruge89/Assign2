using System;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolApp
{
    public partial class SchoolForm : Form
    {
        public SchoolForm()
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
            FormController.BuildStudentPool();
            foreach (Student s in FormModel.studentPool)
            {
                StudentBox.Items.Add(s.BuildStudentListing());
            }
        }

        private void PopulateCourseBox()
        {
            FormController.BuildCoursePool();
            foreach (Course c in FormModel.coursePool)
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
