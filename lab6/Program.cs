using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace lab
{
    internal class Lab5
    {
        private const string Path = "F:\\data\\projects\\VSprojects\\labs\\laboratories\\lab6\\data.txt";

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
                                if (stringIsCorrect(str))
                                {
                                    str = FormatString(str);
                                    isCorrect = true;
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный ввод. Введите ликвидные предложения.");
                                }
                            } while (!isCorrect);
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
                            }
                            catch (IOException e)
                            {
                                Console.WriteLine("Этот файл не может быть считан:");
                                Console.WriteLine(e.Message);
                            }
                            Console.Clear();
                            Console.WriteLine("Сформирована рандомные предложения.");
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

        static int FindSeparator(string str, int index)
        {
            bool IsSeparator(char letter)
            {
                char[] separators = { ' ', ';', '.', '-', '!', '?', ',', ':' };
                foreach (char sep in separators)
                {
                    if (sep == letter)
                        return true;
                }
                return false;
            }

            for ( int i = index + 1; i < str.Length; i++ )
            {
                if (IsSeparator(str[i]))
                    return i;
            }
            return -1;
        }

        static void ReverseWords(ref string str)
        {
            int left = 0, right = 0;
            int number = 1;

            do
            {
                
                right = FindSeparator(str, left);
                if (right == -1)
                    break;
                if (number == str[left..right].Length - 1)
                {
                    str = string.Concat(str.AsSpan()[0..(left + 1)], Reverse(str[(left+1)..right]), str.AsSpan()[right..str.Length]);
                }
                
                left = right;

                if (str[right] == '.' | str[right] == '!' | str[right] == '?')
                    number = 0;
                else if (str[right] == ' ')
                    number ++;
            } while (left < str.Length - 1);
        }

        static string Reverse(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static string FormatString(string str)
        {
            string[] s = str.Split(' ');
            Regex regexWordPattern = new(@"[^ ]+");
            Regex regexSimbolPattern = new(@"[.,!?;']");
            List<string> buf = new();
            int index = 0;

            foreach (string item in s)
            {
                if (regexSimbolPattern.IsMatch(item) && buf.Count > 0)
                {
                    buf.Insert(index: index, buf[index - 1] + item);
                    index++;
                }
                else if (regexWordPattern.IsMatch(item))
                {
                    buf.Add(item);
                    index++;
                }
            }
            string newString = string.Join(" ", buf.ToArray());
            return newString;
        }

        static bool stringIsCorrect(string str)
        {
            Regex regexWordPattern = new(@"[!?',.:;]?[а-яА-ЯёЁa-zA-Z]+[!?',.:;]?");
            Regex regexNumbersPattern = new(@"[0-9]+");
            Regex regexPunctiationPattern = new(@"[!?',.:;]");
            Regex regexPeriodsPattern = new(@"[!.?]");
            Regex regexPattern = new(@"");
            Regex regexIllegalPattern = new(@"[!?',.:;!#$%&'()*+,\-./:;<=>?@[^_`{|}][!?',.:;!#$%&'()*+,\-./:;<=>?@[^_`{|}]+");
            int index = 0;
            foreach (string item in str.Split(" "))
            {
                if (index == 0 && regexPunctiationPattern.IsMatch(item))
                    return false;
                else if (!(regexPattern.IsMatch(item) || regexWordPattern.IsMatch(item) || regexPunctiationPattern.IsMatch(item) || regexNumbersPattern.IsMatch(item)))
                    return false;
                else if (regexIllegalPattern.IsMatch(item))
                    return false;
                else if (item != "")
                    index++;
            }
            if (regexPeriodsPattern.IsMatch(str))
                return true;
            return false;
        }
    }
}




