namespace E09_Crossfire
{
    using System;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            var matrix = InitializeMatrix();

            matrix = Shooting(matrix);

            PrintResult(matrix);
        }

        private static void PrintResult(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row].Where(c => c != -1)));
            }
        }

        private static int[][] Shooting(int[][] matrix)
        {
            var shootingCommand = Console.ReadLine().Trim();

            while (!shootingCommand.Equals("Nuke it from orbit"))
            {
                var shootParameters = shootingCommand.Split(' ').Select(int.Parse).ToArray();

                var shotRow = shootParameters[0];
                var shotCol = shootParameters[1];
                var shotRadius = shootParameters[2];

                matrix = DestroyMatrix(shotRow, shotCol, shotRadius, matrix);

                shootingCommand = Console.ReadLine().Trim();
            }

            return matrix;
        }

        private static int[][] DestroyMatrix(int shotRow, int shotCol, int shotRadius, int[][] matrix)
        {
            for (int row = shotRow - shotRadius; row <= shotRow + shotRadius; row++)
            {
                if (IsInMatrix(row, shotCol, matrix))
                {
                    matrix[row][shotCol] = -1;
                }

            }
            for (int col = shotCol - shotRadius; col <= shotCol + shotRadius; col++)
            {
                if (IsInMatrix(shotRow, col, matrix))
                {
                    matrix[shotRow][col] = -1;
                }
            }
            //rearrange matrix
            for (int row = 0; row < matrix.Length; row++)
            {
                //move cells
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] < 0)
                    {
                        matrix[row] = matrix[row].Where(c => c > 0).ToArray();
                        break;
                    }
                }
                //remove empty rows
                if (matrix[row].Count() < 1)
                {
                    matrix = matrix.Take(row).Concat(matrix.Skip(row + 1)).ToArray();
                    row--;
                }
            }
            return matrix;
        }

        private static bool IsInMatrix(int row, int col, int[][] matrix)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static int[][] InitializeMatrix()
        {
            var rowsCols = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var matrix = new int[rowsCols[0]][];
            var counter = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[rowsCols[1]];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = counter;
                    counter++;
                }
            }

            return matrix;
        }
    }
}
