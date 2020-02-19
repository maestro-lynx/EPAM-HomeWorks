using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class GreatestCommonDivisor
    {
        public static int SteinsAlgorithm(params int[] numbers)
        {
            int a=numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                while (a != 0 && numbers[i] != 0)
                {
                    if (a > numbers[i])
                    {
                        a %= numbers[i];
                    }
                    else
                    {
                        numbers[i] %= a;
                    }                                      
                }
                a = (a == 0) ? numbers[i] : a;
            }
            return a;
        }
        public static int SteinsAlgorithm(int a,int b)
        {
            if (a == b)
                return a;

            if (a == 0)
                return b;

            if (b == 0)
                return a;

            if (a%2==0)
            {
                if (b % 2 != 0)
                {
                    return SteinsAlgorithm(a >> 1, b);
                }   
                else
                {
                    return SteinsAlgorithm(a >> 1, b >> 1) << 1;
                }
                    
            }
            if (a % 2 != 0&& b % 2 == 0)
            {
                return SteinsAlgorithm(a, b >> 1);
            }
            if (a > b)
            {
                return SteinsAlgorithm((a - b) >> 1, b);
            }

            return SteinsAlgorithm((b - a) >> 1, a);
        }
        public static int SteinsAlgorithm(int a, int b, int c)
        {
            return SteinsAlgorithm(a, SteinsAlgorithm(b, c));
        }
        public static int SteinsAlgorithm(int a, int b, int c, int d)
        {
            return SteinsAlgorithm(a, SteinsAlgorithm(b, c, d));
        }
        public static int SteinsAlgorithm(int a, int b, int c, int d, int e)
        {
            return SteinsAlgorithm(a, SteinsAlgorithm(b, c, d, e));
        }
    }
}
