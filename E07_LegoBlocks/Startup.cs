namespace E07_LegoBlocks
{
    using System;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            var rowsCount = int.Parse(Console.ReadLine());
            var firstMatrix = FillMatrix(rowsCount);
            var secondMatrix = FillMatrix(rowsCount).Select(r => r.Reverse().ToArray()).ToArray();

            if (MatrixIsRectangle(firstMatrix, secondMatrix))
            {
                for (int row = 0; row < firstMatrix.Length; row++)
                {
                    Console.WriteLine($"[{string.Join(", ", firstMatrix[row].Concat(secondMatrix[row]))}]");
                }
            }
            else
            {
                var cellCount = 0;
                for (int row = 0; row < firstMatrix.Length; row++)
                {
                    cellCount += firstMatrix[row].Length + secondMatrix[row].Length;
                }
                Console.WriteLine($"The total number of cells is: {cellCount}");
            }
        }

        private static bool MatrixIsRectangle(int[][] firstMatrix, int[][] secondMatrix)
        {
            for (int row = 1; row < firstMatrix.Length; row++)
            {
                if (firstMatrix[row].Length + secondMatrix[row].Length != firstMatrix[row - 1].Length + secondMatrix[row - 1].Length)
                {
                    return false;
                }
            }
            return true;
        }

        private static int[][] FillMatrix(int rowsCount)
        {
            var matrix = new int[rowsCount][];

            for (int row = 0; row < rowsCount; row++)
            {
                int[] rowValues = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                matrix[row] = rowValues;
            }
            return matrix;
        }
    }
}
