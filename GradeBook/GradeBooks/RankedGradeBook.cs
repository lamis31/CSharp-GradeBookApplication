using System;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
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
            averageGrades.Sort();
            int numOfStudentsPerGrade = averageGrades.Count / 5;
            if(averageGrade > averageGrades[numOfStudentsPerGrade])
            {
                return 'A';
            }
            else if (averageGrade > averageGrades[numOfStudentsPerGrade*2])
            {
                return 'B';
            }
            else if (averageGrade > averageGrades[numOfStudentsPerGrade * 3])
            {
                return 'C';
            }
            else if (averageGrade > averageGrades[numOfStudentsPerGrade * 4])
            {
                return 'D';
            }
            return 'F';
        }
    }
}
