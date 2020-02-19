using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int length;
            int[] numbers;
            Console.WriteLine("Введите количество чисел: ");
            length = int.Parse(Console.ReadLine());
            if (length > 1 && length <=5)
            {
                numbers = new int[length];
                for (int i = 0; i < length; i++)
                {
                    Console.Write($"Введите число {i + 1} : ");
                    numbers[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine($"НОД равен = {GreatestCommonDivisor.SteinsAlgorithm(numbers)}");
            }
            else
            {
                Console.WriteLine("Нужно выбрать от двух до пяти чисел");
            }
            Console.ReadKey();
        }
    }
}
