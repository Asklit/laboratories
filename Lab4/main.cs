using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.Arm;

namespace Лаба1
{
    internal class task
    {
        /// <summary>
        /// main function
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер того пунка, который хотите выполнить.");
            Console.WriteLine("1. Сформировать массив из случайных чисел заданной длины.");
            Console.WriteLine("2. Сформировать массив из входных данных заданной длины.");

            int number;
            bool isConvert;
            bool flag = false;

            do
            {
                
                isConvert = int.TryParse(Console.ReadLine(), out number);
                if (!isConvert)
                {
                    Console.WriteLine("Неправильно введено число. Попробуйте еще раз ввести номер из списка.");
                }
                else if (number < 1 | number > 2)
                {
                    Console.WriteLine("Число не пренадлежит списку. Введите номер пункта еще раз.");
                    isConvert = false;
                };
            } while (!isConvert);

            while (true)
            {
                switch (number)
                {
                    case 1:
                        {
                            int lenght, maxValue;

                            Console.WriteLine("Введите длину массива.");

                            do
                            {
                                isConvert = int.TryParse(Console.ReadLine(), out lenght);
                                if (!isConvert)
                                {
                                    Console.WriteLine("Длина массива должна быть целым числом.");
                                    Console.WriteLine("Повторите ввод.");
                                }
                                else if (lenght < 0)
                                {
                                    Console.WriteLine("Длина массива должна быть положительной.");
                                    Console.WriteLine("Повторите ввод.");
                                    isConvert = false;
                                }
                                else if (lenght == 0)
                                {
                                    Console.WriteLine("Длина массива не может быть равна нулю.");
                                    Console.WriteLine("Повторите ввод.");
                                    isConvert = false;
                                };
                                
                            } while (!isConvert);

                            Console.WriteLine("Ведите максимально возможное значение в массиве (целое число большее 1).");

                            do
                            {
                                isConvert = int.TryParse(Console.ReadLine(), out maxValue);
                                if (!isConvert)
                                {
                                    Console.WriteLine("Некорректный ввод. Введите число еще раз.");
                                }
                                else if (maxValue < 2)
                                {
                                    Console.WriteLine("Число должно быть больше единицы.");
                                    isConvert = false;
                                }
                            } while (!isConvert);

                            CreateRandomArray(lenght, maxValue);

                            break;
                        };
                    case 2 when flag:
                        {
                            Console.WriteLine();
                            break;
                        }
                    case 3 when flag:
                        {
                            Console.WriteLine();
                            break;
                        };
                    case 4 when flag:
                        {
                            Console.WriteLine();
                            break;
                        };
                }

                flag = true;

                Console.WriteLine("1. Сформировать массив из случайных чисел заданной длины.");
                Console.WriteLine("2. Сформировать массив из входных данных заданной длины.");
                Console.WriteLine("3. ");
                Console.WriteLine("4. ");
                Console.WriteLine("5. ");
                Console.WriteLine("6. ");

                do
                {
                    isConvert = int.TryParse (Console.ReadLine(), out number);
                    if (!isConvert)
                    {
                        Console.WriteLine("Неправильно введено число. Попробуйте еще раз ввести номер из списка.");

                    }
                    else if (number < 1 | number > 4)
                    {
                        Console.WriteLine("Число не пренадлежит списку. Введите номер пункта еще раз.");
                        isConvert = false;
                    };

                    
                
                } while (!isConvert);
            }

        }

        static Array CreateRandomArray(int lenght, int maxValue)
        {

            int[] arr = new int[lenght];
            var rand = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(1, maxValue + 1);
                Console.WriteLine(arr[i]);
            };
            return arr;

        }


    }
}