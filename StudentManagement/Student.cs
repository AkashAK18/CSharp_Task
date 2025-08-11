using System;

namespace StudentManagement
{
    public enum Level
    {
        Average,   
        Good,      
        Excellent  
    }

    // Address struct
    public struct Address
    {
        public string City;
        public string State;
        public string PinCode;

        public override string ToString() => $"{City}, {State}, {PinCode}";
    }

    // Student class with Level derived from Marks
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public double Marks { get; set; }
        public Address Address { get; set; }

        public Level Level
        {
            get
            {
                if (Marks >= 85)
                    return Level.Excellent;
                else if (Marks >= 60)
                    return Level.Good;
                else
                    return Level.Average;
            }
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Age: {Age}, Dept: {Department}, Marks: {Marks}, Level: {Level}, Address: {Address}";
        }
    }
}
