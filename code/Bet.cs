using System;

namespace Roulette
{
    internal class Bet
    {
        internal static void Numbers(int randomBin)
        {
            if (randomBin == 37)
            {
                Console.WriteLine("You win if you bet on: 00");
            }
            else
            {
                Console.WriteLine($"You win if you bet on: {randomBin}");
            }
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
                if (randomBin < 19)
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
                if (randomBin <= 12)
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
                        Console.WriteLine("You win if you bet on: column 1 (3/6/9/12/15/18/21/24/27/30/33/36)");
                        break;
                    case 1:
                        Console.WriteLine("You win if you bet on: column 3 (1/4/7/10/13/16/19/22/25/28/31/34)");
                        break;
                    case 2:
                        Console.WriteLine("You win if you bet on: column 2 (2/5/8/11/14/17/20/23/26/29/32/35)");
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
                int tempInt = (randomBin - 1) / 3;
                int temp1 = (tempInt * 3) + 1;
                int temp2 = (tempInt * 3) + 2;
                int temp3 = (tempInt * 3) + 3;
                Console.WriteLine($"You win if you bet on: {temp1}/{temp2}/{temp3}");
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
                int tempInt = (randomBin - 1) / 3;
                switch (tempInt)
                {
                    case 0:
                        int temp1 = (tempInt * 3) + 1;
                        int temp2 = (tempInt * 3) + 2;
                        int temp3 = (tempInt * 3) + 3;
                        int temp4 = (tempInt * 3) + 4;
                        int temp5 = (tempInt * 3) + 5;
                        int temp6 = (tempInt * 3) + 6;
                        Console.WriteLine($"You win if you bet on: {temp1}/{temp2}/{temp3}/{temp4}/{temp5}/{temp6}");
                        break;
                    case 11:
                        temp1 = ((tempInt - 1) * 3) + 1;
                        temp2 = ((tempInt - 1) * 3) + 2;
                        temp3 = ((tempInt - 1) * 3) + 3;
                        temp4 = (tempInt * 3) + 1;
                        temp5 = (tempInt * 3) + 2;
                        temp6 = (tempInt * 3) + 3;
                        Console.WriteLine($"You win if you bet on: {temp1}/{temp2}/{temp3}/{temp4}/{temp5}/{temp6}");
                        break;
                    default:
                        temp1 = ((tempInt - 1) * 3) + 1;
                        temp2 = ((tempInt - 1) * 3) + 2;
                        temp3 = ((tempInt - 1) * 3) + 3;
                        temp4 = (tempInt * 3) + 1;
                        temp5 = (tempInt * 3) + 2;
                        temp6 = (tempInt * 3) + 3;
                        Console.WriteLine($"You win if you bet on: {temp1}/{temp2}/{temp3}/{temp4}/{temp5}/{temp6} or {temp4}/{temp5}/{temp6}/{temp4 + 3}/{temp5 + 3}/{temp6 + 3}");
                        break;
                }
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
                int street = (randomBin - 1) / 3;
                int column = (randomBin % 3);
                string n = randomBin + "/" + (randomBin + 1) + " ";
                string s = randomBin + "/" + (randomBin - 1) + " ";
                string e = randomBin + "/" + (randomBin + 3);
                string w = (randomBin - 3) + "/" + randomBin + " ";

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

        internal static void Corner(int randomBin)
        {
            if (randomBin == 0 || randomBin == 37)
            {
                Console.WriteLine("You win nothing on the corner bet");
            }
            else
            {
                int street = (randomBin - 1) / 3;
                int column = (randomBin % 3);
                string nw = (randomBin + 1 - 3) + "/" + (randomBin + 1) + (randomBin - 3) + "/" + randomBin+ " ";
                string ne = (randomBin + 1 - 3) + "/" + (randomBin + 1) + (randomBin - 3) + "/" + randomBin + " ";
                string sw = (randomBin + 1 - 3) + "/" + (randomBin + 1) + (randomBin - 3) + "/" + randomBin + " ";
                string se = (randomBin + 1 - 3) + "/" + (randomBin + 1) + (randomBin - 3) + "/" + randomBin + " ";

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

                /*               randomBin % 3
                                   case 0:(3/6/9/12/15/18/21/24/27/30/33/36)");
                                   case 1:(1/4/7/10/13/16/19/22/25/28/31/34)");
                                   case 2:(2/5/8/11/14/17/20/23/26/29/32/35)");*/
            }
        }
    }
}