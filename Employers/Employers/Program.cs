using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;

namespace Employers
{
    class Employee //2. feladat összetett adatszerkezet.
    {
        private int id;
        private string name;
        private int age;
        private int earnings;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public int Earnings
        {
            get { return earnings; }
            set { earnings = value; }
        }
    }
    internal class Program
    {
        static List<Employee> employees = new List<Employee>();
        static void Main(string[] args)
        {
            //1. feladat
            StreamReader sr = new StreamReader("tulajdonsagok_100sor.txt");
            while (!sr.EndOfStream)//a dolgozók hozzáadása az employees listához.
            {
                string[] temp = sr.ReadLine().Split(';');
                Employee emp = new Employee();
                emp.Id= Convert.ToInt32(temp[0]);
                emp.Name= temp[1];
                emp.Age= Convert.ToInt32(temp[2]);
                emp.Earnings= Convert.ToInt32(temp[3]);
                employees.Add(emp);
            }
            sr.Close();

            foreach (var item in employees)// 3. feladat: megjelenítem a dolgozók nevét.
            {
                Console.WriteLine($"{item.Name}");
            }

            //4. feladat: a legjobban keresők nevének és azonosítójának kiírása.
            
            int max = 0;
            foreach (var item in employees)
            {
                if (max <= item.Earnings)
                {
                    max = item.Earnings;
                }
            }
            foreach (var item in employees)
            {
                if (item.Earnings>=max)
                {
                    Console.WriteLine($"\nAzonosító: {item.Id}\nNév: {item.Name}");
                }
            }


            Console.ReadKey();
        }
    }
}
