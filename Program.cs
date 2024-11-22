using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danh_Sach_SV
{
    internal class Program
    {
        static void Main(string[] args)

        {// Tao danh sach cac hoc sinh
            List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Man", Age = 16 },
            new Student { Id = 2, Name = "Cristiano Ronaldo", Age = 14 },
            new Student { Id = 3, Name = "Leo Messi", Age = 18 },
            new Student { Id = 4, Name = "Kilyam Mpape", Age = 15 },
            new Student { Id = 5, Name = "Alan Wakel", Age = 17 }
        };

            // a. In danh sach toan bo hoc sinh
            Console.WriteLine("Danh sach hoc sinh:");
            students.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}"));

            // b. Tim va in danh sach cac hoc sinh co tuoi tu 15 den 18
            var age15to18 = students.Where(s => s.Age >= 15 && s.Age <= 18).ToList();
            Console.WriteLine("\nHoc sinh co tuoi tu 15 den 18:");
            age15to18.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}"));

            // c. Tim va in hoc sinh co ten bat dau bang chu "A"
            var startWithA = students.Where(s => s.Name.StartsWith("A")).ToList();
            Console.WriteLine("\nHoc sinh co ten bat dau bang chu 'A':");
            startWithA.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}"));

            // d. Tinh tong tuoi cua tat ca hoc sinh
            int totalAge = students.Sum(s => s.Age);
            Console.WriteLine($"\nTong tuoi cua tat ca hoc sinh: {totalAge}");

            // e. Tim va in hoc sinh co tuoi lon nhat
            int maxAge = students.Max(s => s.Age);
            var oldestStudents = students.Where(s => s.Age == maxAge).ToList();
            Console.WriteLine("\nHoc sinh co tuoi lon nhat:");
            oldestStudents.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}"));

            // f. Sap xep danh sach theo tuoi tang dan va in danh sach
            var sortedByAge = students.OrderBy(s => s.Age).ToList();
            Console.WriteLine("\nDanh sach hoc sinh sau khi sap xep theo tuoi tang dan:");
            sortedByAge.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}"));

            Console.ReadLine();
        }
    }
}

