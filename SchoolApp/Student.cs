/************************************************************
 *                                                          *
 *  CSCI 473/504          Assignment 1         Fall 2018    *                                             
 *                                                          *
 *  Programmers: Tyler Saballus/Josh Ruge                   *
 *                                                          *
 *  Date Due:   Sept-13                                     *                          
 *                                                          *
 *  Purpose:    Student enrollment using two classes,       *
 *              Students and Courses to enact basic         *
 *              functionality to the user via a menu.       *
 ***********************************************************/
using System;
using System.Text;

namespace SchoolApp
{
    public enum academicYears { Freshman, Sophomore, Junior, Senior, PostBacc };

    public class Student : IComparable<Student>
    {
        private readonly uint zid;
        private string firstName;
        private string lastName;
        private string major;
        private academicYears year;
        private double gpa;
        private ushort currentHours;

        // Define Properties for each data member
        public uint Zid
        {
            get => zid;
        }

        // Property for firstName
        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        // Property for lastName
        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        // Property for major
        public string Major
        {
            get => major;
            set => major = value;
        }

        // Property for year
        public academicYears Year
        {
            get => year;
            set => year = value;
        }

        // Property for gpa
        public double Gpa
        {
            get => gpa;
            set
            {
                if (value >= 0 && value <= 4)
                {
                    gpa = value;
                }
                else
                {
                    Console.WriteLine("Error! Gpa must be between 0 and 4.");
                }
            }
        }

        // Property for currentHours
        public ushort Hours
        {
            get => currentHours;
            set => currentHours = value;
        }

        // Student Constructor - Default
        public Student()
        {
            zid = 1111111;
            firstName = "J";
            lastName = "D";
            major = "N/A";
            gpa = 0;
            currentHours = 0;
        }

        // Student Constructor - 6 Arguments
        public Student(uint newZid, string newFName, string newLName, string newMajor, int newYear,
                       double newGpa)
        {
            // Set the zid in the constructor because it is readonly
            if (newZid < 1000000)
            {
                Console.WriteLine("Error! ZID must be greater than 1000000");
            }
            else if (newZid > 9999999)
            {
                Console.WriteLine("Error! ZID must be less than 9999999");
            }
            else
            {
                zid = newZid;
            }

            FirstName = newFName;
            LastName = newLName;
            Year = (academicYears)newYear;
            Major = newMajor;
            Gpa = newGpa;
            Hours = 0;
        }


        /*******************************************************
        * Student.CompareTo method
        * 
        * Arguments: Student student2 - student to compared with this student
        * Return Type: int - comparison code
        * Use Case: Compares two student objects by zid
        ******************************************************/
        public int CompareTo(Student student2)
        {
            uint zid2 = student2.Zid;

            if (zid < zid2)
            {
                return -1;
            }

            if (zid == zid2)
            {
                return 0;
            }

            if (zid > zid2)
            {
                return 1;
            }

            return -99;
        }

        /*******************************************************
        * Student.Enroll method
        * 
        * Arguments: Course targetCourse - course to be added
        * Return Type: int - condition code
        * Use Case: Enrolls a student in course and returns a condition code
        ******************************************************/
        public int Enroll(Course targetCourse)
        {
            // Check if the student can be enrolled in the course
            if (targetCourse.NumEnrolled >= targetCourse.MaxCapacity) // Check if at max capacity
            {
                Console.WriteLine("Error! This class is already at max capacity.");
                return 5;
            }
            else if ((targetCourse.CredHours + Hours) > 18) // Check if would be above max hours
            {
                Console.WriteLine("Error! Student would be over the maximum number of credits allowed.");
                return 15;
            }
            else // Check if the student is already enrolled
            {
                foreach (uint iZid in targetCourse.studentsEnrolled)
                {
                    if (Zid == iZid)
                    {
                        Console.WriteLine("Error! Student is already enrolled in the course");
                        return 10;
                    }
                }
            } // end Error check

            // Add student to the course if conditions were met
            targetCourse.studentsEnrolled.Add(Zid);
            Console.WriteLine("Successfully Enrolled Student!\n");
            return 0;
        } // end Student.Enroll method

        /*******************************************************
         * Student.Drop method
         * 
         * Arguments: Course targetCourse - course to be dropped
         * Return Type: int - condition code
         * Use Case: Drops a student from course and returns a condition code
         ******************************************************/
        public int Drop(Course targetCourse)
        {
            // Loop through students list in course and check for this.zid
            foreach (uint iZid in targetCourse.studentsEnrolled)
            {
                if (Zid == iZid)
                {
                    targetCourse.studentsEnrolled.Remove(iZid);
                    Console.WriteLine("Successfully Dropped Student!\n");

                    return 0;
                }
            }

            // If a match was not found, return error code 20
            return 20;
        } // end Student.Drop method


        /*******************************************************
        * Course.ToString method
        * 
        * Arguments: none
        * Return Type: none
        * Use Case: Allows object to print in the defined
        * pattern we set for it
        ******************************************************/
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            // Build the Student string object
            sb.Append("Z" + Zid + " -- ");
            sb.Append(String.Format("{0,14}", LastName + ", "));
            sb.Append(String.Format("{0,-12}", FirstName));
            sb.Append(" [" + String.Format("{0,9}", Year) + "] ");
            sb.Append("<" + Major + "> ");
            sb.Append("|" + String.Format("{0,6}", Gpa.ToString("0.000")) + " |");

            return sb.ToString();
        }

        public string BuildStudentListing()
        {
            string studentListing = "z" + Zid + " -- " + LastName + ", " + FirstName;
            return studentListing;
        }


    } // end Student class
} // end SchoolApp namespace