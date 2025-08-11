using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string filePath = "student.txt";

            FetchStudent fetchStudent = new FetchStudent();
            GiveReport giveReport = new GiveReport();
            Notify notify = new Notify();

            Console.WriteLine("Loading student data...");
            List<Student> students = await fetchStudent.LoadStudentDataAsync(filePath);

            Console.WriteLine("Generating reports...\n");

            int success = 0, failed = 0;

            var taskResult = students.Select(async student =>
            {
                bool generatedReport = await giveReport.GenerateReportAsync(student);
                if (generatedReport)
                {
                    await notify.SendNotificationAsync(student);
                    success++;
                }
                else
                {
                    failed++;
                }
            });

            await Task.WhenAll(taskResult);

            Console.WriteLine("\nAll reports completed.\n");
            Console.WriteLine("Report Summary:");
            Console.WriteLine($"- Total Students: {students.Count}");
            Console.WriteLine($"- Successful Reports: {success}");
            Console.WriteLine($"- Failed Reports: {failed}");

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
