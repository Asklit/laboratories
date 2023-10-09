using System.Linq.Expressions;

namespace Лаба1
{
    internal class task1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вариант 10");
            Console.WriteLine("---------------------------");
            FirstTask();
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Принадлежит ли точка области? Ответ: {SecondTask()}");
            Console.WriteLine("---------------------------");
            ThirdTask();
        }

        static void FirstTask()
        {
            double m, n;
            bool isConvert;

            Console.WriteLine("Задание 1. Вычисление значений");
            
            // считывание чисел m и n

            do
            {
                Console.WriteLine("Привет! Введи число m");
                isConvert = double.TryParse(Console.ReadLine(), out m);
                if (!isConvert)
                    Console.WriteLine($"Ошибка, вы ввели не число m. Повторите ввод");
            } while (!isConvert);

            do
            {
                Console.WriteLine("Привет! Введи число n");
                isConvert = double.TryParse(Console.ReadLine(), out n);
                if (!isConvert)
                    Console.WriteLine("Ошибка, вы ввели не число n. Повторите ввод");
            } while (!isConvert);

            // проверка возможности деления на n и вывод результатов первого выражения
            
            if (n != 1)
            {
                n -= 1;
                double res1 = m / n++;
                Console.WriteLine($"Значение выражения: (m / --n++) равно {res1}. Значение m={m}, n={n}");
            }
            else { Console.WriteLine("Невозможно вычислить (m / --n++), деление на 0 невозможно"); };

            // проверка возможности деления на n и вывод результатов второго выражения

            if (n != 0)
            {
                bool res2 = m / n < n--;
                Console.WriteLine($"Значение выражения: (m / n < n--) равно {res2}. Значение m={m}, n={n}");
            }
            else { Console.WriteLine("Невозможно вычислить (m / n < n--), деление на 0 невозможно"); }

            // вычисление и вывод значения третьего выражения

            bool res3 = m + n++ > n + m;
            Console.WriteLine($"Значение выражения: (m + n++ > n + m) равно {res3}. Значение m={m}, n={n}");

            double x;

            // считывание переменной x

            do
            {
                Console.WriteLine("Привет! Введи число x");
                isConvert = double.TryParse(Console.ReadLine(), out x);
                if (!isConvert)
                    Console.WriteLine("Ошибка, вы ввели не число x. Повторите ввод");
            } while (!isConvert);

            // вычисление и вывод значения четвертого выражения

            double res4 = Math.Pow(x, 5) * Math.Sqrt(Math.Abs(x - 1)) + Math.Abs(25 - Math.Pow(x, 5));

            Console.WriteLine($"Значение выражения: (x^5*sqrt(abs(x - 1)) + abs(25 - x^5)) равно {res4}");
            
        }


        static bool SecondTask()
        {
            double x, y;
            bool isConvert;

            Console.WriteLine("Задание 2. Определение положения точки");

            // считывание координат (x y)

            do
            {
                Console.WriteLine("Привет! Введи координату x");
                isConvert = double.TryParse(Console.ReadLine(), out x);
                if (!isConvert)
                    Console.WriteLine("Введи координату x, вещественное число");
            } while (!isConvert);

            do
            {
                Console.WriteLine("Привет! Введи координату y");
                isConvert = double.TryParse(Console.ReadLine(), out y);
                if (!isConvert)
                    Console.WriteLine("Введи координату y, вещественное число");
            } while (!isConvert);

            // вычисление положения точки заданной области
            
            bool res;
            
            res = ((y >= -1 / 7.0 * x - 1) & (x <= 0) & (y <= 0));

            return res;

            /*if (res)
            {
                Console.WriteLine($"Точка ({x}, {y}) принадлежит заданной области.");
            }
            else { Console.WriteLine($"Точка ({x}, {y}) не лежит в заданной области."); };*/

        }

        static void ThirdTask()
        {
                       
            Console.WriteLine("Задание 3. Вычисление примера с заданными данными");
            double aDouble;
            double bDouble;
            aDouble = 1000;
            bDouble = 0.0001;

            // вычисление выражения в типе double 

            double bufDouble1 = (double)Math.Pow(aDouble + bDouble, 3);

            double bufDouble2 = (double)Math.Pow(aDouble, 3);

            double bufDouble3 = (double)Math.Pow(aDouble, 2);

            double bufDouble4 = (double)Math.Pow(bDouble, 2);

            double bufDouble5 = (double)Math.Pow(bDouble, 3);

            double bufDouble6 = (double)(bufDouble1 - (double)(bufDouble2 + (double)(3 * bufDouble3 * bDouble)));

            double bufDouble7 = (double)((double)(3 * aDouble * bufDouble4) + bufDouble5);

            double resDouble = bufDouble6 / bufDouble7;

            // вычисление выражения в типе float 

            float aFloat = 1000;
            float bFloat = 0.0001f;

            float bufFloat1 = (float)Math.Pow(aFloat + bFloat, 3);

            float bufFloat2 = (float)Math.Pow(aFloat, 3);

            float bufFloat3 = (float)Math.Pow(aFloat, 2);

            float bufFloat4 = (float)Math.Pow(bFloat, 2);

            float bufFloat5 = (float)Math.Pow(bFloat, 3);

            float bufFloat6 = (float)(bufFloat1 - (float)(bufFloat2 + (float)(3 * bFloat * bufFloat3)));

            float bufFloat7 = (float)((float)(3 * aFloat * bufFloat4) + bufFloat5);

            float resFloat = bufFloat6 / bufFloat7;

            Console.Write($"A - double, B - double. Ответ: ");
            Console.WriteLine(resDouble);

            Console.Write($"A - float, B - float. Ответ: ");
            Console.WriteLine(resFloat);
        }


    }
}