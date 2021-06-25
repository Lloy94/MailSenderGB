using System;
using System.Numerics;
using System.Threading;

namespace ConsoleAppThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            int n = int.Parse(Console.ReadLine());
            Thread myThread1 = new Thread(() => Summ(n));
            myThread1.Start();
            Thread myThread2 = new Thread(() => Factorial(n));
            myThread2.Start();
            Console.ReadLine();
        }

        public static BigInteger Factorial(int n)
        {
            var factorial = new BigInteger(1);
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
                Console.WriteLine($"Вычисление факториала в первом потоке, факториал для числа {i} - {factorial}");
                Thread.Sleep(50);
            }

            return factorial;
        }

        private static void Summ(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
                Console.WriteLine($"Вычисление суммы чисел во втором потоке - {sum}");
                Thread.Sleep(50);
            }
        }


    }
}
