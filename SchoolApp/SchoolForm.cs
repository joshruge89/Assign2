using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SchoolApp
{
    public partial class SchoolForm : Form
    {
        public SchoolForm()
        {
            InitializeComponent();
            PositionAndSizeFrame();

            FormController.BuildStudentPool();
            FormController.BuildCoursePool();

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
            StudentBox.Items.Clear();
            foreach (Student s in FormModel.studentPool)
            {
                StudentBox.Items.Add(s.BuildStudentListing());
            }
        }

        private void PopulateCourseBox()
        {
            CourseBox.Items.Clear();
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
            MainOutputBox.Clear();
            string studentSelection, courseSelection;
            StringBuilder enrollOutput = new StringBuilder();
            bool bothSelected = true;

            if (StudentBox.SelectedIndex == -1)
            {
                enrollOutput.AppendLine("Error! Please Select a Student");
                bothSelected = false;
            }

            if (CourseBox.SelectedIndex == -1)
            {
                enrollOutput.AppendLine("Error! Please Select a Course");
                bothSelected = false;
            }

            if (bothSelected == true)
            {
                StringBuilder selectedMsg = new StringBuilder();
                Student selectedStudent = FormController.MatchStudent(StudentBox.SelectedItem.ToString());
                Course selectedCourse = FormController.MatchCourse(CourseBox.SelectedItem.ToString());

                int conditionCode = selectedStudent.Enroll(selectedCourse);

                if (conditionCode == 0)
                {
                    PopulateCourseBox();

                    selectedMsg.Append("Successfully added ");
                    selectedMsg.Append(selectedStudent.FirstName + " " + selectedStudent.LastName + " ");
                    selectedMsg.Append("(z" + selectedStudent.Zid + ") to ");
                    selectedMsg.Append(selectedCourse.BuildCourseListing());
                } else
                {
                    selectedMsg.Append(FormController.BuildEnrollErrorMsg(conditionCode));
                }            
          
                enrollOutput.AppendLine(selectedMsg.ToString());
            }

           

            MainOutputBox.Text = enrollOutput.ToString();
        }

        //Drop Student Function 
        private void DropStudentButton_Click(object sender, EventArgs e)
        {
            MainOutputBox.Clear();
            string studentSelection, courseSelection;
            StringBuilder dropOutput = new StringBuilder();
            StringBuilder selectedMsg = new StringBuilder();
            bool bothSelected = true;

            if (StudentBox.SelectedIndex == -1)
            {
                dropOutput.AppendLine("Error! Please Select a Student");
                bothSelected = false;
            }

            if (CourseBox.SelectedIndex == -1)
            {
                dropOutput.AppendLine("Error! Please Select a Course");
                bothSelected = false;
            }

            if (bothSelected == true)
            {
                Student selectedStudent = FormController.MatchStudent(StudentBox.SelectedItem.ToString());
                Course selectedCourse = FormController.MatchCourse(CourseBox.SelectedItem.ToString());

                int conditionCode = selectedStudent.Drop(selectedCourse);

                if (conditionCode == 0)
                {
                    PopulateCourseBox();

                    dropOutput.Append("Successfully dropped ");
                    dropOutput.Append(selectedStudent.FirstName + " " + selectedStudent.LastName + " ");
                    dropOutput.Append("(z" + selectedStudent.Zid + ") from ");
                    dropOutput.Append(selectedCourse.BuildCourseListing());

                    
                }
                else
                {
                    selectedMsg.Append(FormController.BuildEnrollErrorMsg(conditionCode));
                }


            }

            MainOutputBox.Text = dropOutput.ToString();
           
        }
    }
}
