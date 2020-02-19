using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Root
    {
        /// <summary>
        /// Нахождение корня (Стандартый метод)
        /// </summary>
        /// <param name="number">Число</param>
        /// <param name="power">Степень</param>
        /// <returns>Корень числа</returns>
        public static double StandardMethod(double number,int power)=> Math.Pow(number,(double) 1 / power);
        /// <summary>
        /// Нахождение корня (Метод Ньютона)
        /// </summary>
        /// <param name="number">Число</param>
        /// <param name="power">Степень</param>
        /// <returns>Корень числа</returns>
        public static double NewtonsMethod(double number, int power)
        {
            double eps = 0.0000000000000000000001;//допустимая погрешность
            double root = number / power;         //начальное приближение корня
            double rn = number;                   //значение корня последовательным делением
            int iter = 0;                         //число итераций
            while (Math.Abs(root - rn) >= eps)
            {
                rn = number;
                for (int i = 1; i < power; i++)
                {
                    rn /= root;
                }
                root = 0.5 * (rn + root);
                iter++;
            }
            return root;
        }
        /// <summary>
        /// Сравнение двух методов нахождение корня
        /// </summary>
        /// <param name="number"></param>
        /// <param name="power"></param>
        public static void Comparision(double number,int power)
        {
            Console.WriteLine($"Стандартный метод (через Math.Pow) : {StandardMethod(number, power)}");
            Console.WriteLine($"Метод Ньютона : {NewtonsMethod(number, power)}");

        }
    }
}
