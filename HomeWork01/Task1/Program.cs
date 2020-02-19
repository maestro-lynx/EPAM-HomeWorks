using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            int choice=-1;
            while (choice != 0)
            {
                Console.WriteLine("Выберите способ ввода: 1. Ручной. 2. Обзор файла. 0. Выйти");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Coordinates.Manual();
                        break;
                    case 2:
                        Coordinates.FromTxtFile();
                        break;
                    default:
                        Console.WriteLine("Неправильный ввод. Попробуйте ещераз");
                        break;

                }
            }         
        }

    }
}
