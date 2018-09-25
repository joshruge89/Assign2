using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        static SortedSet<Student> studentPool;
        static SortedSet<Course> coursePool;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }


        /*******************************************************
         * Program.BuildStudentPool method
         *
         * Arguments: None
         * Return Type: void
         * Use Case: Builds the static studentPool variable
         ******************************************************/
        private static void BuildStudentPool()
        {
            Console.WriteLine("Building Student Pool");

            String buffer,
                filepath = "..\\..\\..\\students.txt"; // Windows Path
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
                    studentPool.Add(newStudent);

                    // Read next line of input
                    buffer = inFile.ReadLine();
                } // end while loop
            } // end using inFile

        } // end BuildStudentPool method

        /*******************************************************
        * Program.BuildCoursePool method
        *
        * Arguments: None
        * Return Type: void
        * Use Case: Builds the static coursePool variable
        ******************************************************/
        private static void BuildCoursePool()
        {
            Console.WriteLine("\nBuilding Course Pool");

            String buffer,
                filepath = "..\\..\\..\\courses.txt"; // Windows path
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
                    coursePool.Add(newCourse);

                    // Read next line of input
                    buffer = inFile.ReadLine();
                } // end while loop
            } // end using

        } // end BuildCoursePool method

        /*******************************************************
        * Program.EnrollStudent method
        *
        * Arguments: None
        * Return Type: void
        * Use Case: takes user input and searches for class then
        *           adds student to class enrolled list.
        ******************************************************/
       public static void EnrollStudent()
       {
           string studentLookup, courseLookup;
           bool courseFound = false,
               studentFound = false;

           Course courseMatch = new Course();
           Student studentMatch = new Student();

           // Prompt and get user input zid
           PrintStudentList();
           Console.WriteLine();
           Console.WriteLine("Please enter the Z-ID (omitting the Z character)");
           Console.Write("of the student to enroll in the course: ");
           studentLookup = Console.ReadLine();

           PrintCourseList();
           Console.WriteLine();
           Console.WriteLine("Which course will this student be enrolled into?");
           Console.Write("<DEPT COURSE_NUM-SECTION_NUM>  ");
           courseLookup = Console.ReadLine();
           courseLookup = courseLookup.ToUpper();

           // Parse the student id from user input
           uint targetZid;
           UInt32.TryParse(studentLookup, out targetZid);

           // Loop and try to match input with a student
           foreach (Student s in studentPool)
           {
               if (s.Zid == targetZid)
               {
                   studentMatch = s;
                   studentFound = true;
               }
           }

           // Split the course input string by space or -
           char[] delims = { ' ', '-' };
           string[] courseArgs = courseLookup.Split(delims);
           string targetCourseNum = courseArgs[1],
               targetSection = courseArgs[2];

           // Parse course number into a uint
           uint parsedCourseNum;
           UInt32.TryParse(targetCourseNum, out parsedCourseNum);

           // Loop and try to match input with a course
           foreach (Course c in coursePool)
           {
               if (c.CourseNum == parsedCourseNum && c.SectionNum.Equals(targetSection))
               {
                   courseMatch = c;
                   courseFound = true;
               }
           }

           // Check if student or course was found and notify user, otherwise enroll student

           if (studentFound == false)
           {
               Console.WriteLine("Invalid zid, please enter a valid Student ID.");
           }
           else if (courseFound == false)
           {
               Console.WriteLine("Invalid Course, please enter a valid Course.");
           }
           else
           {
               studentMatch.Enroll(courseMatch);
           }

       } // end Program.EnrollStudent method

       public static void DropStudent()
       {
           string studentLookup, courseLookup;
           bool courseFound = false,
               studentFound = false;

           Course courseMatch = new Course();
           Student studentMatch = new Student();

           // Prompt and get user input zid
           PrintStudentList();
           Console.WriteLine();
           Console.WriteLine("Please enter the Z-ID (omitting the Z character)");
           Console.Write("of the student to drop from the course: ");
           studentLookup = Console.ReadLine();

           PrintCourseList();
           Console.WriteLine();
           Console.WriteLine("Which course will this student be dropped from?");
           Console.Write("<DEPT COURSE_NUM-SECTION_NUM>  ");
           courseLookup = Console.ReadLine();
           courseLookup = courseLookup.ToUpper();

           // Parse the student id from user input
           uint targetZid;
           UInt32.TryParse(studentLookup, out targetZid);

           // Loop and try to match input with a student
           foreach (Student s in studentPool)
           {
               if (s.Zid == targetZid)
               {
                   studentMatch = s;
                   studentFound = true;
               }
           }

           // Split the course input string by space or -
           char[] delims = { ' ', '-' };
           string[] courseArgs = courseLookup.Split(delims);
           string targetCourseNum = courseArgs[1],
               targetSection = courseArgs[2];

           // Parse course number into a uint
           uint parsedCourseNum;
           UInt32.TryParse(targetCourseNum, out parsedCourseNum);

           // Loop and try to match input with a course
           foreach (Course c in coursePool)
           {
               if (c.CourseNum == parsedCourseNum && c.SectionNum.Equals(targetSection))
               {
                   courseMatch = c;
                   courseFound = true;
               }
           }

           // Check if student or course was found and notify user, otherwise enroll student

           if (studentFound == false)
           {
               Console.WriteLine("Invalid zid, please enter a valid Student ID.");
           }
           else if (courseFound == false)
           {
               Console.WriteLine("Invalid Course, please enter a valid Course.");
           }
           else
           {
               studentMatch.Drop(courseMatch);
           }
       } // end Program.DropStudent method


        /*******************************************************
         * Program.PrintRosterForCourse method
         *
         * Arguments: None
         * Return Type: void
         * Use Case: takes user input and prints student roster
         *           for course specified
         ******************************************************/
        public static void PrintRosterForCourse()
        {
            PrintCourseList();
            Console.WriteLine();

            // Get input from the user
            Console.Write("Please enter Department: ");
            string deptChoice;
            deptChoice = Console.ReadLine();
            deptChoice = deptChoice.ToUpper();
            // Print a space
            Console.WriteLine();

            // Get input from the user
            Console.Write("Please enter Course ID: ");
            string courseChoice;
            courseChoice = Console.ReadLine();
            // Print a space
            Console.WriteLine();

            // Get input from the user
            Console.Write("Please enter Section ID: ");
            string sectChoice;
            sectChoice = Console.ReadLine();
            sectChoice = sectChoice.ToUpper();
            // Print a space
            Console.WriteLine();

            bool printError = false;
            foreach (Course c in coursePool)
            {
                if (c.DeptCode.Equals(deptChoice) && c.SectionNum.Equals(sectChoice))
                {
                    c.PrintRoster(studentPool);
                    printError = true;
                }

            }

            if (printError == false)
            {
                Console.WriteLine("No matches found.");
            }

            Console.WriteLine();
        } // end Program.PrintRosterForCourse method
    } // end Program class
} // end namespace
