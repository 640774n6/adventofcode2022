using System;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022
{
    public class Day01
    {
        public static void Main(string[] args)
        {
            //Load and parse input into enumerable of calorie sums
            string input = File.ReadAllText(args[0]);
            IEnumerable<int> query = input
                .Split("\n\n")
                .Select(x => x
                    .Split("\n")
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(x => int.Parse(x))
                    .Sum());

            //Part 1: Max
            int part1 = query.Max();
            Console.WriteLine($"part 1: {part1}");

            //Part 2: Top 3 Sum
            int part2 = query
                .OrderByDescending(x => x)
                .Take(3)
                .Sum();
            Console.WriteLine($"part 2: {part2}");
        }
    }
}