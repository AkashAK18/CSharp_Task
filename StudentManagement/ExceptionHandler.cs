using System;

namespace StudentManagement
{
    public class InvalidStudentException : Exception
    {
        public InvalidStudentException(string message) : base(message) { }
    }
}
