using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace MatrixParallel
{
    class Program
    {
        private static int[,] MatrixCreate()
        {
            Random rand = new();
            var matrix = new int[100, 100];
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    matrix[i, j] = rand.Next(0, 11);
                }
            }
            return matrix;
        }
        static async Task Main(string[] args)
        {
            var matrix1 = MatrixCreate();
            var matrix2 = MatrixCreate();
            await ParralellMatrixMulti(matrix1, matrix2);
            Console.WriteLine("работа программы завершена");
        }

        private static int MatrixMulti(int[,] matrix, int[,] matrix1, int[,] matrix2, int i, int j, out int thread_id)
        {
            matrix[i, j] = 0;
            for (int k = 0; k < 100; k++)
            {
                matrix[i, j] += matrix1[i, k] * matrix2[k, j];
            }
            thread_id = Thread.CurrentThread.ManagedThreadId;
            return matrix[i, j];
        }

        private static void Progress(int i, int thread_id)
        {
            Console.WriteLine($"получено число {i} в потоке {thread_id}");
        }
        private static async Task ParralellMatrixMulti(int[,] matrix1, int[,] matrix2)
        {
            int[,] matrix3 = new int[100, 100];
            var tasks = new List<Task>();
            for (int i = 0; i < 99; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    tasks.Add(Task.Run(() =>
                    {
                        matrix3[i, j] = MatrixMulti(matrix3, matrix1, matrix2, i, j, out int thread_id);
                        Progress(matrix3[i, j], thread_id);
                    }));
                }
            }
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
       
       /* static void Main(string[] args)
        {
            var matrix1 = MatrixCreate();
            var matrix2 = MatrixCreate();
            ParralellMatrixMulti(matrix1, matrix2);
            Console.WriteLine("работа программы завершена");
        }

        private static int MatrixMulti(int[,] matrix, int[,] matrix1, int[,] matrix2, int i, int j, out int thread_id)
        {
            matrix[i, j] = 0;
            for (int k = 0; k < 100; k++)
            {
                matrix[i, j] += matrix1[i, k] * matrix2[k, j];
            }
            thread_id = Thread.CurrentThread.ManagedThreadId;
            return matrix[i, j];
        }

        private static void Progress(int i, int thread_id)
        {
            Console.WriteLine($"получено число {i} в потоке {thread_id}");
        }
        private static int[,] ParralellMatrixMulti(int[,] matrix1, int[,] matrix2)
        {
            int[,] matrix3 = new int[100, 100];
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    matrix3[i, j] = MatrixMulti(matrix3, matrix1, matrix2, i, j, out int thread_id);
                    Progress(matrix3[i, j], thread_id);

                }
            }
            return matrix3;
        }
        */
    }
}
