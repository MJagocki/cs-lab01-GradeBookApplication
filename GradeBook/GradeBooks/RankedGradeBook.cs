using GradeBook.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    
     public class RankedGradeBook : BaseGradeBook
    {


        public RankedGradeBook(string name, bool isWeighted) : base(name , isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var seperatedCountStudents = (int)Math.Ceiling(Students.Count * 0.2);
            var studentGrades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (averageGrade >= studentGrades[seperatedCountStudents - 1])
                return 'A';
            if (averageGrade >= studentGrades[(seperatedCountStudents * 2) -1 ])
                return 'B';
            if (averageGrade >= studentGrades[(seperatedCountStudents * 3) - 1])
                return 'C';
            if (averageGrade >= studentGrades[(seperatedCountStudents * 4) - 1])
                return 'D';

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
           

            if (Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students.");
                return ;
            }
            base.CalculateStudentStatistics(name);
        }

     }

}

