using System;
using System.Globalization;
using System.Linq;

Console.WriteLine("Enter full file path:");
string path = Console.ReadLine();

List<Employee> emp = new();

using (StreamReader sr = File.OpenText(path))
{
    while (!sr.EndOfStream)
    {
        string[] lines = sr.ReadLine().Split(',');
        string name = lines[0];
        string email = lines[1];
        double salary = double.Parse(lines[2], CultureInfo.InvariantCulture);

        emp.Add(new(name, email, salary));
    }

    Console.WriteLine("Enter salary:");
    double value = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

    var result = emp.Where(e => e.Salary > value).OrderBy(e => e.Name);

    var r = emp.Where(e => e.Name[0] == 'M').Sum(e => e.Salary); 
    Console.WriteLine("Email of people whose salary is more than 2000.00");
    foreach(var item in result)
    {
        Console.WriteLine(item.Email);
    }
    Console.WriteLine($"Sum od salary of people whose name starts whith 'M':{r.ToString("F2",CultureInfo.InvariantCulture)}");
}





public class Employee
{
    public string Name { get; set; }
    public string Email { get; set; }
    public double Salary { get; set; }

    public Employee(string name, string email, double salary)
    {
        Name = name;
        Email = email;
        Salary = salary;
    }
}