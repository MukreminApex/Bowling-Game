using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Program
    {
        public static void Main() {}
    }
    public class Game
    {
        private int score;
        private int[] rolls = new int[21];
        private int currentRoll;

        
        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int Score()
        {
            int score = 0;
            int roll = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                // Instead of the below code,
                // create a new method for Strike,
                // and call it, to reduce repetitions and clutter.
                // The same method goes for Spare.

                // if (rolls[roll] == 10) // strike

                if (IsStrike(roll))
                {
                    score += 10 + StrikeBonus(roll);
                    roll += 2;
                }
                else if (IsSpare(roll))
                {
                    score += 10 + SpareBonus(roll);
                    roll += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(roll);
                    roll += 2;
                }
            }

            return score;
        }

        private int SumOfBallsInFrame(int roll)
        {
            return rolls[roll] + rolls[roll + 1];
        }

        private int SpareBonus(int roll)
        {
            return rolls[roll + 2];
        }

        private int StrikeBonus(int roll)
        {
            return rolls[roll + 1] + rolls[roll + 2];
        }

        private bool IsSpare(int roll)
        {
            return rolls[roll] + rolls[roll + 1] == 10;
        }

        private bool IsStrike(int roll)
        {
            return rolls[roll] == 10;
        }
    }
}
