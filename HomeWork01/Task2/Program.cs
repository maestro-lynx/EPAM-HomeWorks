using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            #region Инициализация базовых элементов
            int choice = -1;//Переменная для использования в switch, -1 чтобы вошел в цикл
            int operationType = -1;//Переменная для выбора типа операции, -1 чтобы вошел в цикл
            bool matrix1HasValues = false;//Проверка что первая матрица имеет значения
            bool matrix2HasValues = false;//Проверка что вторая матрица имеет значения
            Matrix matr1 = new Matrix();//Инициализация первой матрицы
            Matrix matr2 = new Matrix();//Инициализация второй матрицы
            Matrix result = new Matrix();//Инициализация для хранения результата операции над матриц-ей(ами)
            #endregion
            #region Выбор операции
            while (operationType == -1)//цикл идет пока не сделан выбор
            {
                Console.WriteLine("Выберите операцию: 1. Операции над одной матрицей 2. Операции над двумя матрицами. 0. Выйти");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        operationType = 1;
                        break;
                    case 2:
                        operationType = 2;
                        break;
                    case 0:
                        Environment.Exit(0);//выход из программы
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор. Попробуйте еще раз");
                        break;
                }
            }
            #endregion
            #region Ввод матрицы 1
            while (!matrix1HasValues)//цикл идет пока первая матрица не будет заполнено
            {
                Console.WriteLine("Ввод матрицы 1:");
                Console.WriteLine("1. Ввод вручную. 2. Случайное генерация. 3. Из текстого файла 0. Выйти");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Введите количество строк: ");
                        int rows = int.Parse(Console.ReadLine());
                        Console.Write("Введите количество столбцов: ");
                        int columns = int.Parse(Console.ReadLine());
                        matr1 = new Matrix(rows, columns);
                        matr1.Read();
                        matr1.Write();
                        matrix1HasValues = true;
                        break;
                    case 2:
                        Console.Write("Введите количество строк: ");
                        int rows1 = int.Parse(Console.ReadLine());
                        Console.Write("Введите количество столбцов: ");
                        int columns1 = int.Parse(Console.ReadLine());
                        matr1 = new Matrix(rows1, columns1);
                        matr1.GenerateRandomValues();
                        matr1.Write();
                        matrix1HasValues = true;
                        break;
                    case 3:
                        if (Matrix.TryReadFromFile(out matr1))
                        {
                            matrix1HasValues = true;
                        }
                        else
                        {
                            matrix1HasValues = false;
                        }
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор. Попробуйте еще раз");
                        break;
                }
            }

            #endregion
            #region Ввод матрицы 2
            if (operationType == 2)//Для операции с двумя матрицами нужны обе матрицы!
            {
                while (!matrix2HasValues) //цикл идет пока вторая матрица не будет заполнено
                {
                    Console.WriteLine("Ввод матрицы 2:");
                    Console.WriteLine("1. Ввод вручную. 2. Случайное генерация. 3. Из текстого файла. 0. Выйти ");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Введите количество строк: ");
                            int rows = int.Parse(Console.ReadLine());
                            Console.Write("Введите количество столбцов: ");
                            int columns = int.Parse(Console.ReadLine());
                            matr2 = new Matrix(rows, columns);
                            matr2.Read();
                            matr2.Write();
                            matrix2HasValues = true;
                            break;
                        case 2:
                            Console.Write("Введите количество строк: ");
                            int rows1 = int.Parse(Console.ReadLine());
                            Console.Write("Введите количество столбцов: ");
                            int columns1 = int.Parse(Console.ReadLine());
                            matr2 = new Matrix(rows1, columns1);
                            matr2.GenerateRandomValues();
                            matr2.Write();
                            matrix2HasValues = true;
                            break;
                        case 3:
                            if (Matrix.TryReadFromFile(out matr2))
                            {
                                matrix2HasValues = true;
                            }
                            else
                            {
                                matrix2HasValues = false;
                            }
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Неправильный выбор. Попробуйте еще раз");
                            break;
                    }
                }

            }
            #endregion
            #region Операции над одной матрицей
            if (operationType == 1)//тип операции
            {
                while (choice != 0)//цикл идет пока не сделан выбор
                {
                    Console.WriteLine("Операции над одной матрицей: 1. Противоположность. 2. Сумма положительных элементов.\n" +
                        "3. Список положительных элементов. 4. Список четных элементов. 5. Список простых элементов. 0. Выйти");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Противоположность матрицы: ");
                            result = -matr1;
                            result.Write();
                            break;
                        case 2:
                            Matrix.SumOfPositiveNumbers(matr1);
                            break;
                        case 3:
                            Matrix.PositiveNumbers(matr1);
                            break;
                        case 4:
                            Matrix.EvenNumbers(matr1);
                            break;
                        case 5:
                            Matrix.PrimeNumbers(matr1);
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Неправильный выбор. Попробуйте еще раз");
                            break;
                    }
                }
            }
            #endregion
            #region Операции над двумя матрицами
            if (operationType == 2)//тип операции
            {
                while (choice != 0)//цикл идет пока не сделан выбор
                {
                    Console.WriteLine("Операции над двумя матрицами: 1. Сложить две матрицы. 2. Вычитание матриц 3.Умножить две матрицы \n" +
                        "4. Сохранить результат в файл. 0. Выйти");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Сложение матриц 1 и 2: ");
                            result = matr1 + matr2;
                            result.Write();
                            break;
                        case 2:
                            Console.WriteLine("Вычитание матриц 1 и 2: ");
                            result = matr1 - matr2;
                            result.Write();
                            break;
                        case 3:
                            Console.WriteLine("Умножение матриц 1 и 2: ");
                            result = matr1 * matr2;
                            result.Write();
                            break;
                        case 4:
                            result.SaveToFile();
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Неправильный выбор. Попробуйте еще раз");
                            break;
                    }
                }
            }
            #endregion
        }
    }
}
