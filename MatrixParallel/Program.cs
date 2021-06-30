using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace MatrixParallel
{
    class Program
    {
        private static Random rand = new();
        private int [,] MatrixCreate()
        {
            var matrix = new int[100, 100];
            for (var i = 0; i < 100; i++)
            {
                for (var j = 0; j < 100; j++)
                {
                    matrix[i, j] = rand.Next(0, 10);
                }
            }
            return matrix;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private int MatrixMulti(int[,] matrix, int[,] matrix1, int[,] matrix2, int i, int j)
        {
            for (var k = 0; k < 100; k++)
            {
                matrix[i, j] += matrix1[i, k] * matrix2[k, j];
            }
            return matrix[i, j];
        }

        private async Task ParralellMatrixMulti(int[,] matrix1, int [,] matrix2)
        {
            int[,] matrix3 = new int[100, 100];
            var tasks = new List<Task>();
            for (var i = 0; i < 100; i++)
            {
                for (var j = 0; j < 100; j++)
                {
                    matrix3[i, j] = MatrixMulti(matrix3, matrix1, matrix2, i, j);                    
                }
            }
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
    }
}
