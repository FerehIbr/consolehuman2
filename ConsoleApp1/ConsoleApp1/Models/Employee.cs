using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Employee
    {
        private static int _Count = 1000;
        public string Name { get; set; }
        public string No { get; set; }
        public string Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (value.Length < 2)
                {
                    Console.WriteLine("Min 2 simvol ola biler");
                    return;
                }
                _position = value;
            }
        }
        private string _position;
        public double Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value < 2)
                {
                    return;
                }
                _salary = value;
            }
        }
        private double _salary;
        public string DepartmentName { get; set; }

        public Employee(string name, string position, double salary, string departmentName)
        {
            No += departmentName.ToUpper().Substring(0, 2) + _Count;
            _Count++;
            Name = name;
            Position = position;
            Salary = salary;
            DepartmentName = departmentName;
        }

        public Employee(string departmentName)
        {
            DepartmentName = departmentName;
        }

        public override string ToString()
        {
            return $"Nomresi: {No}\n Name: {Name} \n Position: {Position} \n Salary: {Salary} \n DepartmentName: {DepartmentName}";
        }

    }
}
