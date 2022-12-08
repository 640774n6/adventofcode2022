using System;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022
{
    public class Day04
    {
        public static void Main(string[] args)
        {
            IEnumerable<IEnumerable<int>[]> input = File.ReadAllText(args[0])
                .Split("\n")
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Split(",").Select(y => Enumerable.Range(int.Parse(y.Split("-")[0]), int.Parse(y.Split("-")[1]) - int.Parse(y.Split("-")[0]) + 1)).ToArray());

            int part1 = input
                .Where(x => !x[0].Except(x[1]).Any() || !x[1].Except(x[0]).Any())
                .Count();
            Console.WriteLine($"part1: {part1}");

            int part2 = input
                .Where(x => x[0].Intersect(x[1]).Any())
                .Count();
            Console.WriteLine($"part2: {part2}");
        }
    }
}