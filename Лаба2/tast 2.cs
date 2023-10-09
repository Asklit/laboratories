using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace Лаба2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вариант 9. Задачи 1 - 9. Задача 2 - 26. Задача 3 - 43.");

            Console.WriteLine("---------------------------");
            FirstTask();
            Console.WriteLine("---------------------------");
            SecondTask();
            Console.WriteLine("---------------------------");
            ThirdTask();

        }
        
        static void FirstTask()
        {
            int n;
            bool isConvert;

            Console.WriteLine("Задание 1. Дана последовательность из n целых чисел. Найти максимальный элемент в этой последовательности.");
            Console.WriteLine("Привет! Введи длину последовательности.");

            // считывание числа натурального числа n

            do
            {
                isConvert = int.TryParse(Console.ReadLine(), out n);
                if (!isConvert)
                {
                    Console.WriteLine("Длина последовательности должна быть целым числом.");
                    Console.WriteLine("Введи длину последовательности.");
                }
                else if (n < 0)
                {
                    Console.WriteLine("Длина последовательности должна быть положительной.");
                    Console.WriteLine("Введи длину последовательности.");
                    isConvert = false;
                }
                else if (n == 0)
                {
                    Console.WriteLine("Длина последовательности не может быть равна нулю.");
                    Console.WriteLine("Введи длину последовательности.");
                    isConvert = false;
                };
            } while (!isConvert);

            // переменные для вычисления максимального числа из последовательности и их кол-ва

            int number, maxNumber, countMax;
            maxNumber = -1000000000;
            countMax = 1;

            // последовательное считывание числа number

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введи целое число. Уже введено {i} чисел из {n}.");
                do
                {
                    isConvert = int.TryParse(Console.ReadLine(), out number);
                    if (!isConvert)
                        Console.WriteLine("Ошибка. Нужно ввести целое число.");
                } while (!isConvert);

                // перезапись максимального числа из предыдущих введеных и текущего и количества введеных макс. чисел
                // по заданию нужно вывести только макс. из последовательности, но я доработал программу и подсчитываю еще их количество

                if (maxNumber == number)
                {
                    countMax += 1;
                }
                else if (number > maxNumber)
                {
                    maxNumber = number;
                    countMax = 1;
                }
                    

            }

            Console.WriteLine($"Максимальный элемент последовательности равен: {maxNumber}");
            Console.WriteLine($"Количество максимальных элементов: {countMax}");

        }

        static void SecondTask()
        {
            Console.WriteLine("Задача 2. Дана последовательность целых чисел, за которой следует 0. Найти максимальный элемент в этой последовательности.");

            // переменные для вычисления максимального числа из последовательности и их кол-ва

            bool isConvert, numberNotZero;
            int number, maxNumber, countMax, index;

            maxNumber = -1000000000;
            countMax = 1;
            index = 0;

            do
            {
                Console.WriteLine("Введите число. Если хотите завершить работу - введите 0.");

                // последовательное считывание числа number

                do
                {
                    isConvert = int.TryParse(Console.ReadLine(), out number);
                    if (!isConvert)
                        Console.WriteLine("Ошибка. Нужно ввести целое число.");
                } while (!isConvert);
                                
                if (number != 0)
                {
                    numberNotZero = true;
                    // Количество введенных чисел
                    index += 1;

                    // перезапись максимального числа из предыдущих введеных и текущего и количества введеных макс. чисел
                    // по заданию нужно вывести только макс. из последовательности, но я доработал программу и подсчитываю еще их количество

                    if (maxNumber == number)
                    {
                        countMax += 1;
                    }
                    else if (number > maxNumber)
                    {
                        maxNumber = number;
                        countMax = 1;
                    }
                }
                else
                {
                    numberNotZero = false;
                }
                                
            } while (numberNotZero);


            // Проверка длины последовательности
            if (index == 0)
            {
                Console.WriteLine("Последовательность пуста.");
            }
            else
            {
                Console.WriteLine($"Максимальный элемент последовательности равен: {maxNumber}");
                Console.WriteLine($"Количество максимальных элементов: {countMax}");
            }
        }

        static void ThirdTask()
        {
            Console.WriteLine("Задание 3. Найти первое отрицательное число последовательности u=cos(ctg(n)), где n=1,2,3...");
            
            int n = 0;
            
            // перебор значений n и проверка условия 
            
            do
            {
                n += 1;
                Console.Write($"При n = {n} принимает значение: ");
                Console.WriteLine(Math.Cos((float)1 / Math.Tan(n)));
            } while (Math.Cos((float)1 / Math.Tan(n)) >= 0);
            Console.WriteLine($"Уравнение u=cos(ctg(n)) впервые принимает отрицательное значение при n = {n}.");
        }


    }
}