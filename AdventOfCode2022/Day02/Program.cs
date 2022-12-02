using System;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022
{
    public enum GameHand
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    };

    public enum GameResult
    {
        Loss = 0,
        Tie = 3,
        Win = 6
    }

    public class Day02
    {
        private static int CalcScorePart1(GameHand opponent, GameHand player)
        {
            //Calculate score based on a tie
            if (player == opponent)
                return (int)player + (int)GameResult.Tie;

            //Calculate score based on player hand
            int score = (int)player;
            switch (player)
            {
                case GameHand.Rock:
                    score += (int)(opponent == GameHand.Scissors ? GameResult.Win : GameResult.Loss);
                    break;
                case GameHand.Paper:
                    score += (int)(opponent == GameHand.Rock ? GameResult.Win : GameResult.Loss);
                    break;
                case GameHand.Scissors:
                    score += (int)(opponent == GameHand.Paper ? GameResult.Win : GameResult.Loss);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Invalid game hand");
            }

            //Return score
            return score;
        }

        private static int CalcScorePart2(GameHand opponent, GameResult desiredResult)
        {
            //Calculate score based on a tie
            if (desiredResult == GameResult.Tie)
                return (int)opponent + (int)desiredResult;

            //Calculate score based on opponent hand and desired result
            int score = (int)desiredResult;
            switch(opponent)
            {
                case GameHand.Rock:
                    score += (int)(desiredResult == GameResult.Win ? GameHand.Paper : GameHand.Scissors);
                    break;
                case GameHand.Paper:
                    score += (int)(desiredResult == GameResult.Win ? GameHand.Scissors : GameHand.Rock);
                    break;
                case GameHand.Scissors:
                    score += (int)(desiredResult == GameResult.Win ? GameHand.Rock : GameHand.Paper);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Invalid game hand");
            }

            //Return score
            return score;
        }

        public static void Main(string[] args)
        {
            //Load input
            string input = File.ReadAllText(args[0]);

            //Parse input and calculate score sum using strategy 1
            int part1 = input
                .Split("\n")
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.ToCharArray())
                .Select(x => CalcScorePart1((GameHand)(((x[0] - 'A') + 1)), (GameHand)((x[2] - 'X') + 1)))
                .Sum();
            Console.WriteLine($"part 1: {part1}");

            //Parse input and calculate score sum using strategy 2
            int part2 = File.ReadAllText(args[0])
                .Split("\n")
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.ToCharArray())
                .Select(x => CalcScorePart2((GameHand)(((x[0] - 'A') + 1)), (GameResult)((x[2] - 'X') * 3)))
                .Sum();
            Console.WriteLine($"part 2: {part2}");
        }
    }
}