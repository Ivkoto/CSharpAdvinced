namespace E06_TargetPractice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            var matrix = InitializeMatrix();
            Shooting(matrix);
            FallOfTheElements(matrix);

            Console.WriteLine(string.Join("\n", matrix.Select(r => string.Join(string.Empty, r))));
        }

        private static void FallOfTheElements(char[][] matrix)
        {
            for (int col = 0; col < matrix[0].Length; col++)
            {
                for (int row = matrix.Length - 1; row > 0; row--)
                {
                    if (matrix[row][col] == ' ' && matrix[row - 1][col] != ' ')
                    {
                        while (row < matrix.Length)
                        {
                            if (matrix[row][col] == ' ')
                            {
                                var temp = matrix[row - 1][col];
                                matrix[row - 1][col] = ' ';
                                matrix[row][col] = temp;
                                row++;
                            }
                            else
                            {
                                break;
                            }
                        }

                    }
                }
            }
        }

        private static void Shooting(char[][] matrix)
        {
            var shotingParameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var impactRow = shotingParameters[0];
            var impactCol = shotingParameters[1];
            var impactRadius = shotingParameters[2];

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    var pointToCenterDistance = Math.Sqrt((row - impactRow) * (row - impactRow) + (col - impactCol) * (col - impactCol));
                    if (pointToCenterDistance <= impactRadius)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static char[][] InitializeMatrix()
        {
            var rowsCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var matrix = new char[rowsCols[0]][].Select(r => r = new char[rowsCols[1]]).ToArray();
            var snake = new Queue<char>(Console.ReadLine().ToCharArray());

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                for (int col = matrix[row].Length - 1; col >= 0; col--)
                {
                    matrix[row][col] = snake.Dequeue();
                    snake.Enqueue(matrix[row][col]);
                }

                row--;

                if (row < 0)
                {
                    break;
                }

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = snake.Dequeue();
                    snake.Enqueue(matrix[row][col]);
                }
            }

            return matrix;
        }
    }
}
