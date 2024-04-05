using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool IsWeight) : base(name, IsWeight)
        {
            Type = Enums.GradeBookType.Ranked;
            Name = name;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();
            int biggerCount = 0;
            foreach (Student s in Students)
            {
                if(averageGrade>s.AverageGrade) biggerCount++;
            }
            if (biggerCount >= Students.Count / 5 * 4)
            {
                return 'A';
            }
            else if (biggerCount >= Students.Count / 5 * 3)
            {
                return 'B';
            }
            else if (biggerCount >= Students.Count / 5 * 2)
            {
                return 'C';
            }
            else if (biggerCount >= Students.Count / 5)
            {
                return 'D';
            }
            else return 'F';
        }
        

        public override void CalculateStatistics()
        {
            
            if (Students.Count < 5) 
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else 
            {
                base.CalculateStatistics();
                Console.WriteLine();
            }
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5) 
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics( name);
                Console.WriteLine();
            }

        }

    }
}
