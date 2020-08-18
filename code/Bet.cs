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
                    Console.WriteLine("You won if you bet on Even");
                }
                else
                {
                    Console.WriteLine("You won if you bet on Odd");
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