using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    // StandardGradeBook CLASS inherits BaseGradeBook CLASS
    public class RankedGradeBook : BaseGradeBook
    {
        // Constructor: it calls the base constructor(BaseGradeBook class's constructor) upon completion
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        // GetLetterGrade method Override
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("(Ranked-grading requires a minimum of 5 students to work");

            var thresold = (int)Math.Ceiling(Students.Count*0.2);

            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList() ;
            if (grades[thresold-1] <= averageGrade)
                return 'A';
            else if (grades[thresold * 2] - 1 <= averageGrade)
                return 'B';
            else if (grades[thresold * 3] - 1 <= averageGrade)
                return 'C';
            else if (grades[thresold * 4] - 1 <= averageGrade)
                return 'D';
            else return 'F';

            /*for (int i=0; grades.Count;i++)
            {

            }*/
        }
    }
}
