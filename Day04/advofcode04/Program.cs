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
            string path = @"C:\Users\Максим\source\repos\advofcode01\Day04\adventofcode.com_2023_day_4_input.txt";

            string[] cards = File.ReadAllLines(path);

            int[][] winnum = new int[cards.Length][];
            int[][] playernum = new int[cards.Length][];

            for (int k = 0; k < cards.Length; k++)
            {
                var cardParts = cards[k].Split(":");
                var allnum = cardParts[1].Split("|");

                winnum[k] = allnum[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                playernum[k] = allnum[1].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            double sum = 0;
            int count = 0;
            Dictionary<int, int> gameCount = new Dictionary<int, int>();
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
                gameCount.Add(i+1, count);
            }

            Console.WriteLine(sum);

            Dictionary<int, int> cardCount = new Dictionary<int, int>();
            
            foreach(var game in gameCount)
            {
                cardCount.Add(game.Key, 1);
            }

            foreach(var game in gameCount)
            {
                foreach (var nextGame in gameCount.Where(x => x.Key > game.Key && x.Key <= game.Key + game.Value))
                {
                    cardCount[nextGame.Key] += cardCount[game.Key];
                }
            }
            int scratchCardTotal = cardCount.Sum(x => x.Value);

            Console.WriteLine(scratchCardTotal);
        }
    }
}
