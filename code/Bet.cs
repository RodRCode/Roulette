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