﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cSharpTry
{
    class PerlinNoize
    { 
        double persistanсe = 0.5;
        int countOfOctaves = 7;
        int primeIndex = 3;
        int maxPrimeIndex = 10;
        int[,] primes =
        {
            { 995615039, 600173719, 701464987 },
            { 831731269, 162318869, 136250887 },
            { 174329291, 946737083, 245679977 },
            { 362489573, 795918041, 350777237 },
            { 457025711, 880830799, 909678923 },
            { 787070341, 177340217, 593320781 },
            { 405493717, 291031019, 391950901 },
            { 458904767, 676625681, 424452397 },
            { 531736441, 939683957, 810651871 },
            { 997169939, 842027887, 423882827 }
        };

        public PerlinNoize(double per, int oct, int ind)
        {
            persistanсe = per;
            countOfOctaves = oct;
            primeIndex = ind;
        }
        public double GetValue(double x, double y)
        {
            double total = 0,
                frequency = Math.Pow(2, countOfOctaves),
                amplitude = 1;
            for (int i = 0; i < countOfOctaves; i++)
            {
                frequency /= 2;
                amplitude *= persistanсe;
                total += InterpolatedNoise((primeIndex + i) % maxPrimeIndex,
                    x / frequency, y / frequency) * amplitude;
            }
            return total / frequency;
            //return Math.Abs(total / frequency);
        }

        double InterpolatedNoise(int i, double x, double y)
        {
            int intX = (int)x;
            double factX = x - intX;
            int intY = (int)y;
            double factY = y - intY;

            double v1 = SmoothedNoise(i, intX, intY),
                v2 = SmoothedNoise(i, intX + 1, intY),
                v3 = SmoothedNoise(i, intX, intY + 1),
                v4 = SmoothedNoise(i, intX + 1, intY + 1),
                i1 = Interpolate(v1, v2, factX),
                i2 = Interpolate(v3, v4, factX);
            return Interpolate(i1, i2, factY);
        }

        double Interpolate(double a, double b, double x)
        {
            double ft = x * 3.1415927,
                f = (1 - Math.Cos(ft)) * 0.5;
            return a * (1 - f) + b * f;
        }

        double SmoothedNoise(int i, int x, int y)
        {
            double corners = (Noise(i, x - 1, y - 1) + Noise(i, x + 1, y - 1) +
                Noise(i, x - 1, y + 1) + Noise(i, x + 1, y + 1)) / 16,
            sides = (Noise(i, x - 1, y) + Noise(i, x + 1, y) + Noise(i, x, y - 1) +
                Noise(i, x, y + 1)) / 8,
            center = Noise(i, x, y) / 4;
            return corners + sides + center;
        }

        double Noise(int index, int x, int y)
        {
            int n = x + y * 57;
            n = (n << 13) ^ n;
            int a = primes[index, 0];
            int b = primes[index, 1];
            int c = primes[index, 2];
            int t = (n * (n * n * a + b) + c) & 0x7fffffff;
            return 1.0 - (double)(t) / 1073741824.0;
        }

    }
}
