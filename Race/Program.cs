using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> racerDistance = new Dictionary<string, int>();
            Console.ReadLine().Split(", ").ToList().ForEach(x => racerDistance.Add(x, 0));

            string text = Console.ReadLine();
            while (text != "end of race")
            {
                StringBuilder name = new StringBuilder();
                int number = 0;
                foreach (var item in text)
                {
                    if (char.IsLetter(item))
                    {
                        name.Append(item);
                    }
                    if (char.IsDigit(item))
                    {
                        number += int.Parse(item.ToString());
                    }
                }
                if (racerDistance.ContainsKey(name.ToString()))
                {
                    racerDistance[name.ToString()] += int.Parse(number.ToString());
                }
                text = Console.ReadLine();
            }
            string[] place = { "1st", "2nd", "3rd" };
            List<string> output = racerDistance.Where(d => d.Value > 0).OrderByDescending(d => d.Value).Select(k => k.Key).ToList();
            int max = (output.Count > 3) ? 3 : output.Count;
            for (int i = 0; i < max; i++)
            {
                Console.WriteLine($"{place[i]} place: {output[i]}");
            }
        }
    }
}