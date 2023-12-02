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
                var gameNames = gameName[1];
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
                        totalCounts[gameName][color] = 0;
                        totalCounts[gameName][color] += quantity;
                    }
                }
                
            }
            foreach (var color in totalCounts.Values.SelectMany(g => g.Keys).Distinct())
            {
                Console.WriteLine($"Total {color} cubes in each game:");
                foreach (var (game, count) in totalCounts)
                {
                    Console.WriteLine($"{game}: {count.GetValueOrDefault(color, 0)}");
                }
                Console.WriteLine();
            }
        }
    }
}
