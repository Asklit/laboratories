using System.Linq.Expressions;

namespace Лаба1
{
    internal class task3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вариант 9");
            FirstTask();
        }

        static void FirstTask()
        {

            double xa = 0.1;
            double xb = 0.8;
            double y;
            double sn, se;
            double k = 10;
            double x = xa;
            int n = 30;
            double e = 0.0001;

            // Основной цикл программы, перебор значений х от xa до xb с шагом (xb - xa) / k
            do
            {
                // вычисление разных функций разными способами

                sn = countSN(n, x);
                se = countSE(e, x);
                y = countY(x);

                // отступы для красивого вывода

                string bufx, bufn, bufe;
                bufx = string.Join("", Enumerable.Repeat(" ", (20 - x.ToString().ToArray().Length)));
                bufn = string.Join("", Enumerable.Repeat(" ", (20 - sn.ToString().ToArray().Length)));
                bufe = string.Join("", Enumerable.Repeat(" ", (20 - se.ToString().ToArray().Length)));

                Console.WriteLine($"X = {x}{bufx}| Sn = {sn}{bufn}| Se = {se}{bufe}| y = {y}");

                x += (xb - xa) / k;
            } while (x < xb);
        }

        static double countSN(int n, double x)
        {
            // подсчет Sn с рекурентным числителем

            double amount = x;
            double an = x;

            for (int i = 1; i < n + 1; i++)
            {
                an *= (x * x * x * x) / (double)(4 * n + 1);
                amount += an;
            }
            return amount;
        }

        static double countSE(double e, double x)
        {
            // подсчет Se с рекурентным числителем

            double amount = 0;
            double an = x;
            int n = 0;

            while (Math.Abs(an) > e)
            {
                amount += an;
                n += 1;
                an *= (x * x * x * x) / (double)(4 * n + 1);
            };
            return amount;
        }

        static double countY(double x)
        {
            // вычисление значения функции Y = 1/4 * ln((1 + x)(1 - x)) + 1/2 * arctan(x)

            double y = Math.Log((1 + x) / (1 - x)) / 4 + Math.Atan(x) / 2;
            return y;
        }


    }
}