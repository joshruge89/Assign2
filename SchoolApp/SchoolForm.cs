/************************************************************
 *                                                          *
 *  CSCI 473/504           Assignment 2         Fall 2018   *                                             
 *                                                          *
 *  Programmers: Tyler Saballus/Josh Ruge                   *
 *                                                          *
 *  Date Due:   Sept-27                                     *                          
 *                                                          *
 *  Purpose:    Student enrollment using two classes,       *
 *              Students and Courses to enact basic         *
 *              functionality to the user via a form..      *
 ***********************************************************/
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
            FormController.BuildMajorPool();
            FormController.BuildDeptPool();

            PopulateStudentBox();
            PopulateCourseBox();
            PopulateMajorComboBox();
            PopulateYearComboBox();
            PopulateDeptComboBox();
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

        private void PopulateMajorComboBox()
        {
            MajorComboBox.Items.Clear();
            MajorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (string major in FormModel.majorPool)
            {
                MajorComboBox.Items.Add(major);
            }
        }

        private void PopulateYearComboBox()
        {
            YearComboBox.Items.Clear();
            YearComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (string year in FormModel.yearPool)
            {
                YearComboBox.Items.Add(year);
            }
        }

        private void PopulateDeptComboBox()
        {
            DeptComboBox.Items.Clear();
            DeptComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (string dept in FormModel.deptPool)
            {
                DeptComboBox.Items.Add(dept);
            }
        }

        //Print Roster Button 
        private void PrintRosterButton_Click(object sender, EventArgs e)
        {
            MainOutputBox.Clear();
            StringBuilder rosterOutput = new StringBuilder();
            bool selected = true;

            if (CourseBox.SelectedIndex == -1)
            {
                rosterOutput.AppendLine("Error! Please Select a Course");
                selected = false;
            }

            if (selected == true)
            {
                Course selectedCourse = FormController.MatchCourse(CourseBox.SelectedItem.ToString());
                rosterOutput.AppendLine(selectedCourse.ToString()); 
            }


            MainOutputBox.Text = rosterOutput.ToString();
        }

        private void StudentBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CourseBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Enroll Students
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
                    string dropErrorMsg = "Error! Student could not be dropped from class.";
                    dropOutput.Append(dropErrorMsg);
                }


            }

            MainOutputBox.Text = dropOutput.ToString();
           
        }

        //Add Student 
        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            MainOutputBox.Clear();
            bool isNameValid = true,
                isZidValid = true,
                isMajorValid = true,
                isYearValid = true;

            StringBuilder addStudentOutput = new StringBuilder();
            string[] names = NameBox.Text.Split(',');

            if (String.IsNullOrEmpty(NameBox.Text))
            {
                isNameValid = false;
                addStudentOutput.AppendLine("Error! Please enter a name to add a student");
            } else if (!NameBox.Text.Contains(", "))
            {
                addStudentOutput.AppendLine("Error! Please enter a valid name to add a student -- Valid format: lname, fname");
                isNameValid = false;
            } 

            if (String.IsNullOrEmpty(ZidBox.Text))
            {
                addStudentOutput.AppendLine("Error! Please enter a Zid to add a student");
                isZidValid = false;
            }

            if (String.IsNullOrEmpty(MajorComboBox.Text))
            {
                addStudentOutput.AppendLine("Error! Please select a major to add a student");
                isMajorValid = false;
            }

            if (String.IsNullOrEmpty(YearComboBox.Text))
            {
                addStudentOutput.AppendLine("Error! Please select a year to add a student");
                isYearValid = false;
            }

            if (isNameValid == true && isZidValid == true && isMajorValid == true && isYearValid == true)
            {

                // Parse zid from string to uint
                uint newZid;
                UInt32.TryParse(ZidBox.Text, out newZid);

                Student newStudent = new Student(newZid, names[1].Trim(), names[0], MajorComboBox.Text, YearComboBox.SelectedIndex, 0);
                FormModel.studentPool.Add(newStudent);
                PopulateStudentBox();

                addStudentOutput.AppendLine(String.Format("Successfully added {0} {1} to the database!", names[1].Trim(), names[0]));
            } else
            {
                addStudentOutput.AppendLine("Unable to add the student. Please try again.");
            }

            MainOutputBox.Text = addStudentOutput.ToString();
        } // end SchoolForm.AddStudentButton_Click method

        private void AddCourseButton_Click(object sender, EventArgs e)
        {

            MainOutputBox.Clear();

            bool isDeptValid = true,
                    isCourseNumBoxValid = true,
                    isSectionBoxValid = true,
                    isMaxCapacityBoxValid = true;

            StringBuilder addCourseOutput = new StringBuilder();

            if (String.IsNullOrEmpty(DeptComboBox.Text))
            {
                addCourseOutput.AppendLine("Error! Please select a department code to add a course");
                isDeptValid = false;
            }

            if (String.IsNullOrEmpty(CourseNumBox.Text))
            {
                addCourseOutput.AppendLine("Error! Please enter a course number to add a course");
                isCourseNumBoxValid = false;
            }

            if (String.IsNullOrEmpty(SectionBox.Text))
            {
                addCourseOutput.AppendLine("Error! Please enter a section number to add a course");
                isSectionBoxValid = false;
            }

            if (String.IsNullOrEmpty(MaxCapacityBox.Text))
            {
                addCourseOutput.AppendLine("Error! Please enter max capacity to add a course");
                isMaxCapacityBoxValid = false;
            }

            if (isDeptValid == true && isCourseNumBoxValid == true && isSectionBoxValid == true && isMaxCapacityBoxValid == true)
            {

                // Parse cNum from string to uint
                uint crsNum;
                UInt32.TryParse(CourseNumBox.Text, out crsNum);


                // Parse newCapp from string to ushort
                ushort newMax;
                UInt16.TryParse(MaxCapacityBox.Text, out newMax);


                Course newCourse = new Course(DeptComboBox.Text, crsNum, SectionBox.Text, 3, newMax);
                FormModel.coursePool.Add(newCourse);
                PopulateCourseBox();

                addCourseOutput.AppendLine("Successfully added " + newCourse.BuildCourseListing() + " to the course pool");

            }


            MainOutputBox.Text = addCourseOutput.ToString();

        }


    }
}
