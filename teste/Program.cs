using System;
using System.Globalization;
using teste.Entities.Enums;
using teste.Entities;
namespace teste
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department´s name: ");
            string department = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double basesalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Department dept = new Department(department);
            Worker worker = new Worker(name, level, basesalary, dept);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter #" + i + " contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valueperhour = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valueperhour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthandyear = Console.ReadLine();
            int month = int.Parse(monthandyear.Substring(0, 2));
            int year = int.Parse(monthandyear.Substring(3));

            Console.WriteLine("Name " + worker.Name);
            Console.WriteLine("Department " + worker.Department.Name);
            Console.WriteLine("Income for " + monthandyear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}

