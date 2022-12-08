using System;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022
{
    public class Day03
    {
        public static void Main(string[] args)
        {
            IEnumerable<string> input = File.ReadAllText(args[0])
                .Split("\n")
                .Where(x => !string.IsNullOrWhiteSpace(x));

            int part1 = input
                .Select(x => x.Substring(0, (int)(x.Length / 2)).Intersect(x.Substring((int)(x.Length / 2), (int)(x.Length / 2))).First())
                .Select(x => x >= 'A' && x <= 'Z' ? x - 38 : x - 96)
                .Sum();
            Console.WriteLine($"part1: {part1}");

            int part2 = input
                .Chunk(3)
                .Select(x => x[0].Intersect(x[1]).Intersect(x[2]).First())
                .Select(x => x >= 'A' && x <= 'Z' ? x - 38 : x - 96)
                .Sum();
            Console.WriteLine($"part2: {part2}");
        }
    }
}