using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//the second task from advent of code 2023
//the task can be seen at the advent of code web-site


namespace advofcode02
{
    class Program
    {
        static void Main(string[] args)
        {
            //reading from the file
            string path = @"C:\Users\Максим\source\repos\advofcode01\Day02\adventofcode.com_2023_day_2_input.txt";
            string[] lines = File.ReadAllLines(path);

            //nested dictionary to store: game id as key - string, colour as key - string, quantity as value - int
            var totalCounts = new Dictionary<string, Dictionary<string, int>>();

            //loop going through lines content
            foreach (var game in lines)
            {
                var gameParts = game.Split(":"); //spliting the string with colon delimiter to separate game ID and another part
                var gameName = gameParts[0].Trim(); //getting and trimming the game ID
                var sets = gameParts[1].Split(";").Select(s => s.Trim()); //getting sets (the rest part of the string)

                //writing game ID to the nested dictionary 
                if (!totalCounts.ContainsKey(gameName))
                {
                    totalCounts[gameName] = new Dictionary<string, int>();
                }
                //now loop for sets
                foreach (var set in sets)
                {
                    var items = set.Split(",").Select(s => s.Trim()); //spliting each value of the each set 

                    //loop for every value
                    foreach(var item in items)
                    {
                        var parts = item.Trim().Split(" "); //spliting colour and value
                        var quantity = int.Parse(parts[0]); //parsing the value
                        var color = parts[1]; //no need to explain

                        //writing the max value of each game to the nested dictionary with game ID and colur as keys
                        if (!totalCounts[gameName].ContainsKey(color) || quantity > totalCounts[gameName][color])
                        {
                            totalCounts[gameName][color] = quantity;
                        }
                    }
                }
                
            }

            //new arrays to store only values
            int[] green = new int[lines.Length];
            int[] red = new int[lines.Length];
            int[] blue = new int[lines.Length];

            int a = 0; //counter

            //going through nested dictionary with colour as a key
            foreach (var color in totalCounts.Values.SelectMany(g => g.Keys).Distinct())
            {
                a = 0;
                //game ID and value of the colour
                foreach (var (game, count) in totalCounts)
                {
                    //getting the values to arrays
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
                    a++;
                }
                Console.WriteLine();             
            }

            //the logic to get the answer for the first task
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

            //the logic to get the answer for the second task
            double sum2 = 0;

            for (int i = 0; i < green.Length; i++)
            {
                sum2 += green[i] * red[i] * blue[i];        
            }
            Console.WriteLine("The second solution: " + sum2);
        }
    }
}
