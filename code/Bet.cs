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

            }
            else
            {

            }
        }

        internal static void RedBlack(Bin chosenBin)
        {
            Console.WriteLine($"You win if you bet on: {chosenBin.color}");
        }

        internal static void LowHigh(int randomBin)
        {
            if (randomBin == 0 || randomBin == 37)
            {

            }
            else
            {

            }
        }

        internal static void Dozens(int randomBin)
        {
            if (randomBin == 0 || randomBin == 37)
            {

            }
            else
            {

            }
        }

        internal static void Columns(int randomBin)
        {
            if (randomBin == 0 || randomBin == 37)
            {

            }
            else
            {

            }
        }

        internal static void Street(int randomBin)
        {
            if (randomBin == 0 || randomBin == 37)
            {

            }
            else
            {

            }
        }

        internal static void SixNumbers(int randomBin)
        {
            if (randomBin == 0 || randomBin == 37)
            {

            }
            else
            {

            }
        }

        internal static void Split(int randomBin)
        {
            if (randomBin == 0 || randomBin == 37)
            {

            }
            else
            {

            }
        }

        internal static void Corner(int randomBin)
        {
            if (randomBin == 0 || randomBin == 37)
            {

            }
            else
            {

            }
        }
    }
}