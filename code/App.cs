using System;
using System.Collections.Generic;
using System.Dynamic;
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
            //9. Split the edge of any two contiguous numbers 1/2, 11/14, 35/36
            //10. Corners: 1/2/4/5 or 23/24/26/27
            int numberOfBins = 36;
            int numberOfColumns = 3;

            IntroAndOptions(ref numberOfBins, ref numberOfColumns);

            Console.Clear();

            List<Bin> bins = Bin.GenerateBins(numberOfBins, numberOfColumns);
            int randomBin = 0;
            Bin chosenBin = new Bin();

            //        randomBin = 35;
            //        FancyBinPrint(bins,numberOfColumns);
            randomBin = RandomBallDrop(bins, numberOfBins, numberOfColumns);

            chosenBin = bins[randomBin];

            Console.SetCursorPosition(0, (numberOfColumns * 2) + 2);
            Console.WriteLine("The winning bets were:");


            Bet.Numbers(randomBin, numberOfBins);
            Bet.EvenOdd(randomBin, numberOfBins);
            Bet.RedBlack(chosenBin, randomBin, numberOfBins);
            Bet.LowHigh(randomBin, numberOfBins);
            Bet.Dozens(randomBin, numberOfBins);
            Bet.Columns(randomBin, numberOfBins, bins);
            Bet.Street(randomBin, numberOfBins, bins);
            Bet.SixNumbers(randomBin, numberOfBins, bins, numberOfColumns);
            Bet.Split(randomBin, numberOfBins, numberOfColumns);
            Bet.Corner(randomBin, numberOfBins, numberOfColumns);
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

                int width = Console.WindowWidth;
                int height = Console.WindowHeight;

                int maxColumns = height / 2 - 1;
                int maxHorizontalBins = (width - 8) / 4;
                int maxBins = maxHorizontalBins * maxColumns;

                Console.WriteLine($"\n\nBased on the current window size, you can have up to {maxBins} numbers on the board and {maxColumns} columns");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\nBut, that's OK, you do you.");
                Console.ResetColor();

                bool goodNumber = false;
                do
                {
                    GetNumbersAndColumns(out numberOfBins, out numberOfColumns, out answerString, maxColumns, maxBins);
                    if (numberOfBins > (maxHorizontalBins * numberOfColumns))
                    {
                        Console.WriteLine("That arrangement exceeds the bounds of the screen.  Please try again.");
                        Console.WriteLine($"\n\nBased on the current window size, you can have up to {maxBins} numbers on the board and {maxColumns} columns");
                    }
                    else
                    {
                        goodNumber = true;
                    }
                } while (!goodNumber);
            }
        }

        private static void GetNumbersAndColumns(out int numberOfBins, out int numberOfColumns, out string answerString, int maxColumns, int maxBins)
        {
            bool goodNumber = false;
            do
            {
                Console.Write("\n\nEnter how many numbers you want on the Roulette Table then hit enter: ");
                answerString = Console.ReadLine();
                numberOfBins = int.Parse(answerString);
                if (numberOfBins > maxBins)
                {
                    Console.WriteLine("That is too many numbers.");
                    Console.WriteLine($"\n\nBased on the current window size, you can have up to {maxBins} numbers on the board and {maxColumns} columns");
                    Console.WriteLine("Please try again.");
                }
                else
                {
                    goodNumber = true;
                }
            } while (!goodNumber);

            goodNumber = false;
            do
            {
                Console.Write("\nEnter how many columns you want: ");
                answerString = Console.ReadLine();
                numberOfColumns = int.Parse(answerString);
                if (numberOfColumns > maxColumns)
                {
                    Console.WriteLine("That is too many columns.");
                    Console.WriteLine($"\n\nBased on the current window size, you can have up to {maxBins} numbers on the board and {maxColumns} columns");
                    Console.WriteLine("Please try again.");
                }
                else
                {
                    goodNumber = true;
                }
            } while (!goodNumber);
        }

        private int RandomBallDrop(List<Bin> bins, int numberOfBins, int numberOfColumns)
        {
            int beepLength = 50;
            bool finsihed = false;
            int tempRand = 0;
            int lastRand = 0;
            var lastBin = bins[0];
            var randBin = bins[0];

            Console.CursorVisible = false;
            FancyBinPrint(bins, numberOfColumns);
            do
            {
                Random rand = new Random();
                lastRand = tempRand;
                lastBin = bins[lastRand];

                tempRand = rand.Next(numberOfBins + 2);
                randBin = bins[tempRand];

                if (beepLength < 1000)
                {
                    PrintLastBin(lastBin);
                    PrintRandBin(randBin);
                    try
                    {
                        Console.Beep(300, beepLength);
                    }
                    catch (Exception ex)
                    {
                        Thread.Sleep(beepLength);
                    }
                    beepLength = (int)(beepLength * 1.1);
                    Console.SetCursorPosition(0, numberOfColumns + 2);
                }
                else
                {
                    PrintLastBin(lastBin);
                    PrintRandBin(randBin);
                    finsihed = true;
                    Console.SetCursorPosition(0, numberOfColumns + 2);
                    try
                    {
                        Console.Beep();
                    }
                    catch (Exception ex)
                    {
                    }

                    return tempRand;
                }
            } while (!finsihed);
            Console.CursorVisible = true;
            return tempRand;
        }

        private void PrintRandBin(Bin bin)
        {

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.SetCursorPosition(bin.x * 4, bin.y * 2);
            Console.Write(bin.number);
            Console.ResetColor();
        }

        private void PrintLastBin(Bin bin)
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