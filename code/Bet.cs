using System;
using System.Collections.Generic;

namespace Roulette
{
    internal class Bet
    {
        internal static void Numbers(int randomBin, int numberOfBins)
        {
            if (randomBin == numberOfBins + 1)
            {
                Console.WriteLine("You win if you bet on: 00");
            }
            else
            {
                Console.WriteLine($"You win if you bet on: {randomBin}");
            }
        }

        internal static void EvenOdd(int randomBin, int numberOfBins)
        {
            if (randomBin == 0 || randomBin == numberOfBins + 1)
            {
                Console.WriteLine("You win nothing on the even/odd bet");
            }
            else
            {
                if ((randomBin % 2) == 0)
                {
                    Console.WriteLine("You win if you bet on: Even");
                }
                else
                {
                    Console.WriteLine("You win if you bet on: Odd");
                }
            }
        }

        internal static void RedBlack(Bin chosenBin, int randomBin, int numberOfBins)
        {
            if (randomBin == 0 || randomBin == numberOfBins + 1)
            {
                Console.WriteLine("You win nothing on the Red/Black bet");
            }
            else
            {
                Console.WriteLine($"You win if you bet on: {chosenBin.color}");
            }
        }

        internal static void LowHigh(int randomBin, int numberOfBins)
        {
            if (randomBin == 0 || randomBin == numberOfBins + 1)
            {
                Console.WriteLine("You win nothing on the low/high bet");
            }
            else
            {
                if (randomBin < (numberOfBins / 2))
                {
                    Console.WriteLine("You win if you bet on: Low");
                }
                else
                {
                    Console.WriteLine("You win if you bet on: High");

                }
            }
        }

        internal static void Dozens(int randomBin, int numberOfBins)
        {
            if (randomBin == 0 || randomBin == numberOfBins + 1)
            {
                Console.WriteLine("You win nothing on the dozens bet");
            }
            else
            {
                int dozens = (randomBin / 12);

                Console.WriteLine($"You win if you bet on: {dozens*12+1}-{(dozens+1)*12}");
            }
        }

        internal static void Columns(int randomBin, int numberOfBins, List<Bin> bins)
        {
            if (randomBin == 0 || randomBin == numberOfBins + 1)
            {
                Console.WriteLine("You win nothing on the columns bet");
            }
            else
            {
                int column = bins[randomBin].y;
                Console.Write($"You win if you bet on: column {column} (");
                foreach (var bin in bins)
                {
                    if (bin.number == "00" || bin.number == " 0")
                    {

                    }
                    else
                    {
                        if (bin.y == column)
                            Console.Write(bin.number + " ");
                    }
                }
                Console.WriteLine(")");
            }
        }

        internal static void Street(int randomBin, int numberOfBins, int numberOfColumns)
        {
            if (randomBin == 0 || randomBin == numberOfBins + 1)
            {
                Console.WriteLine("You win nothing on the streets bet");
            }
            else
            {
                int tempInt = (randomBin - 1) / numberOfColumns;
                int temp1 = (tempInt * numberOfColumns) + numberOfColumns - 2;
                int temp2 = (tempInt * numberOfColumns) + numberOfColumns - 1;
                int temp3 = (tempInt * numberOfColumns) + numberOfColumns;
                Console.WriteLine($"You win if you bet on: {temp1}/{temp2}/{temp3}");
            }
        }

        internal static void SixNumbers(int randomBin, int numberOfBins, int numberOfColumns)
        {
            if (randomBin == 0 || randomBin == numberOfBins + 1)
            {
                Console.WriteLine("You win nothing on the six number bet");
            }
            else
            {
                int tempInt = (randomBin - 1) / numberOfColumns;
                switch (tempInt)
                {
                    case 0:
                        int temp1 = (tempInt * numberOfColumns) + 1;
                        int temp2 = (tempInt * numberOfColumns) + 2;
                        int temp3 = (tempInt * numberOfColumns) + 3;
                        int temp4 = (tempInt * numberOfColumns) + 4;
                        int temp5 = (tempInt * numberOfColumns) + 5;
                        int temp6 = (tempInt * numberOfColumns) + 6;
                        Console.WriteLine($"You win if you bet on: {temp1}/{temp2}/{temp3}/{temp4}/{temp5}/{temp6}");
                        break;
                    case 11:
                        temp1 = ((tempInt - 1) * numberOfColumns) + 1;
                        temp2 = ((tempInt - 1) * numberOfColumns) + 2;
                        temp3 = ((tempInt - 1) * numberOfColumns) + 3;
                        temp4 = (tempInt * numberOfColumns) + 1;
                        temp5 = (tempInt * numberOfColumns) + 2;
                        temp6 = (tempInt * numberOfColumns) + 3;
                        Console.WriteLine($"You win if you bet on: {temp1}/{temp2}/{temp3}/{temp4}/{temp5}/{temp6}");
                        break;
                    default:
                        temp1 = ((tempInt - 1) * numberOfColumns) + 1;
                        temp2 = ((tempInt - 1) * numberOfColumns) + 2;
                        temp3 = ((tempInt - 1) * numberOfColumns) + 3;
                        temp4 = (tempInt * numberOfColumns) + 1;
                        temp5 = (tempInt * numberOfColumns) + 2;
                        temp6 = (tempInt * numberOfColumns) + 3;
                        Console.WriteLine($"You win if you bet on: {temp1}/{temp2}/{temp3}/{temp4}/{temp5}/{temp6} or {temp4}/{temp5}/{temp6}/{temp4 + numberOfColumns}/{temp5 + numberOfColumns}/{temp6 + numberOfColumns}");
                        break;
                }
            }
        }

        internal static void Split(int randomBin, int numberOfBins, int numberOfColumns)
        {
            if (randomBin == 0 || randomBin == numberOfBins + 1)
            {
                Console.WriteLine("You win nothing on the split bet");
            }
            else
            {
                int street = (randomBin - 1) / numberOfColumns;
                int column = (randomBin % numberOfColumns);
                string n = randomBin + "/" + (randomBin + 1) + " ";
                string s = randomBin + "/" + (randomBin - 1) + " ";
                string e = randomBin + "/" + (randomBin + numberOfColumns);
                string w = (randomBin - numberOfColumns) + "/" + randomBin + " ";

                switch (street)
                {
                    case 0:
                        w = "";
                        break;
                    case 11:
                        e = "";
                        break;
                    default:
                        break;
                }
                switch (column)
                {
                    case 0:
                        n = "";
                        break;
                    case 1:
                        s = "";
                        break;
                    default:
                        break;
                }

                Console.WriteLine($"You win if you bet on: {w}{n}{s}{e}");
            }
        }

        internal static void Corner(int randomBin, int numberOfBins, int numberOfColumns)
        {
            if (randomBin == 0 || randomBin == numberOfBins + 1)
            {
                Console.WriteLine("You win nothing on the corner bet");
            }
            else
            {
                int street = (randomBin - 1) / numberOfColumns;
                int column = (randomBin % numberOfColumns);
                string nw = (randomBin + 1 - numberOfColumns) + "/" + (randomBin + 1) + "/" + (randomBin - numberOfColumns) + "/" + randomBin + " ";
                string ne = (randomBin + 1) + "/" + (randomBin + 1 + numberOfColumns) + "/" + randomBin + "/" + (randomBin + numberOfColumns) + " ";
                string sw = (randomBin - numberOfColumns) + "/" + randomBin + "/" + (randomBin - numberOfColumns - 1) + "/" + (randomBin - 1) + " ";
                string se = randomBin + "/" + (randomBin + numberOfColumns) + "/" + (randomBin - 1) + "/" + (randomBin - 1 + numberOfColumns) + " ";

                switch (street)
                {
                    case 0:
                        nw = "";
                        sw = "";
                        break;
                    case 11:
                        ne = "";
                        se = "";
                        break;
                    default:
                        break;
                }
                switch (column)
                {
                    case 0:
                        nw = "";
                        ne = "";
                        break;
                    case 1:
                        sw = "";
                        se = "";
                        break;
                    default:
                        break;
                }

                Console.WriteLine($"You win if you bet on: {nw}{ne}{sw}{se}");
            }
        }
    }
}