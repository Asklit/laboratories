using Microsoft.VisualBasic;
using System;

namespace lab
{
    internal class Lab5
    {
        /// <summary>
        /// Основа программы
        /// </summary>
        /// <params name=oneDimensionalArray>Одномерный массив</params>
        /// <params name=twoDimensionalArray>Двумерный массив</params>
        /// <params name=unknownDimensionalArray>Рваный массив</params>
        /// <params name=currentMenu>Текущее меню</params> 
        static void Main()
        {
            int currentMenu = 0;
            // Создание массивов
            int[] oneDimensionalArray = Array.Empty<int>();
            int[,] twoDimensionalArray = new int[0,0];
            int[][] unknownDimensionalArray = new int[0][]; 

            int numArray;

            do
            {
                PrintMenu(currentMenu); // Вывод меню
                numArray = GetInt(1, 4, "Число не пренадлежит списку. Введите номер пункта еще раз.");

                switch (numArray)
                {
                    case 1:
                        {
                            currentMenu = 1; // Смена меню
                            int numPoint;

                            Console.Clear(); // Отчистка консоли
                            do
                            {
                                PrintMenu(currentMenu);
                                numPoint = GetInt(1, 4, "Число не пренадлежит списку. Введите номер пункта еще раз.");

                                switch (numPoint)
                                {
                                    case 1:
                                        {
                                            currentMenu = 11; // Смена меню
                                            int numGenerate;

                                            Console.Clear(); // Отчистка консоли
                                            PrintMenu(currentMenu);
                                            numGenerate = GetInt(1, 3, "Число не пренадлежит списку. Введите номер пункта еще раз.");

                                            switch (numGenerate)
                                            {
                                                case 1:
                                                    {
                                                        // Создание и заполнение массива вводимой длины
                                                        GetLengthArray(out int length);
                                                        oneDimensionalArray = new int[length];
                                                        FillRandomArray(ref oneDimensionalArray);
                                                        // Вывод логов в консоль
                                                        Console.Clear();
                                                        Console.WriteLine("Сформирован массив из рандомных чисел.");
                                                        Console.WriteLine();
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        // Создание и заполнение массива вводимой длины
                                                        GetLengthArray(out int length);
                                                        oneDimensionalArray = new int[length];
                                                        FillArray(ref oneDimensionalArray);
                                                        // Вывод логов в консоль
                                                        Console.Clear();
                                                        Console.WriteLine("Сформирован массив из введенных чисел.");
                                                        Console.WriteLine();
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                            }
                                            currentMenu = 1;
                                            break;
                                        }
                                    case 2:
                                        {
                                            if (CheckEmpty(oneDimensionalArray)) // Проверка на пустой массив
                                            {
                                                Console.Clear(); // Вывод логов в консоль
                                                Console.WriteLine("Массив пустой.");
                                                Console.WriteLine();
                                            }
                                            else
                                            {
                                                // Печать массива
                                                Console.Clear(); // Вывод логов в консоль
                                                Console.WriteLine("Печать одномерного массива:");
                                                PrintArray(currentMenu, oneDimensionalArray, twoDimensionalArray, unknownDimensionalArray);
                                                Console.WriteLine();
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            if (CheckEmpty(oneDimensionalArray))  // Проверка на пустой массив
                                            {
                                                Console.Clear(); // Вывод логов в консоль
                                                Console.WriteLine("Массив пустой.");
                                                Console.WriteLine();
                                            }
                                            else
                                            {
                                                oneDimensionalArray = DeliteOddItems(oneDimensionalArray); // Удаление нечетных чисел

                                                Console.Clear(); // Вывод логов в консоль
                                                Console.WriteLine("Удалены все нечетные элементы.");
                                                Console.WriteLine();
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            currentMenu = 0;
                                            Console.Clear();
                                            break;
                                        }
                                }
                            } while (numPoint != 4);

                            break;
                        }
                    case 2:
                        {
                            currentMenu = 2;
                            int numPoint;

                            Console.Clear();
                            do
                            {
                                PrintMenu(currentMenu);
                                numPoint = GetInt(1, 4, "Число не пренадлежит списку. Введите номер пункта еще раз.");

                                switch (numPoint)
                                {
                                    case 1:
                                        {
                                            currentMenu = 21;
                                            int numGenerate;

                                            Console.Clear();
                                            PrintMenu(currentMenu);
                                            numGenerate = GetInt(1, 3, "Число не пренадлежит списку. Введите номер пункта еще раз.");

                                            switch (numGenerate)
                                            {
                                                case 1:
                                                    {
                                                        GetLengthArray(out int str, out int col); // Создание и заполнение массива вводимой длины
                                                        twoDimensionalArray = new int[str, col];
                                                        FillRandomArray(ref twoDimensionalArray);
                                                        
                                                        Console.Clear();
                                                        Console.WriteLine("Сформирован двумерный массив из рандомных чисел.");
                                                        Console.WriteLine();
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        GetLengthArray(out int str, out int col); // Создание и заполнение массива вводимой длины
                                                        twoDimensionalArray = new int[str, col];
                                                        FillArray(ref twoDimensionalArray);
                                                        
                                                        Console.Clear();
                                                        Console.WriteLine("Сформирован двумерный массив из введенных чисел.");
                                                        Console.WriteLine();
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                            }
                                            currentMenu = 2;
                                            break;
                                        }
                                    case 2:
                                        {
                                            if (CheckEmpty(twoDimensionalArray)) // Проверка на пустой массив
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Массив пустой.");
                                                Console.WriteLine();
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Печать двумерного массива:");
                                                PrintArray(currentMenu, oneDimensionalArray, twoDimensionalArray, unknownDimensionalArray);
                                                Console.WriteLine();
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            currentMenu = 231;
                                            int TypeFillArray;

                                            Console.Clear();
                                            PrintMenu(currentMenu);
                                            TypeFillArray = GetInt(1, 3, "Число не пренадлежит списку. Введите номер пункта еще раз.");
                                            switch (TypeFillArray)
                                            {
                                                case 1:
                                                    {
                                                        if (twoDimensionalArray.Length >= 10000) // Проверка на переполнение массива
                                                        {
                                                            Console.WriteLine("Достигнуто максимальное количество строк в массиве.");
                                                            break;
                                                        }
                                                        int[,] buf;
                                                        if (twoDimensionalArray.GetLength(1) != 0) // Проверка на пустой массив
                                                        {

                                                            GetLengthNewArray(out int k, twoDimensionalArray.Length);
                                                            buf = new int[k, twoDimensionalArray.GetLength(1)];
                                                        }
                                                        else
                                                        {
                                                            GetLengthArray(out int k, out int col);
                                                            buf = new int[k, col];
                                                        }
                                                        FillRandomArray(ref buf);
                                                        twoDimensionalArray = AddRows(twoDimensionalArray, buf); // Добавление строк в массив

                                                        Console.Clear();
                                                        Console.WriteLine("Добавлены новые строки в массив.");
                                                        Console.WriteLine();
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        if (twoDimensionalArray.Length >= 10000) // Проверка на переполнение массива
                                                        {
                                                            Console.WriteLine("Достигнуто максимальное количество строк в массиве.");
                                                            break;
                                                        }
                                                        int[,] buf;
                                                        if (twoDimensionalArray.GetLength(1) != 0) // Проверка на пустой массив
                                                        {

                                                            GetLengthNewArray(out int k, twoDimensionalArray.Length);
                                                            buf = new int[k, twoDimensionalArray.GetLength(1)];
                                                        }
                                                        else
                                                        {
                                                            GetLengthArray(out int k, out int col);
                                                            buf = new int[k, col];
                                                        }
                                                        FillArray(ref buf);
                                                        twoDimensionalArray = AddRows(twoDimensionalArray, buf); // Добавление строк в массив

                                                        Console.Clear();
                                                        Console.WriteLine("Добавлены новые строки в массив.");
                                                        Console.WriteLine();
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                            }
                                            currentMenu = 2;
                                            break;
                                        }
                                    case 4:
                                        {
                                            currentMenu = 0;
                                            Console.Clear();
                                            break;
                                        }
                                }
                            } while (numPoint != 4);

                            break;
                        }
                    case 3:
                        {
                            currentMenu = 3;
                            int numPoint;

                            Console.Clear();
                            do
                            {
                                PrintMenu(currentMenu);
                                numPoint = GetInt(1, 4, "Число не пренадлежит списку. Введите номер пункта еще раз.");

                                switch (numPoint)
                                {
                                    case 1:
                                        {
                                            currentMenu = 31;
                                            int numGenerate;

                                            Console.Clear();
                                            PrintMenu(currentMenu);
                                            numGenerate = GetInt(1, 3, "Число не пренадлежит списку. Введите номер пункта еще раз.");

                                            switch (numGenerate)
                                            {
                                                case 1:
                                                    {
                                                        // Создание и заполнение массива
                                                        GetLengthArray(out int str, out int[] cols);
                                                        unknownDimensionalArray = new int[str][];
                                                        FillRandomArray(ref unknownDimensionalArray, cols);
                                                        
                                                        Console.Clear();
                                                        Console.WriteLine("Сформирован рваный массив из рандомных чисел.");
                                                        Console.WriteLine();
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        // Создание и заполнение массива
                                                        GetLengthArray(out int str, out int[] cols);
                                                        unknownDimensionalArray = new int[str][];
                                                        FillArray(ref unknownDimensionalArray, cols);
                                                        
                                                        Console.Clear();
                                                        Console.WriteLine("Сформирован рваный массив из рандомных чисел.");
                                                        Console.WriteLine();
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                            }
                                            currentMenu = 3;
                                            break;
                                        }
                                    case 2:
                                        {
                                            if (CheckEmpty(unknownDimensionalArray)) // Проверка на пустой массив
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Массив пустой.");
                                                Console.WriteLine();
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Печать рваного массива:");
                                                PrintArray(currentMenu, oneDimensionalArray, twoDimensionalArray, unknownDimensionalArray);
                                                Console.WriteLine();
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            if (CheckEmpty(unknownDimensionalArray)) // Проверка на пустой массив
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Массив пустой.");
                                                Console.WriteLine();
                                            }
                                            else
                                            {
                                                // Удаление строки в массиве
                                                Console.Clear();
                                                Console.WriteLine("Введите номер строки для удаления.");
                                                int k = GetInt(1, unknownDimensionalArray.GetLength(0), $"Номер строки может быть от {1} до {unknownDimensionalArray.GetLength(0)}. Введите номер пункта еще раз.");
                                                unknownDimensionalArray = DeliteRow(unknownDimensionalArray, k);

                                                Console.Clear();
                                                Console.WriteLine($"Удалена строка номер {k}.");
                                                Console.WriteLine();
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            currentMenu = 0;
                                            Console.Clear();
                                            break;
                                        }
                                }
                            } while (numPoint != 4);

                            break;
                        }
                }
            } while (numArray != 4);
            Console.Clear();
            Console.WriteLine("Завершение работы.");
        }

        /// <summary>
        /// Ввод числа
        /// </summary>
        /// <param name="number">Вводимое число</param>
        /// <param name="isConvert">Проверка правильности ввода</param>
        /// <returns>Введенное число number</returns>
        static int GetInt(int minInt, int maxInt, string errorMessage="Число за допустимыми границами. Введите число еще раз.")
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
        /// Ввод длины массива
        /// </summary>
        /// <param name="length">Длина массива</param>
        static void GetLengthArray(out int length)
        {
            Console.Clear();
            Console.WriteLine("Введите длину массива:");
            length = GetInt(1, 1000000, $"Длина массива может быть от {1} до {1000000}. Введите номер пункта еще раз.");
        }

        /// <summary>
        /// Ввод количества строк и столбцов
        /// </summary>
        /// <param name="str">количество строк</param>
        /// <param name="col">количество столбцов</param>
        static void GetLengthArray(out int str, out int col)
        {
            Console.Clear();
            Console.WriteLine("Введите количество строк:");
            str = GetInt(1, 10000, $"Количетсво строк может быть от {1} до {10000}. Введите номер пункта еще раз.");
            Console.Clear();
            Console.WriteLine("Введите количество столбцов:");
            col = GetInt(1, 10000, $"Количетсво столбцов может быть от {1} до {10000}. Введите номер пункта еще раз.");
        }

        /// <summary>
        /// Ввод количества строк и столбцов
        /// </summary>
        /// <param name="str">количество строк</param>
        /// <param name="col">количество столбцов</param>
        /// <param name="cols">Массив количества столбцов в каждой строке</param>
        static void GetLengthArray(out int str, out int[] cols)
        {
            Console.Clear();
            Console.WriteLine("Введите количество строк:");
            str = GetInt(1, 10000, $"Количество строк может быть от {1} до {10000}. Введите номер пункта еще раз.");
            Console.Clear();
            cols = new int[str];
            for (int i = 0; i < str; i++)
            {
                Console.WriteLine($"Введите количество столбцов для строки {i + 1} из {str}:");
                cols[i] = GetInt(1, 10000, $"Количество столбцов может быть от {1} до {10000}. Введите номер пункта еще раз.");
            }
        }

        /// <summary>
        /// Ввод длины массива
        /// </summary>
        /// <param name="k">Количество строк</param>
        /// <param name="length">Количество строк в массиве</param>
        static void GetLengthNewArray(out int k, int length)
        {
            Console.WriteLine("Введите количество строк для добавления в массив.");
            k = GetInt(1, 10000 - length, $"Количетсво строк может быть от {1} до {10000 - length}. Введите номер пункта еще раз.");
        }

        /// <summary>
        /// Проверка на пустой массив
        /// </summary>
        /// <param name="arr">Массив</param>
        /// <returns>True/False Длина массива равна нулю</returns>
        static bool CheckEmpty(int[] arr)
        {
            return arr.Length == 0;
        }

        /// <summary>
        /// Проверка на пустой массив
        /// </summary>
        /// <param name="arr">Массив</param>
        /// <returns>True/False Длина массива равна нулю</returns>
        static bool CheckEmpty(int[,] arr)
        {
            return arr.Length == 0;
        }

        /// <summary>
        /// Проверка на пустой массив
        /// </summary>
        /// <param name="arr">Массив</param>
        /// <returns>True/False Длина массива равна нулю</returns>
        static bool CheckEmpty(int[][] arr)
        {
            return arr.Length == 0;
        }

        /// <summary>
        /// Вывод меню в консоль
        /// </summary>
        /// <param name="numberMenu">Текущее меню</param>
        static void PrintMenu(int numberMenu)
        {
            Console.WriteLine("Выберите пункт меню из списка:");
            switch (numberMenu)
            {
                case 0:
                    {
                        Console.WriteLine("1. Работа с одномерным массивом.");
                        Console.WriteLine("2. Работа двумерным массивом.");
                        Console.WriteLine("3. Работа с рваным массивом.");
                        Console.WriteLine("4. Завершние работы.");
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("1. Создать одномерный массив.");
                        Console.WriteLine("2. Напечатать массив.");
                        Console.WriteLine("3. Удалить все нечетные элементы.");
                        Console.WriteLine("4. Вернуться в главное меню.");
                        break;
                    }
                case 11:
                    {
                        Console.WriteLine("1. Создать массив с рандомными числами.");
                        Console.WriteLine("2. Создать массив вручную.");
                        Console.WriteLine("3. Назад.");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("1. Создать двумерный массив.");
                        Console.WriteLine("2. Напечатать массив.");
                        Console.WriteLine("3. Добавить выбранное количество строк в массив.");
                        Console.WriteLine("4. Вернуться в главное меню.");
                        break;
                    }
                case 21:
                    {
                        Console.WriteLine("1. Создать массив с рандомными числами.");
                        Console.WriteLine("2. Создать массив вручную.");
                        Console.WriteLine("3. Назад.");
                        break;
                    }
                case 231:
                    {
                        Console.WriteLine("1. Заполнить строки рандомными числами.");
                        Console.WriteLine("2. Заполнить строки в ручную.");
                        Console.WriteLine("3. Назад."); ;
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("1. Создать рваный массив.");
                        Console.WriteLine("2. Напечатать массив.");
                        Console.WriteLine("3. Удалить строку с заданным номером.");
                        Console.WriteLine("4. Вернуться в главное меню.");
                        break;
                    }
                case 31:
                    {
                        Console.WriteLine("1. Создать массив с рандомными числами.");
                        Console.WriteLine("2. Создать массив вручную.");
                        Console.WriteLine("3. Назад.");
                        break;
                    }
                
            }
        }

        /// <summary>
        /// Заполнение одномерного массива рандомными числами
        /// </summary>
        /// <param name="arr">Массив</param>
        static void FillRandomArray(ref int[] arr)
        {
            var rand = new Random();

            // Формирование массива из рандомных элементов
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(-100, 100);
            };
        }

        /// <summary>
        /// Заполнение двумерного массива рандомными числами
        /// </summary>
        /// <param name="arr">Массив</param>
        static void FillRandomArray(ref int[,] arr)
        {
            var rand = new Random();

            // Формирование массива из рандомных элементов
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(-100, 100);
                }
            }
        }

        /// <summary>
        /// Заполнение рваного массива рандомными числами
        /// </summary>
        /// <param name="arr">Массив</param>
        /// <param name="lens">Длины строк</param>
        static void FillRandomArray(ref int[][] arr, params int[] lens)
        {
            var rand = new Random();

            // Формирование массива из рандомных элементов
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                arr[i] = new int[lens[i]];
                for (int j = 0; j < lens[i]; j++)
                {
                    arr[i][j] = rand.Next(-100, 100);
                }
            }
        }

        /// <summary>
        /// Создание массива из вводимых значений
        /// </summary>
        /// <param name="number">Число массива</param>
        /// <param name="lenght">Длина массива</param>
        /// <param name="arr">Одномерный массив чисел</param>
        static void FillArray(ref int[] arr)
        {
            // Формирование массива из введенных значений
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Введите число для формирования массива. Осталось ввести {arr.Length - i}");
                int number = GetInt(int.MinValue, int.MaxValue);
                arr[i] = number;
            }
        }

        /// <summary>
        /// Создание массива из вводимых значений
        /// </summary>
        /// <param name="arr">Двумерный массив чисел</param>
        static void FillArray(ref int[,] arr)
        {
            // Формирование массива из введенных значений

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine($"Введите число для формирования массива. Строка {i+1} из {arr.GetLength(0)}. Осталось ввести {arr.GetLength(1) - j}");
                    int number = GetInt(int.MinValue, int.MaxValue);
                    arr[i, j] = number;
                }
            }
        }

        /// <summary>
        /// Создание массива из вводимых значений
        /// </summary>
        /// <param name="arr">Рваный массив чисел</param>
        /// <param name="lens">длины строк массива</param>
        static void FillArray(ref int[][] arr, params int[] lens)
        {
            // Формирование массива из введенных значений
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                arr[i] = new int[lens[i]];
                for (int j = 0; j < lens[i]; j++)
                {
                    Console.WriteLine($"Введите число для формирования массива. Строка {i + 1} из {arr.GetLength(0)}. Осталось ввести {lens[i] - j}");
                    arr[i][j] = GetInt(int.MinValue, int.MaxValue);
                }
            }
        }

        /// <summary>
        /// Поиск максимальных длин элементов для красивого отображения
        /// </summary>
        /// <param name="arr">Двумерный массив чисел</param>
        /// <returns>Массив полученный длин</returns>
        static int[] MaxIndexes(int [,] arr)
        {
            int[] indexs = new int[arr.GetLength(1)];
            for (int i = 0; i < arr.GetLength(1); i++) // Заполнение массива минимальными значениями
                indexs[i] = 0;
            // Поиск максимальной длины числа в каждом столбце
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j].ToString().Length > indexs[j]) 
                        indexs[j] = arr[i, j].ToString().Length; // Перезапись максимального значения
                }
            }
            return indexs;
        }

        /// <summary>
        /// Поиск максимальных длин элементов для красивого отображения
        /// </summary>
        /// <param name="arr">Рваный массив чисел</param>
        /// <returns>Массив полученный длин</returns>
        static int[] MaxIndexes(int[][] arr)
        {
            int maxValue = 0;
            foreach (int[] items in arr) // Поиск максимальной длины подмассива
            {
                maxValue = Math.Max(maxValue, items.Length);
            }
            
            int[] indexs = new int[maxValue];
            for (int i = 0; i < maxValue; i++) // Заполнение массива минимальными значениями
                indexs[i] = 0;
            // Поиск максимальной длины числа в каждом столбце
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j].ToString().Length > indexs[j])
                        indexs[j] = arr[i][j].ToString().Length; // Перезапись максимального значения
                }
            }
            return indexs;
        }

        /// <summary>
        /// Вывод массива
        /// </summary>
        /// <param name="currentMenu">Пункт меню</param>
        /// <param name="oneDimensionalArray">Одномерный массив</param>
        /// <param name="twoDimensionalArray">Двумерный массив</param>
        /// <param name="unknownDimensionalArray">Рваный массив</param>
        static void PrintArray(int currentMenu, int[] oneDimensionalArray, int[,] twoDimensionalArray, int[][] unknownDimensionalArray)
        {
            switch (currentMenu)
            {
                case 1:
                    {
                        for (int i = 0; i < oneDimensionalArray.Length; i++)
                        {
                            Console.Write(oneDimensionalArray[i] + " ");
                        }
                        Console.WriteLine();
                        break;
                    }
                case 2:
                    {
                        int[] indexs = MaxIndexes(twoDimensionalArray);

                        for (int i = 0; i < twoDimensionalArray.GetLength(0); i++)
                        {
                            for (int j = 0; j < twoDimensionalArray.GetLength(1); j++)
                                Console.Write(twoDimensionalArray[i, j].ToString().PadLeft(indexs[j]) + " ");
                            Console.WriteLine();
                        }
                        break;
                    }
                case 3:
                    {
                        int[] indexs = MaxIndexes(unknownDimensionalArray);

                        for (int i = 0; i < unknownDimensionalArray.GetLength(0); i++)
                        {
                            for (int j = 0; j < unknownDimensionalArray[i].Length; j++)
                                Console.Write(unknownDimensionalArray[i][j].ToString().PadLeft(indexs[j]) + " ");
                            Console.WriteLine();
                        }
                        break;
                    }
            }
        }
        
        /// <summary>
        /// Удаление нечетных элементов в массиве
        /// </summary>
        /// <param name="arr">Одномерный массив чисел</param>
        /// <returns>Новый массив</returns>
        static int[] DeliteOddItems(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++) // Поиск количества четных элементов в массиве
            {
                if (arr[i] % 2 == 0)
                    count++;
            }

            int[] newArr = new int[count];
            int index = 0;
            for (int i = 0; i < arr.Length; i++) // Заполнение нового массива из четных элементов
            {
                if (arr[i] % 2 == 0) // Проверка на четность
                {
                    newArr[index] = arr[i];
                    index++;
                }
            }
            return newArr;
        }

        /// <summary>
        /// Добавление строк в начало массива
        /// </summary>
        /// <param name="arr">Двумерный массив</param>
        /// <param name="rows">Массив добавляемых строк</param>
        /// <returns></returns>
        static int[,] AddRows(int[,] arr, int[,] rows)
        {
            int[,] newArr = new int[arr.GetLength(0) + rows.GetLength(0), Math.Max(arr.GetLength(1), rows.GetLength(1))];
            for (int i = 0; i < rows.GetLength(0); i++) // Заполнение нового массива введенными значениями
            {
                for (int j = 0; j < rows.GetLength(1); j++)
                    newArr[i, j] = rows[i, j];
            }
            
            for (int i = 0; i < arr.GetLength(0); i++) // Добавление в массив значение из исходного массива
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    newArr[i + rows.GetLength(0), j] = arr[i, j];
            }
            return newArr;
        }

        /// <summary>
        /// Удаление строки из массива
        /// </summary>
        /// <param name="arr">Рваный массив чисел</param>
        /// <param name="k">Номер удаляемой строки</param>
        /// <returns>Новый массив</returns>
        static int[][] DeliteRow(int[][] arr, int k)
        {
            int[][] newArr = new int[arr.GetLength(0) - 1][];
            int index = 0;
            // Добавление в новый массив всех строк кроме k
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (i != (k - 1))
                {
                    newArr[index] = arr[i];
                    index++;
                }
            }
            return newArr;
        }
    }
}