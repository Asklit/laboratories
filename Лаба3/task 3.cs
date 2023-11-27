using System;
using System.Linq.Expressions;

namespace labs
{
    internal class task3
    {
        /// <summary>
        /// main function
        /// </summary>
        /// <param ="FirstTask">completing the first task</param>
        static void Main(string[] args)
        {
            FirstTask();
        }

        /// <summary>
        /// function count Se, Sn, f(x) for different x
        /// </summary>
        /// <param ="xa">start point for x</param>
        /// <param ="xb">finish point for x</param>
        /// <param ="sn">amount power series expansions for baced n</param>
        /// <param ="se">amount power series expansions for accuracy e</param>
        /// <param ="k">count point for count Se, Sn, f(x)</param>
        /// <param ="n">count series expansions for Sn</param>
        /// <param ="e">count accuracy series expansions for Se</param>
        static void FirstTask()
        {

            double xa = 0.1;
            double xb = 0.8;
            double f;
            double sn, se;
            double k = 10;
            double x = xa;
            int n = 30;
            double e = 0.0001;

            // automatic table formation

            Console.WriteLine(string.Join("", Enumerable.Repeat("_", 86)));
            Console.WriteLine("|" + string.Join("", Enumerable.Repeat(" ", 13)) + "|" +
                string.Join("", Enumerable.Repeat(" ", 14)) + "|" +
                string.Join("", Enumerable.Repeat(" ", 14)) + "|" +
                string.Join("", Enumerable.Repeat(" ", 16)) + "|" +
                string.Join("", Enumerable.Repeat(" ", 23)) + "|");
            Console.WriteLine("|" + string.Join("", Enumerable.Repeat(" ", 6)) + "X" + string.Join("", Enumerable.Repeat(" ", 6)) + "|" +
                string.Join("", Enumerable.Repeat(" ", 6)) + "Sn" + string.Join("", Enumerable.Repeat(" ", 6)) + "|" +
                string.Join("", Enumerable.Repeat(" ", 6)) + "Se" + string.Join("", Enumerable.Repeat(" ", 6)) + "|" +
                string.Join("", Enumerable.Repeat(" ", 6)) + "f(x)" + string.Join("", Enumerable.Repeat(" ", 6)) + "|" +
                string.Join("", Enumerable.Repeat(" ", 4)) + "Delta(Sn, f(x))" + string.Join("", Enumerable.Repeat(" ", 4)) + "|");
            Console.WriteLine("|" + string.Join("", Enumerable.Repeat("_", 13)) + "|" +
                string.Join("", Enumerable.Repeat("_", 14)) + "|" +
                string.Join("", Enumerable.Repeat("_", 14)) + "|" +
                string.Join("", Enumerable.Repeat("_", 16)) + "|" +
                string.Join("", Enumerable.Repeat("_", 23)) + "|");

            Console.WriteLine("|" + string.Join("", Enumerable.Repeat(" ", 13)) + "|" +
                string.Join("", Enumerable.Repeat(" ", 14)) + "|" +
                string.Join("", Enumerable.Repeat(" ", 14)) + "|" +
                string.Join("", Enumerable.Repeat(" ", 16)) + "|" +
                string.Join("", Enumerable.Repeat(" ", 23)) + "|");

            // main cycle, selecting the value of x from xa to xb with step = (xb - xa) / k
            do
            {
                // calculating different functions in different ways

                sn = countSN(n, x);
                se = countSE(e, x);
                f = countY(x);

                string formatX = string.Format("{0:f5}", x);
                string formatSN = string.Format("{0:f5}", sn);
                string formatSE = string.Format("{0:f5}", se);
                string formatF = string.Format("{0:f5}", f);

                string formatFSn = string.Format("{0:f5}", Math.Abs(f-sn));

                //  data output in automatic table

                Console.WriteLine($"| x = {formatX} | Sn = {formatSN} | Se = {formatSE} | f(x) = {formatF} | d(f(x), Sn) = {formatFSn} |");

                x += (xb - xa) / k;
            } while (x < xb);

            // automatic table formation

            Console.WriteLine("|" + string.Join("", Enumerable.Repeat("_", 13)) + "|" +
                string.Join("", Enumerable.Repeat("_", 14)) + "|" +
                string.Join("", Enumerable.Repeat("_", 14)) + "|" +
                string.Join("", Enumerable.Repeat("_", 16)) + "|" +
                string.Join("", Enumerable.Repeat("_", 23)) + "|");

        }


        /// <summary>
        /// count amount Sn with a recurrent numerator for baced n
        /// </summary>
        /// <param ="amount">amount Sn</param>
        /// <param ="recurent">the part of the function calculated recursively</param>
        /// <returns>total amount</returns>
        static double countSN(int n, double x)
        {
            double amount = x;
            double recurent = x;

            for (int i = 1; i < n + 1; i++)
            {
                recurent *= (x * x * x * x);
                amount += (recurent / (4 * i + 1));
            }
            return amount;
        }

        /// <summary>
        /// count amount Sn with a recurrent numerator for accuracy e
        /// </summary>
        /// <param ="amount">amount Sn</param>
        /// <param ="an">the part of a numerical series</param>
        /// <returns>total amount</returns>
        static double countSE(double e, double x)
        {

            double amount = 0;
            double recurent = x;
            int n = 0;

            while (Math.Abs(recurent) > e)
            {
                amount += (recurent / (4 * n + 1));
                n += 1;
                recurent *= (x * x * x * x);
            };
            return amount;
        }

        /// <summary>
        /// count f(x)
        /// </summary>
        /// <param ="f">math function</param>
        /// <returns>the value of the function at the point x</returns>
        static double countY(double x)
        {
            double f = Math.Log((1 + x) / (1 - x)) / 4 + Math.Atan(x) / 2;
            return f;
        }


    }
}