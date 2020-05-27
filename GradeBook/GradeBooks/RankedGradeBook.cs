using System;
using System.Collections.Generic;
using System.Linq;

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
