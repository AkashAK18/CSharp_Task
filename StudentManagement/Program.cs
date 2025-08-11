using StudentManagement;
using System;
class Program
{
    static void Main()
    {
        StudentActions details = new StudentActions();
        details.MaxReached += () => Console.WriteLine("Event: More than 5 students added!");

        while (true)
        {
            Console.WriteLine("======Student Management System======\n");
            Console.WriteLine("1. Add Student \n2. Update Student \n3. Delete Student \n4. List All Students \n5. Top Scorer \n6. Total Students in Department \n7. Students Summary \n8. Exit\n");
            Console.Write("Choose: ");
            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        var student = new Student();

                        Console.Write("ID: ");
                        student.Id = int.Parse(Console.ReadLine());
                        Console.Write("Name: ");
                         student.Name = Console.ReadLine();
                        Console.Write("Age: ");
                        student.Age = int.Parse(Console.ReadLine());
                        Console.Write("Department: ");
                        student.Department = Console.ReadLine();
                        Console.Write("Marks: ");
                        student.Marks = double.Parse(Console.ReadLine());

                        Address address = new Address();

                        Console.Write("City: ");
                        address.City = Console.ReadLine();
                        Console.Write("State: ");
                        address.State = Console.ReadLine();
                        Console.Write("PinCode: ");
                        address.PinCode = Console.ReadLine();
                        student.Address = address;

                        details.AddStudent(student);
                        break;

                    case "2":
                        Console.Write("Enter ID to update: ");
                        int userId = int.Parse(Console.ReadLine());

                        Student updatingStudent = new Student();

                        Console.Write("New Name: ");
                        updatingStudent.Name = Console.ReadLine();
                        Console.Write("New Age: ");
                        updatingStudent.Age = int.Parse(Console.ReadLine());
                        Console.Write("New Department: ");
                        updatingStudent.Department = Console.ReadLine();
                        Console.Write("New Marks: ");
                        updatingStudent.Marks = double.Parse(Console.ReadLine());

                        Address newAddress = new Address();

                        Console.Write("New City: ");
                        newAddress.City = Console.ReadLine();
                        Console.Write("New State: ");
                        newAddress.State = Console.ReadLine();
                        Console.Write("Enter PinCode:");
                        newAddress.PinCode = Console.ReadLine();

                        updatingStudent.Address = newAddress;

                        bool updated = details.UpdateStudent(userId, updatingStudent);

                        Console.WriteLine(updated ? "Student updated successfully." : "Student not found.");
                        break;


                    case "3":
                        Console.Write("Enter ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        Console.WriteLine(details.DeleteStudent(deleteId) ? "Deleted." : "Not found.");
                        break;

                    case "4":
                        details.ListStudents();
                        break;

                    case "5":
                        details.TopScorer();
                        break;

                    case "6":
                        details.DepartmentInformation();
                        break;

                    case "7":
                        var summary = details.TotalStudentSummary();
                        Console.WriteLine($"Total Students: {summary.Item1} , Average Marks: {summary.Item2:F2}");
                        break;

                    case "8":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            catch (InvalidStudentException ex)
            {
                Console.WriteLine($"Invalid input: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
