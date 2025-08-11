using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement
{
    public class StudentActions
    {
        public List<Student> students = new List<Student>();
        public event Action MaxReached;

        public void AddStudent(Student student)
        {

            if (students.Count >= 1)
            {
                MaxReached?.Invoke();
                return;
            }

            if (student.Marks < 0 || student.Marks > 100)
                throw new InvalidStudentException("Marks must be between 0 and 100.");

            students.Add(student);
        }

        public bool UpdateStudent(int id, Student updatingStudent)
        {
            var student = students.FirstOrDefault(student => student.Id == id);
            if (student == null)
                return false;

            student.Name = updatingStudent.Name;
            student.Age = updatingStudent.Age;
            student.Department = updatingStudent.Department;
            student.Marks = updatingStudent.Marks;

            student.Address = updatingStudent.Address;
            
            return true;
        }

        public bool DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(student => student.Id == id);
            if (student == null)
                return false;

            students.Remove(student);
            return true;
        }

        public void ListStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.");
            }
            else
            {
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
        }

        public void TopScorer()
        {
            var topper = students.OrderByDescending(student => student.Marks).FirstOrDefault();
            Console.WriteLine(topper != null ? $"Top Scorer: {topper}" : "No students found.");
        }

        public void DepartmentInformation()
        {
            var group = students.GroupBy(student => student.Department);
            foreach (var item in group)
            {
                Console.WriteLine($"\nDepartment: {item.Key} ({item.Count()} Students)");
                foreach (var student in item)
                    Console.WriteLine($" - {student.Name} ({student.Marks})");
            }
        }

        public (int, double) TotalStudentSummary()
        {
            int total = students.Count();
            double average = students.Average(mark => mark.Marks);
            return (total, average);
        }
    }
}
