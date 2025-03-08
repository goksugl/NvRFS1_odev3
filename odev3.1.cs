

using System;

namespace EmployeeApp
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }

        public Employee(int id, string name, double salary, string department)
        {
            Id = id;
            Name = name;
            Salary = salary;
            Department = department;
        }

        // Virtual metot: Alt sınıflar override edecek
        public virtual double CalculateBonus()
        {
            return 0; 
        }
    }

    public class Manager : Employee
    {
        public Manager(int id, string name, double salary, string department)
            : base(id, name, salary, department)
        {
        }

        public override double CalculateBonus()
        {
            return Salary * 0.2; // Maaşın %20’si prim
        }
    }

    public class Developer : Employee
    {
        public Developer(int id, string name, double salary, string department)
            : base(id, name, salary, department)
        {
        }

        public override double CalculateBonus()
        {
            return Salary * 0.1; // Maaşın %10’u prim
        }
    }

    class Program
    {
        static void Main()
        {
            // Kullanıcıdan yönetici bilgilerini alma
            Console.WriteLine("***** Yönetici Bilgileri *****");
            Console.Write("Yöneticinin Adı: ");
            string managerName = Console.ReadLine();

            Console.Write("Maaşı: ");
            double managerSalary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Departmanı: ");
            string managerDepartment = Console.ReadLine();

            // Yönetici nesnesi oluşturma
            Manager manager = new Manager(1, managerName, managerSalary, managerDepartment);

            // Kullanıcıdan geliştirici bilgilerini alma
            Console.WriteLine("\n***** Geliştirici Bilgileri *****");
            Console.Write("Geliştiricinin Adı: ");
            string developerName = Console.ReadLine();

            Console.Write("Maaşı: ");
            double developerSalary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Departmanı: ");
            string developerDepartment = Console.ReadLine();

            // Geliştirici nesnesi oluşturma
            Developer developer = new Developer(2, developerName, developerSalary, developerDepartment);

            // Bonus hesaplamaları
            double managerBonus = manager.CalculateBonus();
            double developerBonus = developer.CalculateBonus();

            // Çıktılar
            Console.WriteLine("\n***** Çalışan Prim Bilgileri *****");
            Console.WriteLine($"Yönetici {manager.Name} için prim: {managerBonus:C}");
            Console.WriteLine($"Geliştirici {developer.Name} için prim: {developerBonus:C}");
        }
    }
}