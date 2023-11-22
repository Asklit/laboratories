using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
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
            bool flag = false;

            number = GetInt(1, 2, "Число не пренадлежит списку. Введите номер пункта еще раз.");

            int[] arr = new int[1];
            bool isWork = true;

            while (isWork)
            {
                switch (number)
                {
                    case 1:
                        {
                            arr = (int[])CreateRandomArray();
                            Console.WriteLine($"Сформирован массив длины: {arr.Length}");
                            break;
                        };
                    case 2:
                        {
                            arr = (int[])CreateArray();
                            Console.WriteLine($"Сформирован массив длины: {arr.Length}");
                            break;
                        }
                    case 3 when flag:
                        {
                            Console.WriteLine("Вывод элементов массива в строку через пробел:");
                            for (int i = 0; i < arr.Length; i++)
                            {
                                Console.Write(arr[i] + " ");
                            }
                            Console.WriteLine();
                            break;
                        };
                    case 4 when flag:
                        {
                            arr = (int[])DeliteItems(arr);
                            break;
                        };
                    case 5 when flag:
                        {
                            arr = (int[])AddItems(arr);
                            break;
                        }
                    case 6 when flag:
                        {
                            arr = (int[])ShiftElements(arr);
                            break;
                        }
                    case 7 when flag:
                        {
                            FindItem(arr);
                            break;
                        }
                    case 8 when flag:
                        {
                            arr = (int[])SlowSort(arr);
                            break;
                        }
                    case 9 when flag:
                        {
                            Console.WriteLine("Завершение работы.");
                            isWork = false;
                            break;
                        }

                }

                flag = true;

                Console.WriteLine("");
                Console.WriteLine("Введите номер того пунка, который хотите выполнить.");
                Console.WriteLine("1. Сформировать массив из случайных чисел заданной длины.");
                Console.WriteLine("2. Сформировать массив из входных данных заданной длины.");
                Console.WriteLine("3. Вывод элементов массива.");
                Console.WriteLine("4. Удалить все элементы больше среднего арифметического элементов массива.");
                Console.WriteLine("5. Добавить выбранное количество элементов в начало массива.");
                Console.WriteLine("6. Сдвинуть циклически на указаное количество элементов вправо.");
                Console.WriteLine("7. Поиск первого четного элемента массива.");
                Console.WriteLine("8. Медленная сортировка массива.");
                Console.WriteLine("9. Выход");
                Console.WriteLine();

                number = GetInt(1, 9, "Число не пренадлежит списку. Введите номер пункта еще раз.");
            }

        }

        static int GetInt(int minInt, int maxInt, string errorMessage)
        {
            bool isConvert;
            int number;

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

        static Array CreateRandomArray()
        {
            int lenght;

            Console.WriteLine("Введите длину массива.");
            lenght = GetInt(1, int.MaxValue, "Длина массива должна быть натуральным числом. Повторите ввод числа.");

            int[] arr = new int[lenght];
            var rand = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(-100, 100);
            };
            return arr;
        }

        static Array CreateArray()
        {
            int number, lenght;

            Console.WriteLine("Введите длину массива.");
            lenght = GetInt(1, int.MaxValue, "Длина массива должна быть натуральным числом. Повторите ввод числа.");

            int[] arr = new int[lenght];

            for (int i = 0; i < lenght; i++)
            {
                Console.WriteLine($"Введите число для формирования массива. Осталось ввести {lenght - i}");
                number = GetInt(int.MinValue, int.MaxValue, "");
            }
            return arr;
        }

        static Array DeliteItems(int[] arr)
        {
            int amount = 0;

            foreach (int item in arr)
            {
                amount += item;
            }

            int count = 0;

            foreach (int item in arr)
            {
                if ((amount / (double)arr.Length) <= item)
                {
                    count += 1;
                }
            }

            int[] newArr = new int[count];
            int index = 0;

            foreach (int item in arr)
            {
                if ((amount / (double)arr.Length) <= item)
                {
                    newArr[index] = item;
                    index++;
                }
            }
            Console.WriteLine($"Удалены все элементы, большие {amount / (double)arr.Length}");

            return newArr;
        }

        static Array AddItems(int[] arr)
        {
            int k;

            k = GetInt(1, int.MaxValue, "Количество элементов должно быть натуральным числом. Повторите ввод еще раз.");
            Console.WriteLine("Введите количество элементов, которое хотите добавить в массив.");

            int[] newArr = new int[k + arr.Length];

            for (int i = 0; i < k; i++)
            {
                Console.WriteLine($"Введите число. Осталось ввести {k - i} чисел.");
                newArr[i] = GetInt(int.MinValue, int.MaxValue, "");
            }
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i + k] = arr[i];
            }
            Console.WriteLine($"Добавлено чисел в массив - {k}. Суммарная длина полученного массива - {newArr.Length}.");
            return newArr;
        }

        static Array ShiftElements(int[] arr)
        {
            int shift;

            Console.WriteLine("Введите на какое количество элементов вы хотите сдвинуть элементы массива");
            shift = GetInt(1, int.MaxValue, "Ввод отрицательных значений со сдвигом влево по уловию задачи не предусмотрен. Введите число еще раз.");

            shift %= arr.Length;

            int[] newArr = new int[arr.Length];
            int index = 0;

            for (int i = (arr.Length - shift); i < arr.Length; i++)
            {
                newArr[index] = arr[i];
                index++;
            }
            
            for (int i = 0; i < (arr.Length - shift); i++)
            {
                newArr[index] = arr[i];
                index++;
            }
            Console.WriteLine($"Выполен циклический сдвиг вправо на {shift} элементов.");
            return newArr;
        }

        static void FindItem(int[] arr)
        {
            int count = 0;
            int elem = 0;
            bool flag = false;

            foreach (int item in arr) 
            {
                count++;
                if (item % 2 == 0)
                {
                    flag = true;
                    elem = item;
                    break;
                };
            }
            
            if (flag)
            {
                Console.WriteLine($"Первый четный элемент массива - {elem}. Количество сравнений - {count} из {arr.Length} возможных.");
            }
            else
            {
                Console.WriteLine($"Четных элементов в массиве нет. Количество проведнных сравнений - {count}.");
            };
        }
        
        static Array SlowSort(int[] arr)
        {
            int j, item;
            for (int i = 1; i < arr.Length; i++)
            {
                item = arr[i];
                j = i - 1;
                while (j >= 0 && item < arr[j])
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = item;
            }

            return arr;
        }
    }
}