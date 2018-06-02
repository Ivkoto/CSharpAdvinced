namespace MatricesLab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;

    class Program
    {
        static void Main()
        {
            //E01_SumMatrixElements();
            //E01_SumMatrixElements2();
            //E02_MaximumSumOf2x2Submatrix();
            //E03_GroupNumbers();
            //E03_GroupNumbers2();
            //E04_PascalTriangle();
        }

        private static void E04_PascalTriangle()
        {
            var number = int.Parse(Console.ReadLine());
            long[][] matrix = new long[number][];

            for (int row = 0; row < number; row++)
            {
                matrix[row] = new long[row + 1];
                matrix[row][0] = 1;
                matrix[row][row] = 1;

                for (int col = 1; col < row; col++)
                {
                    matrix[row][col] = matrix[row - 1][col - 1] + matrix[row - 1][col];
                }
                
            }
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void E03_GroupNumbers2()
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] sizes = new int[3];

            foreach (var number in numbers)
            {
                int reminder = number % 3;
                sizes[reminder]++;
            }

            int[][] matrix =
            {
                new int[sizes[0]],
                new int[sizes[1]],
                new int[sizes[2]]
            };

            int[] offset = new int[3];
            foreach (var number in numbers)
            {
                int reminder = number % 3;
                int index = offset[reminder];
                matrix[reminder][index] = number;
                offset[reminder]++;
            }
        }

        private static void E03_GroupNumbers()
        {
            var input = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var equalsZero = input.Where(n => Math.Abs(n) % 3 == 0).ToArray();
            var equalsOne = input.Where(n => Math.Abs(n) % 3 == 1).ToArray();
            var equalsTwo = input.Where(n => Math.Abs(n) % 3 == 2).ToArray();

            Console.WriteLine(string.Join(" ", equalsZero));
            Console.WriteLine(string.Join(" ", equalsOne));
            Console.WriteLine(string.Join(" ", equalsTwo));
        }

        private static void E02_MaximumSumOf2x2Submatrix()
        {
            var input = Console.ReadLine()
                            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse).ToArray();

            int[][] matrix = new int[input[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            var maxRow = 0;
            var maxCol = 0;
            var maxSum = int.MinValue;

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[0].Length - 1; col++)
                {
                    var curSum = matrix[row][col] + matrix[row][col + 1] + matrix[row + 1][col] + matrix[row + 1][col + 1];
                    if (maxSum < curSum)
                    {
                        maxRow = row;
                        maxCol = col;
                        maxSum = curSum;
                    }
                }
            }
            Console.WriteLine($@"{matrix[maxRow][maxCol]} {matrix[maxRow][maxCol + 1]}
{matrix[maxRow + 1][maxCol]} {matrix[maxRow + 1][maxCol + 1]}
{maxSum}");
        }

        private static void E01_SumMatrixElements2()
        {
            var input = Console.ReadLine()
                                        .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse).ToArray();
            int[,] matrix = new int[input[0], input[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var values = Console.ReadLine()
                            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = values[col];
                }
            }
            int maxSum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    maxSum += matrix[row, col];
                }
            }
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(maxSum);
        }

        private static void E01_SumMatrixElements()
        {
            var input = Console.ReadLine()
                            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse).ToArray();

            int[][] matrix = new int[input[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            var result = 0;
            foreach (var column in matrix)
            {
                result += column.Sum();
            }
            Console.WriteLine(matrix.Length);
            Console.WriteLine(matrix[0].Length);
            Console.WriteLine(result);
        }
    }
}
