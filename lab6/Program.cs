using System.Text.RegularExpressions;

using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace lab
{
    internal class Lab5
    {
        private const string Path = "..\\..\\..\\data.txt";

        /// <summary>
        /// Основая функция
        /// </summary>
        /// <param name="number">Номер меню </param>
        /// <param name="str">Строка предложений</param>
        static void Main()
        {
            int number;
            string str = "";
            do
            {
                PrintMenu();
                number = GetInt(1, 5);

                switch (number)
                {
                    case 1:
                        {
                            Console.Clear();
                            bool isCorrect = false;
                            do
                            {
                                Console.WriteLine("Введите предложения:");
                                str = "" + Console.ReadLine();
                                str = str.Replace("\t", " ");
                                str = str.Replace("\\t", " ");
                                if (StringIsCorrect(str))
                                {
                                    str = FormatString(str);
                                    isCorrect = true;
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный ввод. Введите ликвидные предложения.");
                                }
                            } while (!isCorrect);
                            Console.Clear();
                            break;
                        }
                    case 2:
                        {
                            try
                            {
                                using var sr = new StreamReader(Path);
                                var rand = new Random();
                                var logFile = File.ReadAllLines(Path);
                                var logList = new List<string>(logFile);
                                str = logList[index: rand.Next(1, logList.Count - 1)];
                                str = FormatString(str);
                                Console.Clear();
                                Console.WriteLine("Сформирована рандомные предложения.");
                            }
                            catch (IOException e)
                            {
                                Console.WriteLine("Этот файл не может быть считан:");
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case 3:
                        {
                            if (string.IsNullOrEmpty(str))
                            {
                                Console.WriteLine("Строка пустая. Сначала заполните ее любым способом.");
                                break;
                            }
                            ReverseWords(ref str);
                            Console.Clear();
                            Console.WriteLine("Строка преобразована.");
                            break;
                        }
                    case 4:
                        {
                            if (string.IsNullOrEmpty(str))
                            {
                                Console.WriteLine("Строка пустая. Сначала заполните ее любым способом.");
                                break;
                            }
                            Console.Clear();
                            Console.WriteLine(str);
                            break;
                        }
                }
            } while (number != 5);
            Console.WriteLine("Завершение работы.");
        }

        /// <summary>
        /// Вывод меню в консоль
        /// </summary>
        static void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Выберите пункт меню из списка:");
            Console.WriteLine("1. Ввести предложения вручную.");
            Console.WriteLine("2. Сформировать предложения рандомно.");
            Console.WriteLine("3. Преобразовать предложения.");
            Console.WriteLine("4. Печать предложений.");
            Console.WriteLine("5. Завершние работы.");
        }

        /// <summary>
        /// Ввод числа
        /// </summary>
        /// <param name="number">Вводимое число</param>
        /// <param name="isConvert">Проверка правильности ввода</param>
        /// <returns>Введенное число number</returns>
        static int GetInt(int minInt, int maxInt, string errorMessage = "Число за допустимыми границами. Введите число еще раз.")
        {
            bool isConvert;
            int number;
            // Проверка корректности ввода числа
            do
            {
                isConvert = int.TryParse(Console.ReadLine(), out number);
                if (!isConvert)
                {
                    Console.WriteLine("Некорректный ввод. Повторите ввод числа.");
                }
                else if (number < minInt)
                {
                    Console.WriteLine(errorMessage);
                    isConvert = false;
                }
                else if (number > maxInt)
                {
                    Console.WriteLine(errorMessage);
                    isConvert = false;
                };

            } while (!isConvert);

            return number;
        }

        /// <summary>
        /// Поиск символов в строке
        /// </summary>
        /// <param name="str">Строка предложений</param>
        /// <param name="index">Индекс символа</param>
        /// <returns>Индекс символа</returns>
        static int FindSeparator(string str, int index)
        {
            static bool IsSeparator(char letter)
            {
                char[] separators = { ' ', ';', '.', '-', '!', '?', ',', ':' };
                foreach (char sep in separators)
                {
                    if (sep == letter)
                        return true;
                }
                return false;
            }

            for (int i = index + 1; i < str.Length; i++)
            {
                if (IsSeparator(str[i]))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Переворот слов в строке
        /// </summary>
        /// <param name="str">Строка для переворота слов</param>
        static void ReverseWords(ref string str)
        {
            int left = 0;
            int number = 1;

            do
            {

                int right = FindSeparator(str, left);
                if (right == -1)
                    break;
                if (number == str[left..right].Length - 1)
                {
                    str = string.Concat(str.AsSpan()[0..(left + 1)], Reverse(str[(left + 1)..right]), str.AsSpan()[right..str.Length]);
                }

                left = right;

                if (str[right] == '.' | str[right] == '!' | str[right] == '?')
                    number = 0;
                else if (str[right] == ' ')
                    number++;
            } while (left < str.Length - 1);
        }

        /// <summary>
        /// Переворот слова
        /// </summary>
        /// <param name="word">Слово для переворота</param>
        /// <returns>Перевернутое слово</returns>
        static string Reverse(string word)
        {
            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Форматирование строки
        /// </summary>
        /// <param name="str">Строка для форматирования</param>
        /// <returns>Отформатированная строка</returns>
        static string FormatString(string str)
        {
            str = str.Replace("\t", " ");
            string[] s = str.Split(' ');

            Regex regexWordPattern = new(@"[^ ]+");
            Regex regexSimbolPattern = new(@"[.,!?;']");
            List<string> buf = new();
            int index = 0;

            foreach (string item in s)
            {
                if (item.Length == 1)

                {
                    if (regexSimbolPattern.IsMatch(item[0].ToString()) && buf.Count > 0)
                    {
                        buf.Insert(index: index - 1, buf[index - 1] + item[0]);
                        buf.RemoveAt(index);
                    }
                    else if (regexWordPattern.IsMatch(item))
                    {
                        buf.Add(item);
                        index++;
                    }
                }
                else if (item.Length > 1 && item != "\t")
                {
                    if (regexSimbolPattern.IsMatch(item[0].ToString()) && buf.Count > 0)
                    {
                        buf.Insert(index: index - 1, buf[index - 1] + item[0]);
                        buf.RemoveAt(index);

                        if (regexWordPattern.IsMatch(item[1..]))
                        {
                            buf.Add(item[1..]);
                            index++;
                        }
                    }
                    else if (regexWordPattern.IsMatch(item))
                    {
                        buf.Add(item);
                        index++;
                    }
                }


            }
            string newString = string.Join(" ", buf.ToArray());
            return newString;
        }

        /// <summary>
        /// Проверка на корректность введенной строки
        /// </summary>
        /// <param name="str">Строка текста</param>
        /// <returns>true/false строка корректна или нет</returns>
        static bool StringIsCorrect(string str)
        {
            Regex regexWordPattern = new(@"[!?',.:;]?[а-яА-ЯёЁa-zA-Z]+[!?',.:;]?");
            Regex regexNumbersPattern = new(@"[0-9]+");
            Regex regexPunctiationPattern = new(@"[!?',.:;]");
            Regex regexDoublePunctiationPattern = new(@"[!?',.:;][!?',.:;]+");
            Regex regexPeriodsPattern = new(@"[!.?]");
            Regex regexPattern = new(@"");
            Regex regexIllegalPattern = new(@"[#$%&'()*+\/<=>?@[^_`{|}][#$%&'()*+\/<=>?@[^_`{|}]*");
            int index = 0;
            foreach (string item in str.Split(" "))
            {
                if (regexIllegalPattern.IsMatch(item))
                    return false;
                else if (index == 0 && regexPunctiationPattern.IsMatch(item) && !regexWordPattern.IsMatch(item))
                    return false;
                else if (!(regexPattern.IsMatch(item) || regexWordPattern.IsMatch(item) || regexPunctiationPattern.IsMatch(item) || regexNumbersPattern.IsMatch(item)))
                    return false;
                else if (item != "" && item != "\t")
                    index++;
            }
            if (regexPeriodsPattern.IsMatch(str) && !regexDoublePunctiationPattern.IsMatch(str))
                return true;
            return false;
        }
    }
}