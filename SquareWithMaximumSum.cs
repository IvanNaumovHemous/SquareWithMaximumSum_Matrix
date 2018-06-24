using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
            var rows = int.Parse(data[0]);
            var columns = int.Parse(data[1]);

            var matrix = GetFilledMatrix(rows, columns);
            var MaxSumSquare = GetMaxSquare(matrix, rows, columns);
            PrintAnswer(MaxSumSquare);

        }

        private static void PrintAnswer(int[] maxSumSquare)
        {
            Console.WriteLine(maxSumSquare[0] + " " + maxSumSquare[1]);
            Console.WriteLine(maxSumSquare[2] + " " + maxSumSquare[3]);
            Console.WriteLine(maxSumSquare.Sum());
        }

        private static int[] GetMaxSquare(int[,] matrix, int rows, int columns)
        {
            var array = new int[4];
            var sum = 0;
            var temp = 0;
            var r = 0;
            var c = 0;

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < columns - 1; j++)
                {
                    temp = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                    if (temp > sum)
                    {
                        sum = temp;
                        r = i;
                        c = j;
                    }
                }
            }
       
            array[0] = matrix[r, c];
            array[1] = matrix[r, c + 1];
            array[2] = matrix[r + 1, c];
            array[3] = matrix[r + 1, c + 1];

            return array;
        }

        private static int[,] GetFilledMatrix(int rows, int columns)
        {
            var matrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine().Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            return matrix;
        }
    }
}
