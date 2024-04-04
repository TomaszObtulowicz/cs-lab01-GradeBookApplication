using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    internal class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
            Name = name;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int biggerCount = 0;
            foreach (Student s in Students)
            {
                if(averageGrade>s.AverageGrade) biggerCount++;
            }
            if (biggerCount > Students.Count / 5 * 4)
            {
                return 'A';
            }
            else if (biggerCount > Students.Count / 5 * 3)
            {
                return 'B';
            }
            else if (biggerCount > Students.Count / 5 * 2)
            {
                return 'C';
            }
            else if (biggerCount > Students.Count / 5)
            {
                return 'D';
            }
            else return 'F';
        }
    }
}
