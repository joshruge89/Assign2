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

namespace SchoolApp
{
    class FormModel
    {
        public static SortedSet<Student> studentPool = new SortedSet<Student>();
        public static SortedSet<Course> coursePool = new SortedSet<Course>();
        public static SortedSet<string> majorPool = new SortedSet<string>();
        public static SortedSet<string> deptPool = new SortedSet<string>();

        public static string[] yearPool = { "Freshman", "Sophomore", "Junior", "Senior", "PostBacc" };
    }
}
