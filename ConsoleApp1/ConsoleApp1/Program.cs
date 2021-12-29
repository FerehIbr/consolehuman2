using System;

namespace ConsoleApp1
{
    class Program
    {
        private static int workerlimit;

        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();
            do
            {
                Console.WriteLine("-----------------Human Resource Manager-------------------");
                Console.WriteLine("1.departmentlerin siyahisini gostermek");
                Console.WriteLine("2.department yaratmag");
                Console.WriteLine("3.department de deyisiklik etmek");
                Console.WriteLine("4.ishcilerin siyahisini gostermek");
                Console.WriteLine("5.departmentdeki ischilerin siyahisini gostermek");
                Console.WriteLine("6.isci elave etmek");
                Console.WriteLine("7.isci uzerinde deyisiklik etmek");
                Console.WriteLine("8.departmentden isci silinmesi");
                //Console.Write("emaliyyatin nomresini daxil et" );
                string choose = Console.ReadLine();
                double chooseNum;
                double.TryParse(choose, out chooseNum);
                switch (chooseNum)
                {
                    case 1:
                        Console.Clear();
                        GetDepartments(ref humanResourceManager);
                        break;
                    case 2:
                        Console.Clear();
                        AddDepartment(ref humanResourceManager);
                        break;
                    case 3:
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        GetEmployee(ref humanResourceManager);
                        break;
                    case 5:
                        Console.Clear();
                        break;
                    case 6:
                        Console.Clear();
                        AddEmployee(ref humanResourceManager);          
                        break;
                    case 7:
                        Console.Clear();
                        break;
                    case 8:
                        Console.Clear();
                        RemoveEmployee(ref humanResourceManager);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("duzgun daxil et");
                        break;
                }
            } while (true);
        }
        static void RemoveEmployee(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department item in humanResourceManager.Departments)
            {
                foreach (Employee item1 in item.Employees)
                {
                    Console.WriteLine("silmek istediyiniz iscinin nomresini daxil edin");
                    string no = Console.ReadLine();

                    Console.WriteLine("silmek istediyiniz iscinin adini daxil edin");
                    string name = Console.ReadLine();
                    humanResourceManager.RemoveEmployee(no, name);
                }
            }

        }
        public static void GetDepartments(ref HumanResourceManager humanResourceManager)
        {

            foreach (Department item in humanResourceManager.Departments)
            {

                if (humanResourceManager.Departments.Length > 0)
                {
                    Console.WriteLine($"{item}");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("department movcud deyil,once department elave edin");
                }
            }


            humanResourceManager.GetDepartments();
        }
        static void AddDepartment(ref HumanResourceManager humanResourceManager)
        {
            string name;
            bool check = true;
            do
            {
                if (check)
                {
                    Console.WriteLine("departmentin adini daxil edin");
                }
                else
                {
                    Console.WriteLine("duzgun daxil edin");
                }
                name = Console.ReadLine();
                check = false;
            } while (!humanResourceManager.Checkname(name));
            do
            {
                if (check)
                {
                    Console.WriteLine("daxil etdiyiniz department movcuddur.yeniden daxil edin");
                    name = Console.ReadLine();
                }
                check = true;

            } while (!humanResourceManager.Checkname(name));
            Console.WriteLine("isci sayini daxil edin");
        checkWN:
            string WorkerLimit = Console.ReadLine();
            int WorkerLimitNum = 0;
            while (!int.TryParse(WorkerLimit, out WorkerLimitNum) || WorkerLimitNum < 1)
            {
                Console.WriteLine("duzgun daxil edin:");
                goto checkWN;
            }
            Console.WriteLine("maas limitini daxzil et");
        checkSL:
            string SalaryLimit = Console.ReadLine();
            int SalaryLimitNum = 0;
            while (!int.TryParse(SalaryLimit, out SalaryLimitNum) || SalaryLimitNum < 250)
            {
                Console.WriteLine("duzgun daxil edin:");
                goto checkSL;
            }

            humanResourceManager.AddDepartment(name, WorkerLimitNum, SalaryLimitNum);
        }
        static void AddEmployee(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("iscinin fullname'ni daxil edin");
            string name = Console.ReadLine();
            Console.WriteLine("iscinin vezifesini daxil edin");
            string position = Console.ReadLine();
            while (position.Length < 2)
            {
                Console.WriteLine("vezifenin name'in uzunlugu 2den az ola bilmez");
                Console.Write("vezifenin adini yeniden daxil edin");
                position = Console.ReadLine();
            }
            Console.WriteLine("iscinin maasini daxil edin");
            string salaryName = Console.ReadLine();
            double salary;
            while (!double.TryParse(salaryName, out salary) || salary < 250)
            {
                Console.WriteLine("iscinin maasi 250den az ola bilmez");
                Console.Write("iscinin maasi yeniden daxil edin");
                salaryName = Console.ReadLine();
            }
            if (humanResourceManager.Departments.Length == 0)
            {
                Console.WriteLine("department elave olunmayib");
                Console.WriteLine("ilk once department elave edin");
                return;
            }
            else
            {
                Console.WriteLine("mumkun ola bilen departmentler");
            }
            foreach (Department item in humanResourceManager.Departments)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("iscinin departmentini daxil edin");
            string department = Console.ReadLine();
            bool checkname = true;
            int count = 0;
            while (checkname)
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == department.ToLower())
                    {
                        count++;
                    }

                }
                if (count == 0)
                {
                    Console.WriteLine("daxil etdiyiniz adda department yoxdur");
                    return;
                }
                else
                {
                    checkname = false;
                }
                count = 0;
            }
            //foreach (Department item in humanResourceManager.Departments)
            //{
            //    if (department.ToLower() == item.Name.ToLower() && item.Employees.Length > Department.workerlimit)
            //    {
            //        Console.WriteLine(" ");
            //        Console.WriteLine("department doludur,isci elave ede bilmezsiz");
            //        return;
            //    }
            //}
            humanResourceManager.AddEmployee(name, position, salary, department);
        }
        static void GetEmployee(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length > 0)
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Employees.Length > 0)
                    {
                        Console.WriteLine("iscilerin siyahisini daxil edin");
                        foreach (Employee item1 in item.Employees)
                        {
                            Console.WriteLine($"{item1}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("departmentde isci yoxdur");
                    }
                }
            }
            else
            {
                Console.WriteLine("once isci elave edin");
                return;
            }
        }

    }
}
