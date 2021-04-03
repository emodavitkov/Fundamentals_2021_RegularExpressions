using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?:%(?<name>[A-Z][a-z]+)%)(?:[^%$|.]+)?(?:<(?<product>\w+)>)(?:[^%$|.]+)?(?:\|(?<count>\d+)\|)(?:[^%$|.0-9]+)?(?<price>\d+\.?\d+?)\$";
            Regex regex = new Regex(pattern);
            double income = 0;
            string line = Console.ReadLine();
            while (line != "end of shift")
            {
                if (regex.IsMatch(line))
                {
                    string customerName = regex.Match(line).Groups["name"].Value;
                    string product = regex.Match(line).Groups["product"].Value;
                    int count = int.Parse(regex.Match(line).Groups["count"].Value);
                    double totalPrice = double.Parse(regex.Match(line).Groups["price"].Value) * count;
                    Console.WriteLine($"{customerName}: {product} - {totalPrice:F2}");
                    income += totalPrice;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {income:F2}");
        }
    }
}