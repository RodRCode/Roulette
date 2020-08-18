using System;

namespace Roulette
{
    internal class Bet
    {
        internal static void Numbers(int randomBin)
        {
            Console.WriteLine($"You win if you bet on: {randomBin}");
        }

        internal static void EvenOdd(int randomBin)
        {
            if (randomBin == 0 || randomBin == 37)
            {
                Console.WriteLine("You win nothing on the even/odd bet");
            }
            else
            {
                if ((randomBin % 2) == 0)
                {
                    Console.WriteLine("You won if you bet on: Even");
                }
                else
                {
                    Console.WriteLine("You won if you bet on: Odd");
                }
            }
        }

        internal static void RedBlack(Bin chosenBin, int randomBin)
        {
            if (randomBin == 0 || randomBin == 37)
            {
                Console.WriteLine("You win nothing on the Red/Black bet");
            }
            else
            {
            Console.WriteLine($"You win if you bet on: {chosenBin.color}");
            }
        }

        internal static void LowHigh(int randomBin)
        {
            if (randomBin == 0 || randomBin == 37)
            {
                Console.WriteLine("You win nothing on the low/high bet");
            }
            else
            {
                if (randomBin <19)
                {
                    Console.WriteLine("You win if you bet on: Low");
                }
                else
                {
                    Console.WriteLine("You win if you bet on: High");

                }
            }
        }

        internal static void Dozens(int randomBin)
        {
            if (randomBin == 0 || randomBin == 37)
            {
                Console.WriteLine("You win nothing on the dozens bet");
            }
            else
            {
                if(randomBin<= 12)
                {
                    Console.WriteLine("You win if you bet on: 1-12");
                }
                else if (randomBin >= 25)
                {
                    Console.WriteLine("You win if you bet on: 25-36");
                }
                else
                {
                    Console.WriteLine("You win if you bet on: 13-24");
                }
            }
        }

        internal static void Columns(int randomBin)
        {
            if (randomBin == 0 || randomBin == 37)
            {
                Console.WriteLine("You win nothing on the columns bet");
            }
            else
            {
                switch (randomBin % 3)
                {
                    case 0:
                        Console.WriteLine("You win if you bet on column 1 (3/6/9/12/15/18/21/24/27/30/33/36)");
                        break;
                    case 1:
                        Console.WriteLine("You win if you bet on column 3 (1/4/7/10/13/16/19/22/25/28/31/34)");
                        break;
                    case 2:
                        Console.WriteLine("You win if you bet on column 2 (2/5/8/11/14/17/20/23/26/29/32/35)");
                        break;
                    default:
                        break;
                }
            }
        }

        internal static void Street(int randomBin)
        {
            if (randomBin == 0 || randomBin == 37)
            {
                Console.WriteLine("You win nothing on the streets bet");
            }
            else
            {

            }
        }

        internal static void SixNumbers(int randomBin)
        {
            if (randomBin == 0 || randomBin == 37)
            {
                Console.WriteLine("You win nothing on the six number bet");
            }
            else
            {

            }
        }

        internal static void Split(int randomBin)
        {
            if (randomBin == 0 || randomBin == 37)
            {
                Console.WriteLine("You win nothing on the split bet");
            }
            else
            {

            }
        }

        internal static void Corner(int randomBin)
        {
            if (randomBin == 0 || randomBin == 37)
            {
                Console.WriteLine("You win nothing on the corner bet");
            }
            else
            {

            }
        }
    }
}