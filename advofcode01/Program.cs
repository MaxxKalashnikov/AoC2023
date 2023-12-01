using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


//You can get the first soluting by commenting the very first for loop

namespace advofcode01
{
    class Program
    {
        static void Main(string[] args)
        {
            //declearling the path to the file
            string path = @"C:\Users\Максим\source\repos\advofcode01\adventofcode.com_2023_day_1_input.txt";
            int sum = 0;
            //reading the file
            string[] lines = File.ReadAllLines(path);
            string[] onlynum = new string[lines.Length];

            //using dictionary replacing words with numbers
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = ReplaceDigitWordsWithNumbers(lines[i]);
            }

            //saving only numbers to another array
            for (int i = 0; i < lines.Length; i++)
            {
                 onlynum[i] = string.Join("", lines[i].Where(c => char.IsDigit(c)));
            }

            //getting two numbers from the beginning and from the end of the string
            for (int i = 0; i < onlynum.Length; i++)
            {
                if (onlynum[i].Length == 1)
                {
                    onlynum[i] += onlynum[i];
                }
                if (onlynum[i].Length > 2)
                {
                    string fnum = (onlynum[i])[0].ToString();
                    string snum = (onlynum[i])[onlynum[i].Length - 1].ToString();
                    string n = fnum + snum;
                    onlynum[i] = "";
                    onlynum[i] = n;
                }
            }

            //counting the sum
            for (int i = 0; i < onlynum.Length; i++)
            {
                int value = Int32.Parse(onlynum[i]);
                sum += value;
                value = 0;
            }

            Console.WriteLine("The scond solution:" + sum);
        }

        //funtion for replacing the words with numbers
        static string ReplaceDigitWordsWithNumbers(string input)
        {
            Dictionary<string, string> digit = new Dictionary<string, string>
            {
                { "one", "o1e" }, { "two", "t2" }, { "three", "t3e" },
                { "four", "4" }, { "five", "5e" }, { "six", "6" },
                { "seven", "7n" }, { "eight", "e8t" }, { "nine", "9" }
            };

            foreach (var kvp in digit)
            {
                string pattern = kvp.Key;
                input = input.Replace(pattern, kvp.Value.ToString());
            }

            return input;
        }
    }
}
