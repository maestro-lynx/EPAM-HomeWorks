using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Binary
    {
        /// <summary>
        /// Преобразование десятичного числа на двоичный (Стандартный метод)
        /// </summary>
        /// <param name="number">Десятичное число</param>
        /// <returns>Двоичное представление десятичного числа</returns>
        public static string ToBinaryStandard(int number)
        {
            try
            {
                if (number > 0)//проверка на неотрицательность
                {
                    return Convert.ToString(number, 2);
                }
                else
                {
                    throw new Exception("Неотрицательное число!");
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        /// <summary>
        /// Преобразование десятичного числа на двоичный (Свой метод)
        /// </summary>
        /// <param name="number">Десятичное число</param>
        /// <returns>Двоичное представление десятичного числа</returns>
        public static string ToBinaryAlgorithm(int number)
        {
            string binary=String.Empty;
            try
            {
                if (number > 0)
                {
                    while (number != 0)
                    {
                        binary += (number % 2 == 1) ? "1" : "0";
                        number /= 2;
                    }
                    return new string(binary.ToCharArray().Reverse().ToArray()); ;
                }
                else
                {
                    throw new Exception("Неотрицательное число!");
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
