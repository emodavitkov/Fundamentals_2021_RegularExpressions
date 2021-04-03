using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string validLinePattern = @"\B>>(?<furnitureName>[A-Za-z]+)<<(?<price>(?:\d+)|(?:\d+\.\d+))\!(?<quantity>\d+)\b";
            Regex validInput = new Regex(validLinePattern);
            string line = Console.ReadLine(); //">>{furniture name}<<{price}!{quantity}"
            List<string> furnitures = new List<string>();
            decimal spendMoney = 0;
            while (line != "Purchase")
            {
                if (validInput.IsMatch(line))
                {
                    furnitures.Add(validInput.Match(line).Groups["furnitureName"].Value);
                    int quantity = int.Parse(validInput.Match(line).Groups["quantity"].Value);
                    decimal price = decimal.Parse(validInput.Match(line).Groups["price"].Value);

                    spendMoney += quantity * price;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            if (furnitures.Count != 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, furnitures));
            }
            Console.WriteLine($"Total money spend: {spendMoney:F2}");
        }
    }
}