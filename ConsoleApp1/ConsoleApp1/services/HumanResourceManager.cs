using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class HumanResourceManager : IHumanResourceManager
    {
        public Department[] Departments => _departments;
        private Department[] _departments;

        public HumanResourceManager()
        {
            _departments = new Department[0];
        }
        //public void AddDepartment(string name, int workerlimit, int SalaryLimit)
        //{
        //    Department department = new Department(name, workerlimit, SalaryLimit);

        //    Array.Resize(ref _departments, _departments.Length + 1);
        //    _departments[_departments.Length - 1] = department;
        //}
        //public bool Checkname(string str)
        //{
        //    if (!string.IsNullOrEmpty(str))
        //    {
        //        if (Char.IsUpper(str[0]))
        //        {
        //            foreach (var chr in str)
        //            {
        //                if (char.IsLetter(chr) == false)
        //                {
        //                    return false;
        //                }
        //            }
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        public void AddEmployee(string Name, string position, double salary, string departmentName)
        {
            Employee employee = new Employee(Name,position,salary,departmentName);

            foreach (Department item in _departments)
            {
                if (employee.DepartmentName.ToLower() == item.Name.ToLower())
                {
                    Array.Resize(ref item.Employees, item.Employees.Length + 1);
                    item.Employees[item.Employees.Length - 1] = employee;
                }            
            }

        }
        public void EditDepartaments(string name, string newname)
        {
            foreach (Department item in _departments)
            {
                if (item.Name == newname)
                {
                    break;
                }
            }
        }
        public void EditEmploye(string no, string name, double salary, string position)
        {
            Employee employee = null;
            foreach (Department item in _departments)
            {
                foreach (Employee item1 in item.Employees)
                {
                    if (item1.No==no)
                    {
                        employee = item1;
                        return;
                    }
                    employee.Name = name;
                    employee.Salary = salary;
                    employee.Position = position;
                }
            }
        }
        public void GetDepartments()
        {

        }
        public void RemoveEmployee(string no, string Name)
        {
            foreach (Department item in _departments)
            {
                for (int i = 0; i < item.Employees.Length; i++)
                {
                    if (item.Employees[i].No==no)
                    {
                        item.Employees[i] = null;
                        return;
                    }
                }
            }
        }
        public void AddDepartment(string name, int workerlimit, int SalaryLimit)
        {
            Department department = new Department(name, workerlimit, SalaryLimit);

            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = department;
        }
        public bool Checkname(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if (Char.IsUpper(str[0]))
                {
                    foreach (var chr in str)
                    {
                        if (char.IsLetter(chr) == false)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
