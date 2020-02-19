using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            double number;
            int power;

            Console.Write("Введите число: ");
            number = double.Parse(Console.ReadLine());
            Console.Write("Введите степень корня: ");
            power = int.Parse(Console.ReadLine());
            Root.Comparision(number, power);
            Console.ReadKey();


        }
    }
}
