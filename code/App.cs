using System;
using System.Collections.Generic;
using System.Threading;

namespace Roulette
{
    internal class App
    {
        public App()
        {
        }

        internal void Run()
        {
            //Implement the different bets
            //1. the number of the bin
            //2. Evens/Odds
            //3. Reds/Blacks
            //4. Lows/Highs (1-18) (19-36)
            //5. Dozens (1-12) (13-24) (25-36)
            //6. Columns: first second or third
            //7. Streets: rows 1/2/3 or 22/23/24
            //8. 6 Numbers: Double rows 1/2/3/4/5/6 or 22/23/24/25/26/27
            //9. Split the edge of any two contiguoius numbers 1/2, 11/14, 35/36
            //10. Corners: 1/2/4/5 or 23/24/26/27

            List<Bin> bins = Bin.GenerateBins();
            int randomBin = 0;
            Bin chosenBin = new Bin();

            randomBin = RandomBallDrop(bins);
            chosenBin = bins[randomBin];
            Console.WriteLine("The winning bets were:");

            Bet.Numbers(randomBin);
            Bet.EvenOdd(randomBin);
            Bet.RedBlack(chosenBin, randomBin);
            Bet.LowHigh(randomBin);
            Bet.Dozens(randomBin);
            Bet.Columns(randomBin);
            Bet.Street(randomBin);
            Bet.SixNumbers(randomBin);
            Bet.Split(randomBin);
            Bet.Corner(randomBin);
        }

        private int RandomBallDrop(List<Bin> bins)
        {
            int delay = 0;
            bool finsihed = false;
            int tempRand = 0;
            do
            {
                //Console.Beep();
                if (delay < 851)
                {
                    tempRand = RandFancyBinPrint(bins, delay);
                }
                else
                {
                    finsihed = true;
                    Console.SetCursorPosition(0, 8);
                    return tempRand;
                }
                delay = delay + 75;
            } while (!finsihed);
            return tempRand;
        }

        private int RandFancyBinPrint(List<Bin> bins, int delay)
        {
            Random rand = new Random();
            int tempRand = rand.Next(37);
            int i = 0;
            foreach (var bin in bins)
            {
                if (bin.color == "Black")
                    Console.BackgroundColor = ConsoleColor.Black;
                if (bin.color == "Red")
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                if (bin.color == "Green")
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                if (i == tempRand)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.SetCursorPosition(bin.x * 4, bin.y * 2);
                Console.Write(bin.number);
                Console.ResetColor();
                i++;
            }
            Thread.Sleep(delay);
            Console.SetCursorPosition(0, 8);
            return tempRand;
        }

        private void FancyBinPrint(List<Bin> bins)
        {
            foreach (var bin in bins)
            {
                if (bin.color == "Black")
                    Console.BackgroundColor = ConsoleColor.Black;
                if (bin.color == "Red")
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                if (bin.color == "Green")
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(bin.x * 4, bin.y * 2);
                Console.Write(bin.number);
                Console.ResetColor();
            }
            Console.SetCursorPosition(0, 8);
            Console.WriteLine("Fancy Board Print");
        }

        private static void PrintBins(List<Bin> bins)
        {
            foreach (var bin in bins)
            {
                if (bin.color == "Black")
                    Console.BackgroundColor = ConsoleColor.Black;
                if (bin.color == "Red")
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                if (bin.color == "Green")
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write($"Bin {bin.number} is the color {bin.color}");
                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}