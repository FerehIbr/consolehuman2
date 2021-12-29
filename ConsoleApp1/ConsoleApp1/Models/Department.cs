using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Department
    {
        public string Name { get; set; }
        public int Workerlimit { get; set; }
        public int SalaryLimit { get; set; }
        public Employee[] Employees = new Employee[0];


        public double CalcAverageSalary(Department department)
        {
            double TotalSalary = 0;
            int count = 0;
            foreach (Employee item in department.Employees)
            {
                TotalSalary += item.Salary;
                count++;
            }
            return TotalSalary / count;
        }
        public Department(string name, int workerlimit, int salarylimit, Employee[] employee)
        {
            Employees = new Employee[0];
            Name = name;
            Workerlimit = workerlimit;
            SalaryLimit = salarylimit;
            Employees = employee;
            if (Workerlimit < 1)
            {
                Console.WriteLine("isci sayi duzgun daxil olunmayib!");
            }
            if (SalaryLimit < 250)
            {
                Console.WriteLine("mebleg duzgun daxil olunmayib!");
            }
        }

        public Department(string name, int workerlimit, int salaryLimit)
        {
            Name = name;
            Workerlimit = workerlimit;
            SalaryLimit = salaryLimit;
        }

        internal double TotalSalary(Department department)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"Department adi: {Name}\nIshci sayi: {Workerlimit}\nMaas limiti: {SalaryLimit}";
        }
    }
}
