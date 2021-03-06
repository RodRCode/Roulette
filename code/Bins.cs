﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Roulette
{
    public class Bin
    {
        public string color;
        public string number;
        public int x;
        public int y;

        public Bin(string color = "Purple", string number = "Triple Zero", int x = 0, int y = 0)
        {
            this.color = color;
            this.number = number;
            this.x = x;
            this.y = y;
        }
        public static List<Bin> GenerateBins(int numberOfBins, int numberOfColumns)
        {
            List<Bin> Bins = new List<Bin>();

            var zero = new Bin("Green", " 0", 1, 2);
            var doubleZero = new Bin("Green", "00", 1, 1);

            Bins.Add(zero);
            for (int i = 1; i <= numberOfBins; i++)
            {
                int street = (i - 1) / numberOfColumns;
                var newBin = new Bin();

                if (i < 10)
                {
                    newBin = new Bin("Black", " " + i, street + 2, GetColumn(i, numberOfColumns));

                }
                else
                {
                    newBin = new Bin("Black", "" + i, street + 2, GetColumn(i, numberOfColumns));
                }
                Bins.Add(newBin);
            }

            Bins.Add(doubleZero);

            List<Bin> randomBins = RandomizeColors(Bins, numberOfBins);

            return randomBins;
        }


        private static int GetColumn(int i, int numberOfColumns)
        {
            int modulo = i % numberOfColumns;
            int y = 0;

            if (modulo == 1)
            {
                y = numberOfColumns;
            }
            else if (modulo == 0)
            {
                y = 1;
            }
            else
            {
                y = numberOfColumns - modulo + 1;
            }
            return y;
        }

        private static List<Bin> RandomizeColors(List<Bin> bins, int numberOfBins)
        {
            bool finished = false;
            int i = 0;
            int tempRand = 0;
            Random rand = new Random();
            do
            {
                tempRand = rand.Next(1, numberOfBins);

                if (bins[tempRand].color == "Black")
                {
                    bins[tempRand].color = "Red";
                    i++;
                }
                if (i == numberOfBins / 2)
                {
                    finished = true;
                }

            } while (!finished);

            return bins;
        }
    }
}