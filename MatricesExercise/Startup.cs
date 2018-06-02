namespace E01ToE04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            E01_MatrixOfPalindromes();
            E02_DiagonalDifference();
            E03_SquaresInMatrix();
            E04_MAximumSum();
        }

        private static void E04_MAximumSum()
        {
            var RowColSize = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[][] matrix = new int[RowColSize[0]][];

            for (int i = 0; i < RowColSize[0]; i++)
            {
                var values = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                matrix[i] = values;
            }
            var maximumSum = 0;
            int[][] largerMatrix =
            {
                new int[3],
                new int[3],
                new int[3]
            };
            for (int row = 0; row < RowColSize[0] - 2; row++)
            {
                for (int col = 0; col < RowColSize[1] - 2; col++)
                {
                    var currentSum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2]
                                   + matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2]
                                   + matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];
                    if (currentSum > maximumSum)
                    {
                        maximumSum = currentSum;
                        largerMatrix[0] = new int[] { matrix[row][col], matrix[row][col + 1], matrix[row][col + 2] };
                        largerMatrix[1] = new int[] { matrix[row + 1][col], matrix[row + 1][col + 1], matrix[row + 1][col + 2] };
                        largerMatrix[2] = new int[] { matrix[row + 2][col], matrix[row + 2][col + 1], matrix[row + 2][col + 2] };
                    }
                }
            }
            Console.WriteLine($"Sum = {maximumSum}");
            foreach (var row in largerMatrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void E03_SquaresInMatrix()
        {
            var RowColSize = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            string[][] matrix = new string[RowColSize[0]][];

            for (int i = 0; i < RowColSize[0]; i++)
            {
                string[] letters = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                matrix[i] = letters;
            }
            var squareEqualCounter = 0;
            for (int row = 0; row < RowColSize[0] - 1; row++)
            {
                for (int col = 0; col < RowColSize[1] - 1; col++)
                {
                    if (matrix[row][col] == matrix[row][col + 1] && matrix[row][col] == matrix[row + 1][col] && matrix[row + 1][col] == matrix[row + 1][col + 1])
                    {
                        squareEqualCounter++;
                    }
                    else { continue; }
                }
            }
            Console.WriteLine(squareEqualCounter);
        }

        private static void E02_DiagonalDifference()
        {
            var RowColSize = int.Parse(Console.ReadLine());

            int[][] matrix = new int[RowColSize][];

            for (int row = 0; row < RowColSize; row++)
            {
                int[] values = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                matrix[row] = values;
            }

            var primaryDiagonalSum = 0;
            var secondaryDiagonalSum = 0;

            var primaryIndex = 0;
            var secondaryIndex = matrix.Length - 1;
            for (int i = 0; i < matrix.Length; i++)
            {
                primaryDiagonalSum += matrix[primaryIndex][primaryIndex];
                secondaryDiagonalSum += matrix[secondaryIndex][primaryIndex];

                primaryIndex++;
                secondaryIndex--;
            }

            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
        }

        private static void E01_MatrixOfPalindromes()
        {
            char[] leters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            var input = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            string[][] matrix = new string[input[0]][];
            for (int i = 0; i < input[0]; i++)
            {
                matrix[i] = new string[input[1]];
            }

            for (int row = 0; row < input[0]; row++)
            {
                for (int col = 0; col < input[1]; col++)
                {
                    var symbol1 = leters[row];
                    var symbol2 = leters[row + col];
                    var symbol3 = leters[row];

                    matrix[row][col] = string.Join("", new char[] { symbol1, symbol2, symbol3 });
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
