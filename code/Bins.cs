using System;
using System.Collections.Generic;

namespace Roulette
{
    public class Bin
    {
        public string color;
        public readonly string number;
        public readonly int x;
        public readonly int y;

        public Bin(string color, string number, int x, int y)
        {
            this.color = color;
            this.number = number;
            this.x = x;
            this.y = y;
        }
        public static List<Bin> GenerateBins()
        {
            List<Bin> Bins = new List<Bin>();

            var zero = new Bin("Green", " 0", 1, 2);
            var doubleZero = new Bin("Green", "00", 1, 1);

            var b1 = new Bin("Black", " 1", 2, 3);
            var b2 = new Bin("Black", " 2", 2, 2);
            var b3 = new Bin("Black", " 3", 2, 1);
                                       
            var b4 = new Bin("Black", " 4", 3, 3);
            var b5 = new Bin("Black", " 5", 3, 2);
            var b6 = new Bin("Black", " 6", 3, 1);
                                       
            var b7 = new Bin("Black", " 7", 4, 3);
            var b8 = new Bin("Black", " 8", 4, 2);
            var b9 = new Bin("Black", " 9", 4, 1);
            
            var b10 = new Bin("Black", "10", 5, 3);
            var b11 = new Bin("Black", "11", 5, 2);
            var b12 = new Bin("Black", "12", 5, 1);
                                
            var b13 = new Bin("Black", "13", 6, 3);
            var b14 = new Bin("Black", "14", 6, 2);
            var b15 = new Bin("Black", "15", 6, 1);
                                     
            var b16 = new Bin("Black", "16", 7, 3);
            var b17 = new Bin("Black", "17", 7, 2);
            var b18 = new Bin("Black", "18", 7, 1);
                                       
            var b19 = new Bin("Black", "19", 8, 3);
            var b20 = new Bin("Black", "20", 8, 2);
            var b21 = new Bin("Black", "21", 8, 1);
                               
            var b22 = new Bin("Black", "22", 9, 3);
            var b23 = new Bin("Black", "23", 9, 2);
            var b24 = new Bin("Black", "24", 9, 1);
                                   
            var b25 = new Bin("Black", "25", 10, 3);
            var b26 = new Bin("Black", "26", 10, 2);
            var b27 = new Bin("Black", "27", 10, 1);
                                      
            var b28 = new Bin("Black", "28", 11, 3);
            var b29 = new Bin("Black", "29", 11, 2);
            var b30 = new Bin("Black", "30", 11, 1);
                                   
            var b31 = new Bin("Black", "31", 12, 3);
            var b32 = new Bin("Black", "32", 12, 2);
            var b33 = new Bin("Black", "33", 12, 1);
                                 
            var b34 = new Bin("Black", "34", 13, 3);
            var b35 = new Bin("Black", "35", 13, 2);
            var b36 = new Bin("Black", "36", 13, 1);

            Bins.Add(zero);
            Bins.Add(b1);
            Bins.Add(b2);
            Bins.Add(b3);
            Bins.Add(b4);
            Bins.Add(b5);
            Bins.Add(b6);
            Bins.Add(b7);
            Bins.Add(b8);
            Bins.Add(b9);
            Bins.Add(b10);
            Bins.Add(b11);
            Bins.Add(b12);
            Bins.Add(b13);
            Bins.Add(b14);
            Bins.Add(b15);
            Bins.Add(b16);
            Bins.Add(b17);
            Bins.Add(b18);
            Bins.Add(b19);
            Bins.Add(b20);
            Bins.Add(b21);
            Bins.Add(b22);
            Bins.Add(b23);
            Bins.Add(b24);
            Bins.Add(b25);
            Bins.Add(b26);
            Bins.Add(b27);
            Bins.Add(b28);
            Bins.Add(b29);
            Bins.Add(b30);
            Bins.Add(b31);
            Bins.Add(b32);
            Bins.Add(b33);
            Bins.Add(b34);
            Bins.Add(b35);
            Bins.Add(b36);
            Bins.Add(doubleZero);

            List<Bin> randomBins = RandomizeColors(Bins);

            return randomBins;
        }

        private static List<Bin> RandomizeColors(List<Bin> bins)
        {
            bool finished = false;
            int i = 0;
            int tempRand = 0;
            Random rand = new Random();
            do
            {
                tempRand = rand.Next(1, 36);

                if (bins[tempRand].color == "Black")
                {
                    bins[tempRand].color = "Red";
                    i++;
                }
                if (i == 18)
                {
                    finished = true;
                }

            } while (!finished);

            return bins;
        }
    }
}