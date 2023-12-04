using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advofcode04
{
    class Program
    {
        static void Main(string[] args)
        {
            //reading the file
            string path = @"C:\Users\Максим\source\repos\advofcode01\Day04\adventofcode.com_2023_day_4_input.txt";

            string[] cards = File.ReadAllLines(path);
            //creating empty arrays for palyers numbers and for winning numbers
            int[][] winnum = new int[cards.Length][];
            int[][] playernum = new int[cards.Length][];

            for (int k = 0; k < cards.Length; k++)
            {
                //considering the input splitting the strings to get only numbers to arrays
                var cardParts = cards[k].Split(":");
                var allnum = cardParts[1].Split("|");
                //parsing to integer and writing to the arrays
                winnum[k] = allnum[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                playernum[k] = allnum[1].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            //variables for counting the sum
            double sum = 0;
            int count = 0;
            //dictionary for the second task
            Dictionary<int, int> gameCount = new Dictionary<int, int>();
            //pretty straight forward logic to count the sum if there is a match
            for (int i = 0; i < winnum.Length; i++)
            {
                count = 0;
                for (int j = 0; j < winnum[i].Length; j++)
                {
                    for (int t = 0; t < playernum[i].Length; t++)
                    {
                        if (winnum[i][j] == playernum[i][t])
                        {
                            if(count == 0)
                            {
                                count++;
                                sum += count;
                            }
                            else
                            {
                                sum += Math.Pow(2, count - 1);
                                count++;
                            }
                        }
                    }
                }
                //writing the quantity of all matching numbers as values and game id as a key
                gameCount.Add(i+1, count);
            }

            Console.WriteLine("The first task: " + sum);
            //new dictionary for the second task
            Dictionary<int, int> cardCount = new Dictionary<int, int>();
            
            //filling the dictioonary with default values and game id keys
            foreach(var game in gameCount)
            {
                cardCount.Add(game.Key, 1);
            }

            foreach(var game in gameCount)
            {
                //here i used Linq to get the info according to the task
                foreach (var nextGame in gameCount.Where(x => x.Key > game.Key && x.Key <= game.Key + game.Value))
                {
                    //summing keys
                    cardCount[nextGame.Key] += cardCount[game.Key];
                }
            }
            //counting the sum
            int scratchCardTotal = cardCount.Sum(x => x.Value);

            Console.WriteLine("The second task: " + scratchCardTotal);
        }
    }
}
