﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            var studentsPerGrade = Students.Count / 5;

            var sortedGrades = Students.OrderByDescending(x => x.GetAverage()).ToList();

            if (averageGrade > sortedGrades[studentsPerGrade].GetAverage())
            {
                return 'A';
            }
            else if (averageGrade > sortedGrades[2 * studentsPerGrade].GetAverage())
            {
                return 'B';
            }
            else if (averageGrade > sortedGrades[3 * studentsPerGrade].GetAverage())
            {
                return 'C';
            }
            else if (averageGrade > sortedGrades[4 * studentsPerGrade].GetAverage())
            {
                return 'D';
            }
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
