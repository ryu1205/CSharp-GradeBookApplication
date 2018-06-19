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
        public RankedGradeBook(string name, bool condition) : base(name, condition)
        {
            Type = GradeBookType.Ranked;
        }

        // GetLetterGrade method Override
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("(Ranked-grading requires a minimum of 5 students to work");

            var threshold = (int)Math.Ceiling(Students.Count*0.2);

            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList() ;
            if (grades[threshold - 1] <= averageGrade)
                return 'A';
            else if (grades[(threshold * 2) - 1] <= averageGrade)
                return 'B';
            else if (grades[(threshold * 3) - 1]  <= averageGrade)
                return 'C';
            else if (grades[(threshold * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }

        //
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade");
                return;
            }             

            base.CalculateStatistics();
        }

        //
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
