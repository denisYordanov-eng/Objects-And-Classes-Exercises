using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_AverageGrades
{
    class Program
    {
        class Student
        {
            public string Name { get; set; }
            public double[] Grades { get; set; }
            public double AverageGrades => this.Grades.Average();
        }
        static void Main(string[] args)
        {
          var input = ReadInput();
           PrintOutput(input); 
        }

        private static void PrintOutput(List<Student> input)
        {
            var exelentScore = 
                input.Where(a => a.Grades.Average() >= 5.00)
                .ToList();
            foreach (Student student in exelentScore)
            {
                Console.WriteLine($"{student.Name} -> {student.AverageGrades:f2}");
            }
        }

        private static List<Student> ReadInput()
        {
            int iterations = int.Parse(Console.ReadLine());

            List<Student> studentData = new List<Student>();

            for (int i = 0; i < iterations; i++)
            {
                var input = Console.ReadLine().Split(' ');

                string name = input[0];
                var scores = input.Skip(1).Select(a => double.Parse(a)).ToArray();

                Student newSudent = new Student();

                newSudent.Name = name;
                newSudent.Grades = scores;

                studentData.Add(newSudent);
            }
            var filterStudentData = studentData.OrderBy(a => a.Name)
                .ThenByDescending(a => a.AverageGrades).ToList();

            return filterStudentData;
        }
    }
}
