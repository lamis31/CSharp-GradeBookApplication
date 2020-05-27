using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                writeToConsoleNoMInNumOfStudents();
                return;
            }
            base.CalculateStatistics();
        }

        private static void writeToConsoleNoMInNumOfStudents()
        {
            Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                writeToConsoleNoMInNumOfStudents();
                return;
            }
            base.CalculateStudentStatistics(name);
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            List<double> averageGrades = new List<double>();
            foreach (Student s in Students ) {
                averageGrades.Add(s.AverageGrade);
            }
            var descendingOrderGrades = averageGrades.OrderByDescending(i => i).ToList();

            averageGrades.Sort();
            int numOfStudentsPerGrade = (int)Math.Ceiling(Students.Count * 0.2);
            if(averageGrade > descendingOrderGrades[numOfStudentsPerGrade])
            {
                return 'A';
            }
            else if (averageGrade > descendingOrderGrades[numOfStudentsPerGrade*2])
            {
                return 'B';
            }
            else if (averageGrade > descendingOrderGrades[numOfStudentsPerGrade * 3])
            {
                return 'C';
            }
            else if (averageGrade > descendingOrderGrades[numOfStudentsPerGrade * 4])
            {
                return 'D';
            }
            return 'F';
        }
    }
}
