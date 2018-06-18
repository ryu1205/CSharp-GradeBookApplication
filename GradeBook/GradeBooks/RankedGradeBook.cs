using GradeBook.Enums;
using System;
using System.Collections.Generic;
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
    }
}
