using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Task1
{
    /// <summary>
    /// Форматирование координат
    /// от d.d,d.d на X:d.d Y: d.d где d - decimal значение
    /// </summary>
    class Coordinates
    {
        /// <summary>
        /// Форматирует введенные данные 
        /// </summary>
        public static void Manual()
        {
            string text;

            //ввод данных и преобразование
            Console.WriteLine("Введите координаты: ");
            text = Console.ReadLine();
            string[] formattedText = text.Split(new char[] { ',' });//разделение x и y
            decimal.TryParse(formattedText[0].Replace('.', ','), out decimal x);//заменa . на , и присвоение значение x
            decimal.TryParse(formattedText[1].Replace('.', ','), out decimal y);//заменa . на , и присвоение значение x

            Console.WriteLine("X: " + x.ToString() + " Y: " + y.ToString());
        }
        /// <summary>
        /// Форматируют данные через файл
        /// </summary>
        public static void FromTxtFile()
        {
            string text;
            string path;//путь к файлу

            //открытие диалогового окна для выбора файла
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            openFileDialog.Title = "Выберите текстовый файл";
            openFileDialog.ShowDialog();
            path = openFileDialog.FileName;

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        text = sr.ReadLine();
                        string[] formattedText = text.Split(new char[] { ',' });//разделение x и y
                        decimal.TryParse(formattedText[0].Replace('.', ','), out decimal x);//заменa . на , и присвоение значение x
                        decimal.TryParse(formattedText[1].Replace('.', ','), out decimal y);//заменa . на , и присвоение значение x
                        Console.WriteLine("X: " + x.ToString() + " Y: " + y.ToString());
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось прочесть файл. Попробуйте еще раз.");
            }           
        }
    }
}
