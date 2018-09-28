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
using System.IO;

namespace SchoolApp
{
    static class FormController
    {
         /*******************************************************
         * FormController.BuildStudentPool method
         *
         * Arguments: None
         * Return Type: void
         * Use Case: Builds the static studentPool variable
         ******************************************************/
        public static void BuildStudentPool()
        {
            Console.WriteLine("Building Student Pool");

            String buffer,
                filepath = "..\\..\\students.txt"; // Windows Path
                                                       //filepath = "./students.txt"; // Mac Path

            // Open students.txt file
            using (StreamReader inFile = new StreamReader(filepath))
            {
                // Get first line of input
                buffer = inFile.ReadLine();

                // Loop through file
                while (buffer != null)
                {
                    // Split current line
                    String[] argList = buffer.Split(',');

                    // Parse zid from string to uint
                    uint newZid;
                    UInt32.TryParse(argList[0], out newZid);

                    // Parse year from string to int
                    int newYear;
                    Int32.TryParse(argList[4], out newYear);

                    // Parse gpa from string to float
                    float newGpa;
                    float.TryParse(argList[5], out newGpa);

                    // Create a new student object
                    Student newStudent = new Student(newZid, argList[2], argList[1], argList[3], newYear, newGpa);

                    // Add the new student to the student pool
                    FormModel.studentPool.Add(newStudent);

                    // Read next line of input
                    buffer = inFile.ReadLine();
                } // end while loop
            } // end using inFile

        } // end BuildStudentPool method

        /*******************************************************
        * FormController.BuildCoursePool method
        *
        * Arguments: None
        * Return Type: void
        * Use Case: Builds the static coursePool variable
        ******************************************************/
        public static void BuildCoursePool()
        {
            Console.WriteLine("\nBuilding Course Pool");

            String buffer,
                filepath = "..\\..\\courses.txt"; // Windows path
                                                      //filepath = "./courses.txt"; // Mac Path

            // Open courses.txt file
            using (StreamReader inFile = new StreamReader(filepath))
            {
                // Get first line of input, priming
                buffer = inFile.ReadLine();

                // Loop through file
                while (buffer != null)
                {
                    // Split current line
                    String[] argList = buffer.Split(',');

                    // Parse cNum from string to uint
                    uint crsNum;
                    UInt32.TryParse(argList[1], out crsNum);

                    // Parse crdHours from string to ushort
                    ushort crdHours;
                    UInt16.TryParse(argList[3], out crdHours);

                    // Parse newCapp from string to ushort
                    ushort newCapp;
                    UInt16.TryParse(argList[4], out newCapp);

                    // Create a new Course object
                    Course newCourse = new Course(argList[0], crsNum, argList[2], crdHours, newCapp);

                    // Add the new course to the course pool
                    FormModel.coursePool.Add(newCourse);

                    // Read next line of input
                    buffer = inFile.ReadLine();
                } // end while loop
            } // end using

        } // end BuildCoursePool method


        /*******************************************************
        * FormController.BuildMajorPool method
        *
        * Arguments: None
        * Return Type: void
        * Use Case: Builds the static majorPool variable
        ******************************************************/
        public static void BuildMajorPool()
        {
            foreach (Student s in FormModel.studentPool)
            {
                FormModel.majorPool.Add(s.Major);
            }
        }

        /*******************************************************
        * FormController.BuildDeptPool method
        *
        * Arguments: None
        * Return Type: void
        * Use Case: Builds the static deptPool variable
        ******************************************************/
        public static void BuildDeptPool()
        {
            foreach (Course c in FormModel.coursePool)
            {
                FormModel.deptPool.Add(c.DeptCode);
            }
        }


        /*******************************************************
        * FormController.MatchStudent method
        *
        * Arguments: string targetStudent - the student to be matched
        * Return Type: Student - the matched student
        * ******************************************************/
        public static Student MatchStudent(string targetStudent)
        {
            foreach (Student s in FormModel.studentPool)
            {
                if (s.BuildStudentListing() == targetStudent)
                {
                    return s;
                }
            }

            return new Student();
        }

        /*******************************************************
        * FormController.MatchCourse method
        *
        * Arguments: string targetCourse - the course to be matched
        * Return Type: Course - the matched course
        * ******************************************************/
        public static Course MatchCourse(string targetCourse)
        {
            string query, index;

            query = targetCourse.Substring(0, 13);
            foreach (Course c in FormModel.coursePool)
            {
                index = c.BuildCourseListing().Substring(0, 13);
                if (query == index)
                {
                    return c;
                }
            }

            return new Course();
        }


        /*******************************************************
        * FormController.BuildEnrollErrorMsg method
        *
        * Arguments: int cc - condition code based on the status of enrollment
        * Return Type: string
        * Use Case: Builds enroll button output if error has occurred
        ******************************************************/
        public static string BuildEnrollErrorMsg(int cc)
        {
            if (cc == 5)
            {
                return "Error! This class is already at max capacity.";
            }

            if (cc == 15)
            {
                return "Error! Student would be over the maximum number of credits allowed.";
            }

            if (cc == 10)
            {
                return "Error! Student is already enrolled in the course";
            }

            return "Unkown error occurred";
        } // end FormController.BuildEnrollErrorMsg method


        /*******************************************************
        * FormController.FilterStudentPool method
        *
        * Arguments: None
        * Return Type: void
        * Use Case: searches for student then
        *           adds student to filtered student pool
        ******************************************************/
        public static void FilterStudentPool(string filter)
        {
            FormModel.filteredStudentPool.Clear();

            foreach (Student s in FormModel.studentPool)
            {
                if (s.Zid.ToString().Contains(filter))
                {
                    FormModel.filteredStudentPool.Add(s);
                }
            }
        } // end FormController.FilterStudentPool method


        /*******************************************************
        * FormController.FilterCoursePool method
        *
        * Arguments: None
        * Return Type: void
        * Use Case: searches for student then
        *           adds student to filtered student pool
        ******************************************************/ 
        public static void FilterCoursePool(string filter)
        {
            FormModel.filteredCoursePool.Clear();

            foreach (Course c in FormModel.coursePool)
            {
                if (c.DeptCode.Contains(filter))
                {
                    FormModel.filteredCoursePool.Add(c);
                }
            }
        } // end FormController.FilterStudentPool method

    } // end FormController class
} // end namespace
