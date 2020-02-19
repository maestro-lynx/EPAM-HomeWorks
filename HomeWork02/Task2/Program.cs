using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите неотрицательное число : ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Двоичное представление : {0}",Binary.ToBinaryStandard(number));
            Console.WriteLine("Двоичное представление : {0}",Binary.ToBinaryAlgorithm(number));
            Console.ReadKey();
        }
    }
}
