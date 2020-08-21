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
            int numberOfBins = 36;
            int numberOfColumns = 3;

            IntroAndOptions(ref numberOfBins, ref numberOfColumns);

            Console.Clear();

            List<Bin> bins = Bin.GenerateBins(numberOfBins, numberOfColumns);
            int randomBin = 0;
            Bin chosenBin = new Bin();

            randomBin = RandomBallDrop(bins, numberOfBins, numberOfColumns);
            chosenBin = bins[randomBin];

            Console.SetCursorPosition(0, (numberOfColumns * 2) + 2);
            Console.WriteLine("The winning bets were:");

            //           FancyBinPrint(bins);
            //           randomBin = 35;

            Bet.Numbers(randomBin, numberOfBins);
            Bet.EvenOdd(randomBin, numberOfBins);
            Bet.RedBlack(chosenBin, randomBin, numberOfBins);
            Bet.LowHigh(randomBin, numberOfBins);
            Bet.Dozens(randomBin, numberOfBins);
            Bet.Columns(randomBin, numberOfBins, bins);
            Bet.Street(randomBin, numberOfBins, numberOfColumns);
            Bet.SixNumbers(randomBin, numberOfBins, numberOfColumns);
            Bet.Split(randomBin, numberOfBins, numberOfColumns);
            Bet.Corner(randomBin, numberOfBins, numberOfColumns);

            int street = bins[randomBin].x;
            int column = bins[randomBin].y;

            Console.WriteLine("Here is the test of a street");
            foreach (var bin in bins)
            {
                if (bin.x == street)
                    Console.Write(bin.number + " ");
            }
        }

        private static void IntroAndOptions(ref int numberOfBins, ref int numberOfColumns)
        {
            Console.WriteLine("The standard Roulette table has 36 numbers in 3 columns.");
            Console.Write("If you want to enter your own wacky values, enter \"y\" if not hit anything else: ");
            var answer = Console.ReadKey();
            string answerString = answer.KeyChar.ToString();
            if (answerString == "y")
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("\n\nYou are going to get some WACKY results because the bets have not been fully set up for this (yet)");
                Console.WriteLine("If you put in more than 420 bins and/or more than 15 columns you are going to probably break things");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("But, that's ok, you do you.");
                Console.ResetColor();
                Console.Write("\n\nEnter how many numbers you want on the Roulette Table then hit enter: ");
                answerString = Console.ReadLine();
                numberOfBins = int.Parse(answerString);
                Console.Write("\nEnter how many columns you want: ");
                answerString = Console.ReadLine();
                numberOfColumns = int.Parse(answerString);
            }
        }

        private int RandomBallDrop(List<Bin> bins, int numberOfBins, int numberOfColumns)
        {
            int beepLength = 50;
            bool finsihed = false;
            int tempRand = 0;
            do
            {
                if (beepLength < 1000)
                {
                    tempRand = RandFancyBinPrint(bins, beepLength, numberOfBins, numberOfColumns);
                    Console.Beep(300, beepLength);
                    beepLength = (int)(beepLength * 1.1);
                }
                else
                {
                    tempRand = RandFancyBinPrint(bins, beepLength, numberOfBins, numberOfColumns);
                    finsihed = true;
                    Console.SetCursorPosition(0, numberOfColumns + 2);
                    Console.Beep();
                    return tempRand;
                }
            } while (!finsihed);
            return tempRand;
        }

        private int RandFancyBinPrint(List<Bin> bins, int beepLength, int numberOfBins, int numberOfColumns)
        {
            Random rand = new Random();
            int tempRand = rand.Next(numberOfBins + 2);
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
            Console.SetCursorPosition(0, numberOfColumns + 2);
            return tempRand;
        }

        private void FancyBinPrint(List<Bin> bins, int numberOfColumns)
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
            Console.SetCursorPosition(0, numberOfColumns + 2);
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