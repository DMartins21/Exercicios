﻿using System.Globalization;
using System.Linq;
using System.Security.Cryptography;

namespace Exercicios
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter file full path");
            string path = Console.ReadLine();
            List<Prod> p = new();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while(!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string name = line[0];
                        double value = double.Parse(line[1], CultureInfo.InvariantCulture);

                        p.Add(new Prod(name, value));
                    }

                    var r1 = p.Average(p => p.Value);
                    Console.WriteLine($"Average Price:{r1.ToString("F2",CultureInfo.InvariantCulture)}");

                    var r2 = p.Where(p => p.Value < r1).OrderByDescending(p => p.Name);
                    foreach(var name in r2)
                    {
                        Console.WriteLine(name.Name);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An Error occurred: {ex.Message}");
            }
        }

        static void Print<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Prod{
        public string Name { get; set; }
        public double Value { get; set; }

        public Prod(string name, double value) {
            Name = name;
            Value = value;
        }
    }
}