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

                Console.WriteLine($"You win if you bet on: {dozens * 12 + 1}-{(dozens + 1) * 12}");
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

        internal static void Street(int randomBin, int numberOfBins, List<Bin> bins)
        {
            if (randomBin == 0 || randomBin == numberOfBins + 1)
            {
                Console.WriteLine("You win nothing on the streets bet");
            }
            else
            {

                int street = bins[randomBin].x;

                Console.Write($"You win if you bet on: street {street - 1} (");
                StreetPrint(bins, street);
                Console.WriteLine(")");
            }
        }

        private static void StreetPrint(List<Bin> bins, int street)
        {
            foreach (var bin in bins)
            {
                if (bin.number == "00" || bin.number == " 0")
                {

                }
                else
                {
                    if (bin.x == street)
                        Console.Write(bin.number + " ");
                }
            }
        }

        internal static void SixNumbers(int randomBin, int numberOfBins, List<Bin> bins, int numberOfColumns)
        {
            int maxNumberOfStreets = numberOfBins / numberOfColumns;
            if (randomBin == 0 || randomBin == numberOfBins + 1)
            {
                Console.WriteLine("You win nothing on the six number bet");
            }
            else
            {
                int street = bins[randomBin].x;

                if (street == 2)
                {
                    Console.Write($"You win if you bet on: streets {street - 1 } & {street} (");
                    StreetPrint(bins, street);
                    Console.Write("/ ");
                    street++;
                    StreetPrint(bins, street);
                    Console.WriteLine($")");
                }
                else if (street == maxNumberOfStreets + 1)
                {
                    street--;
                    Console.Write($"You win if you bet on: streets {street - 1 } & {street} (");
                    StreetPrint(bins, street);
                    Console.Write("/ ");
                    street++;
                    StreetPrint(bins, street);
                    Console.WriteLine($")");
                }
                else
                {
                    street--;
                    Console.Write($"You win if you bet on: streets {street - 1} & {street} (");
                    StreetPrint(bins, street);
                    Console.Write("/ ");
                    street++;
                    StreetPrint(bins, street);
                    Console.Write($") or streets {street - 1} & {street} (");
                    StreetPrint(bins, street);
                    Console.Write("/ ");
                    street++;
                    StreetPrint(bins, street);
                    Console.WriteLine(")");
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

                if (street == 0)
                {
                    w = "";
                }
                if (street == numberOfColumns - 1)
                {
                    e = "";
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

                if ((randomBin + numberOfColumns) > numberOfBins)
                {
                    e = "";
                }

                if ((randomBin + 1) > numberOfBins)
                {
                    n = "";
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
                int ?boundry1 = randomBin + 1;
                int ?boundry2 = boundry1 + numberOfColumns;
                int ?boundry3 = randomBin + numberOfColumns;
                int ?boundry4 = randomBin - 1 + numberOfColumns;
                if (boundry1 > numberOfBins)
                {
                    boundry1 = null;
                }
                if (boundry2 > numberOfBins)
                {
                    boundry2 = null;
                }
                if (boundry3 > numberOfBins)
                {
                    boundry3 = null;
                }
                int street = (randomBin - 1) / numberOfColumns;
                int column = (randomBin % numberOfColumns);
                string nw = (randomBin + 1 - numberOfColumns) + "/" + boundry1 + "/" + (randomBin - numberOfColumns) + "/" + randomBin + " ";
                string ne = boundry1 + "/" + boundry2 + "/" + randomBin + "/" + boundry3 + " ";
                string sw = (randomBin - numberOfColumns) + "/" + randomBin + "/" + (randomBin - numberOfColumns - 1) + "/" + (randomBin - 1) + " ";
                string se = randomBin + "/" + boundry3 + "/" + (randomBin - 1) + "/" + boundry4 + " ";

                switch (street)
                {
                    case 0:
                        nw = "";
                        sw = "";
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