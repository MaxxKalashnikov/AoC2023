using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advofcode02
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Максим\source\repos\advofcode01\Day02\adventofcode.com_2023_day_2_input.txt";
            string[] lines = File.ReadAllLines(path);
            var totalCounts = new Dictionary<string, Dictionary<string, int>>();

            foreach (var game in lines)
            {
                var gameParts = game.Split(":");
                var gameName = gameParts[0].Trim();
                var sets = gameParts[1].Split(";").Select(s => s.Trim());

                if (!totalCounts.ContainsKey(gameName))
                {
                    totalCounts[gameName] = new Dictionary<string, int>();
                }

                foreach (var set in sets)
                {
                    var items = set.Split(",").Select(s => s.Trim());
                    foreach(var item in items)
                    {
                        var parts = item.Trim().Split(" ");
                        var quantity = int.Parse(parts[0]);
                        var color = parts[1];
                        if (!totalCounts[gameName].ContainsKey(color) || quantity > totalCounts[gameName][color])
                        {
                            totalCounts[gameName][color] = quantity;
                        }
                    }
                }
                
            }
            int[] green = new int[lines.Length];
            int[] red = new int[lines.Length];
            int[] blue = new int[lines.Length];
            int a = 0;
            foreach (var color in totalCounts.Values.SelectMany(g => g.Keys).Distinct())
            {
                a = 0;
                Console.WriteLine($"Total {color} cubes in each game:");
                foreach (var (game, count) in totalCounts)
                {
                    switch (color)
                    {
                        case "green":
                            green[a] = count.GetValueOrDefault(color, 0);
                            break;
                        case "red":
                            red[a] = count.GetValueOrDefault(color, 0);
                            break;
                        case "blue":
                            blue[a] = count.GetValueOrDefault(color, 0);
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine($"{game}: {count.GetValueOrDefault(color, 0)}");
                    a++;
                }
                Console.WriteLine();             
            }
            int sum = 0;
            int t = 1;
            for (int i = 0; i < green.Length; i++)
            {
                if(green[i] <= 13 && red[i] <= 12 && blue[i] <= 14)
                {
                    sum += t;
                }
                t++;
            }
            Console.WriteLine("The first solution: " + sum);
            double sum2 = 0;

            for (int i = 0; i < green.Length; i++)
            {
                sum2 += green[i] * red[i] * blue[i];        
            }
            Console.WriteLine("The second solution: " + sum2);
        }
    }
}
