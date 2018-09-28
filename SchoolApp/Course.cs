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
using System.Collections.Generic;
using System.Text;

namespace SchoolApp
{
    /*******************************************************
    * Course Class with Icomparable implementation
    * 
    * Use Case: Encapsulates Course object including
    * methods and variables
    ******************************************************/
    public class Course : IComparable<Course>
    {
        //Private variables for course class
        private string deptCode;
        private uint courseNum;
        private string sectionNum;
        private ushort credHours;
        public List<uint> studentsEnrolled;
        private ushort numEnrolled;
        private ushort maxCapacity;

        //constructor with no parameters
        public Course()
        {
            DeptCode = "xxxx";
            courseNum = 999;
            sectionNum = "xxx";
        }

        //constructor with 5 paramters, Department code, course num, sect num, course hours, max capacity
        public Course(string dCode, uint cNum, string sNum, ushort cHours, ushort max)
        {
            deptCode = dCode;
            courseNum = cNum;
            sectionNum = sNum;
            credHours = cHours;
            maxCapacity = max;
            studentsEnrolled = new List<uint>();
        }

        /*******************************************************
        * Course.compareTo method
        * 
        * Arguments: Course Object
        * Return Type: int, results variable
        * Use Case: Changes to base compareTo method in order to
        * compare objects based on deptCode first then CourseNum
        ******************************************************/
        public int CompareTo(Course course2)
        {
            string tempDC = course2.deptCode;
            uint tempCN = course2.courseNum;

            int result = this.deptCode.CompareTo(tempDC);
            if (result == 0)
                result = this.courseNum.CompareTo(tempCN);
            return result;
        }
        /*******************************************************
        * Course.printRoster method
        * 
        * Arguments: none   
        * Return Type: void
        * Use Case: Used on option 5 to print a roster of all
        * students enrolled in this class.
        ******************************************************/
        public StringBuilder PrintRoster(SortedSet<Student> studentPool)
        { 
            StringBuilder sb = new StringBuilder();
            //finding students
            bool matchFound = false;

            foreach (uint iZid in studentsEnrolled)
            {
                foreach (Student s in studentPool)
                {
                    if (s.Zid == iZid)
                    {
                        sb.AppendLine(s.ToString()+"\t");
                        matchFound = true;
                    }
                }
                
            }
            if (matchFound == false)
                sb.AppendLine("There isn't anyone enrolled in " + deptCode + " " + courseNum + "-" + sectionNum);

            return sb;
        }
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
            sb.Append(deptCode + "  ");
            sb.Append(courseNum + "-" + sectionNum + " ");
            sb.Append("(" + numEnrolled + "/" + maxCapacity + ")");

            return sb.ToString();
        }

        //Get,Set methods for Dept code
        public String DeptCode
        {
            get { return deptCode; }
            set { deptCode = value; }
        }

        //Get,Set methods for Course Num
        public uint CourseNum
        {
            get { return courseNum; }
            set { courseNum = value; }
        }


        //Get,Set methods for Section Num
        public String SectionNum
        {
            get { return sectionNum; }
            set { sectionNum = value; }
        }

        //Get,Set methods for Credit Hours
        public ushort CredHours
        {
            get { return credHours; }
            set { credHours = value; }
        }

        //Get,Set methods for Students Enrolled
        public ushort NumEnrolled
        {
            get { return numEnrolled; }
            set { numEnrolled = value; }
        }

        //Get,Set methods for Maximum Capacity
        public ushort MaxCapacity
        {
            get { return maxCapacity; }
            set { maxCapacity = value; }
        }

        public string BuildCourseListing()
        {
            StringBuilder sb = new StringBuilder(DeptCode + " ");
            sb.Append(CourseNum + "-" + SectionNum);
            sb.Append(" (" + NumEnrolled + "/" + MaxCapacity + ")");
            return sb.ToString();
        }

    } // end Course class
} // end SchoolApp namespace