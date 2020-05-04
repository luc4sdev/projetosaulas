using System;
using System.Globalization;
using System.Collections.Generic;
using teste.Entities;
namespace teste
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();
            Console.Write("Enter the number of employees ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Employee #{i} data:");
                Console.Write(" Outsorced (y/n)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Hours: ");
                int hours = int.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valueperhour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (ch == 'y')
                {
                    Console.Write("Additional charge: ");
                    double additionalcharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new OutsorcedEmployee(name, hours, valueperhour, additionalcharge));
                }
                else
                {
                    list.Add(new Employee(name, hours, valueperhour));
                }

            }
            Console.WriteLine();
            Console.WriteLine("Payments:");
            foreach (Employee emp in list)
            {
                Console.WriteLine(emp.Name + " - $ " +  emp.Payment().ToString("F2",CultureInfo.InvariantCulture));
            }


        }
    }
}

