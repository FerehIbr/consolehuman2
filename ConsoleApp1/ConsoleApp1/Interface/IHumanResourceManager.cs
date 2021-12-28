using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface IHumanResourceManager
    {
        Department[] Departments { get; }
        //Employees[] employees { get; }
        //List<Department> Departments { get; set; }
        void AddDepartment(string name, int workerlimit, int SalaryLimit);
        void GetDepartments(Department[] departments);
        void EditDepartaments(string name, string newname);
        void AddEmployee(string Name, string position, double salary, string departmentName);
        void RemoveEmployee(string no, string Name);
        void EditEmploye(string no, string Name, double Salary, string Position);

    }
}
