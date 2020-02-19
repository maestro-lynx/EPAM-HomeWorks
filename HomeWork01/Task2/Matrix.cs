using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Task2
{
    class Matrix
    {
        #region Конструторы и инициализация необходимых элементов
        private int[,] matr;
        private int rows; //строки 
        private int columns; //столбцы
        public int Rows
        {
            get { return rows; }
            set { if (value > 0) rows = value; } //принимать только положительное число
        }
        public int Columns
        {
            get { return columns; }
            set { if (value > 0) columns = value; } //принимать только положительное число
        }
        /// <summary>
        /// Конструкторы матрицы
        /// </summary>
        public Matrix() { }
        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            matr = new int[this.rows, this.columns]; //выделение памяти для матрицы
        }
        /// <summary>
        /// Аксессор матрицы
        /// </summary>
        public int this[int i, int j]
        {
            get
            {
                return matr[i, j];
            }
            set
            {
                matr[i, j] = value;
            }
        }
        #endregion
        #region Методы ввода и вывода матрицы
        /// <summary>
        /// Ввод матрицы случайными значениями
        /// </summary>
        public void GenerateRandomValues()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matr[i, j] = new Random(Guid.NewGuid().GetHashCode()).Next(-10, 10);//Случайное число от -10 до 10
                }
            }
        }
        /// <summary>
        /// Ввод матрицы вручную
        /// </summary>
        public void Read()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"matrix[{i + 1}][{j + 1}] = ");
                    try
                    {
                        matr[i, j] = int.Parse(Console.ReadLine()); //пытаемся спарсить
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Некорректные данные попробуйте еще раз"); //выводим исключение
                        --j;//пытаемся еще раз
                    }

                }
            }
        }
        /// <summary>
        /// Попытаться прочитать файл
        /// </summary>
        /// <returns>Результать прочтение файла</returns>
        [STAThread]
        public static bool TryReadFromFile(out Matrix matrix)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    string[] text = File.ReadAllLines(filename);
                    string[] splittedText = text[0].Trim(' ').Split(' ');//Чтобы узнать количество столбцов
                    matrix = new Matrix(text.Length, splittedText.Length);
                    for (int i = 0; i < matrix.Rows; i++)
                    {
                        splittedText = text[i].Split(' ');
                        for (int j = 0; j < matrix.Columns; j++)
                        {

                            try
                            {
                                matrix[i, j] = int.Parse(splittedText[j]); //пытаемся спарсить
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Некорректные данные попробуйте еще раз"); //выводим исключение
                                return false;
                            }

                        }
                    }
                    Console.WriteLine("Получено успешно\nПолученная матрица");
                    matrix.Write();
                    return true;
                }
                matrix = new Matrix();
                return false;
            }
            finally
            {
                openFileDialog.Dispose();
            }
        }
        [STAThread]
        public void SaveToFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";//только текстовые файлы
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // получаем выбранный файл
                    string filename = saveFileDialog.FileName;
                    // сохраняем текст в файл
                    File.WriteAllText(filename, ToString());
                    MessageBox.Show("Файл сохранен");
                }
            }
            finally
            {
                saveFileDialog.Dispose(); //финализатор
            }

        }
        /// <summary>
        /// Вывод матрицы на консоль
        /// </summary>
        public void Write()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(this[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Переопределение метода ToString
        /// </summary>
        /// <returns>Вывод матрицы на строку</returns>
        public override string ToString()
        {
            string toString = String.Empty;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    toString += String.Format(matr[i, j] + " ");
                }
                toString += String.Format("\n");
            }
            return toString;
        }
        #endregion
        #region Методы для работы с одной матрицей
        /// <summary>
        /// Вывод суммы всех положительных элементов матрицы
        /// </summary>
        /// <param name="a">Матрица 1</param>
        public static void SumOfPositiveNumbers(Matrix a)
        {
            int sum = 0;
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    if (a[i, j] > 0)
                    {
                        sum += a[i, j];
                    }
                }
            }
            Console.WriteLine($"Сумма положительных элементов матрицы: {sum}");
        }
        /// <summary>
        /// Вывод положительных элементов матрицы
        /// </summary>
        /// <param name="a">Матрица</param>
        public static void PositiveNumbers(Matrix a)
        {
            Console.WriteLine("Положительные элементы матрицы:");
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    if (a[i, j] > 0)
                    {
                        Console.Write($"{a[i, j]}\t");
                    }
                }
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Вывод четных элементов матрицы
        /// </summary>
        /// <param name="a">Матрица</param>
        public static void EvenNumbers(Matrix a)
        {
            Console.WriteLine("Четные элементы матрицы:");
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    if (a[i, j] % 2 == 0)
                    {
                        Console.Write($"{a[i, j]}\t");
                    }
                }
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Вывод простых элементов матрицы
        /// </summary>
        /// <param name="a">Матрица</param>
        public static void PrimeNumbers(Matrix a)
        {
            Console.WriteLine("Простые элементы матрицы:");
            bool isPrime; ;//проверяем простое ли число
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    isPrime = true;
                    if (a[i, j] > 1)
                    {
                        for (int k = 2; k < a[i, j]; k++)// в цикле перебираем числа от 2 до a[i, j] - 1
                        {
                            if (a[i, j] % k == 0) // если число делится без остатка на k - возвращаем false (число не простое)
                            {
                                isPrime = false;//число не простое
                                break;//так как число не простое выходим из цикла
                            }
                        }
                        // если программа дошла до данного оператора, то выводим число (число простое) - проверка пройдена
                        if (isPrime)
                        {
                            Console.WriteLine($"{a[i, j]}\t");
                        }
                    }
                }
            }
            Console.WriteLine();
        }
        #endregion
        #region Перегрузки операторов
        /// <summary>
        /// Перегрузка оператора +
        /// </summary>
        /// <param name="a">Матрица 1</param>
        /// /// <param name="b">Матрица 2</param>
        /// <returns>Сложение двух матриц</returns>
        public static Matrix operator +(Matrix a, Matrix b)
        {
            try
            {
                if (a.Rows != b.Rows || a.Columns != b.Columns)
                {
                    throw new Exception("Число строк и столбцов обоих матриц должны быть равными ");
                }
                Matrix result = new Matrix(a.Rows, a.Columns);
                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < a.Columns; j++)
                    {
                        result[i, j] = a[i, j] + b[i, j];
                    }
                }
                return result;
            }
            catch (Exception)
            {

                Console.WriteLine("Число строк и столбцов обоих матриц должны быть равными ");
                return new Matrix();
            }
        }
        /// <summary>
        /// Перегрузка оператора -
        /// </summary>
        /// <param name="a">Матрица 1</param>
        /// /// <param name="b">Матрица 2</param>
        /// <returns>Вычитание двух матриц</returns>
        public static Matrix operator -(Matrix a, Matrix b) => a + (-b);// a + (-b) = a - b
        /// <summary>
        /// Перегрузка унарного оператора -
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <returns>Противоположная матрица</returns>
        public static Matrix operator -(Matrix matrix) => matrix * -1;// a*-1=-a
        /// <summary>
        /// Перегрузка оператора *
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// /// <param name="number">Число</param>
        /// <returns>Произведение двух матриц</returns>
        public static Matrix operator *(Matrix matrix, int number)
        {
            Matrix result = new Matrix(matrix.Rows, matrix.Columns);
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    result[i, j] = matrix[i, j] * number;
                }
            }
            return result;
        }
        /// <summary>
        /// Перегрузка оператора *
        /// </summary>
        /// <param name="number">Число</param>
        /// <param name="matrix">Матрица</param>
        /// <returns>Произведение двух матриц</returns>
        public static Matrix operator *(int number, Matrix matrix) => matrix * number;// a * b = b * a
        /// <summary>
        /// Перегрузка оператора *
        /// </summary>
        /// <param name="a">Матрица 1</param>
        /// <param name="b">Матрица 2</param>
        /// <returns>Произведение двух матриц</returns>
        public static Matrix operator *(Matrix a, Matrix b)
        {
            try
            {
                if (a.Columns != b.Rows)//проверка на условие
                {
                    throw new Exception("Число столбцов первой матрицы и число строк второй матрицы должны быть равными.");
                }
                Matrix result = new Matrix(a.Rows, b.Columns);
                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < b.Columns; j++)
                    {
                        for (int k = 0; k < a.Columns; k++)
                        {
                            result[i, j] += a[i, k] * b[k, j];
                        }
                    }
                }
                return result;
            }
            catch (Exception)
            {
                Console.WriteLine("Число столбцов первой матрицы и число строк второй матрицы должны быть равными.");
                return new Matrix();
            }

        }
        public static bool operator ==(Matrix a, Matrix b)
        {
            if (a.Rows == b.Rows && a.Columns == b.Columns)
            {
                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < a.Columns; j++)
                    {
                        if (a[i, j] != b[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Перегрузка оператора !=
        /// </summary>
        /// <param name="a">Матрица 1</param>
        /// <param name="b">Матрица 2</param>
        /// <returns>Проверка на неравенство </returns>
        public static bool operator !=(Matrix a, Matrix b) => !(a == b);//a!=b = !(a==b)
        /// <summary>
        /// Переопределение метода Equals
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <returns>Единтичность объектов</returns>
        public override bool Equals(object obj)
        {
            return obj is Matrix matrix &&
                   EqualityComparer<int[,]>.Default.Equals(matr, matrix.matr) &&
                   rows == matrix.rows &&
                   columns == matrix.columns &&
                   Rows == matrix.Rows &&
                   Columns == matrix.Columns;
        }
        /// <summary>
        /// Переопределение метода GetHashCode
        /// </summary>
        /// <returns>Хэш код объекта</returns>
        public override int GetHashCode()
        {
            var hashCode = 49602021;
            hashCode = hashCode * -1521134295 + EqualityComparer<int[,]>.Default.GetHashCode(matr);
            hashCode = hashCode * -1521134295 + rows.GetHashCode();
            hashCode = hashCode * -1521134295 + columns.GetHashCode();
            hashCode = hashCode * -1521134295 + Rows.GetHashCode();
            hashCode = hashCode * -1521134295 + Columns.GetHashCode();
            return hashCode;
        }
    #endregion
    }
}
