using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ReportGenerator
{
    public class FetchStudent
    {
        public async Task<List<Student>> LoadStudentDataAsync(string filePath)
        {
            List<Student> students = new List<Student>();

            using StreamReader reader = new StreamReader(filePath);
            string details;
            while ((details = await reader.ReadLineAsync()) != null)
            {
                string[] word = details.Split(',');
                if (word.Length == 3)
                {
                    students.Add(new Student
                    {
                        Id = int.Parse(word[0]),
                        Name = word[1],
                        Department = word[2]
                    });
                }
            }

            return students;
        }
    }

    public class GiveReport
    {
        public async Task<bool> GenerateReportAsync(Student student)
        {
            Console.WriteLine($"[{student.Name}] Report generation started.");
            await Task.Delay(1000); //ReportDelay

            if (student.Name == "Kavin")
            {
                Console.WriteLine($"[{student.Name}] Report generation failed.");
                return false;
            }

            Console.WriteLine($"[{student.Name}] Report generated.");
            return true;
        }
    }

    public class Notify
    {
        public async Task SendNotificationAsync(Student student)
        {
            await Task.Delay(1000); //NotificationDelay
            Console.WriteLine($"[{student.Name}] Notification sent.");
        }
    }
}
