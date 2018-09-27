﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

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
        }




        /*******************************************************
        * FormController.EnrollStudent method
        *
        * Arguments: None
        * Return Type: void
        * Use Case: takes user input and searches for class then
        *           adds student to class enrolled list.
        ******************************************************/
        public static void EnrollStudent()
       {
            Console.WriteLine("EnrollStudent called.");
       } // end FormController.EnrollStudent method

       public static void DropStudent()
       {
            Console.WriteLine("DropStudent Called");
       } // end FormController.DropStudent method


        /*******************************************************
         * FormController.PrintRosterForCourse method
         *
         * Arguments: None
         * Return Type: void
         * Use Case: takes user input and prints student roster
         *           for course specified
         ******************************************************/
        public static void PrintRosterForCourse()
        {
            Console.WriteLine("PrintRosterForCourse called");
        } // end FormController.PrintRosterForCourse method
    } // end FormController class
} // end namespace
