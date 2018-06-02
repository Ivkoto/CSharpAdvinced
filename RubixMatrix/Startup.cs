namespace E05_RubixMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        public static int rowsCount = 0;
        public static int colsCount = 0;
        public static int[][] Matrix = new int[1][];

        static void Main()
        {
            var rowColSize = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            rowsCount = rowColSize[0];
            colsCount = rowColSize[1];

            FillMatrises();

            var commanCount = int.Parse(Console.ReadLine());
            var rowCol = int.MinValue;
            var dirrection = string.Empty;
            var moves = long.MinValue;
            for (int i = 0; i < commanCount; i++)
            {
                var command = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                rowCol = int.Parse(command[0]);
                dirrection = command[1];
                moves = long.Parse(command[2]);

                MatrixMovements(rowCol, dirrection, moves);
            }

            CheckMatrixAndPrintResult();
        }

        private static void CheckMatrixAndPrintResult()
        {
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    int mainValue = i * colsCount + (j + 1);
                    int mixedValue = Matrix[i][j];

                    if (mainValue != mixedValue)
                    {
                        for (int k = 0; k < rowsCount; k++)
                        {
                            int index = Array.IndexOf(Matrix[k], mainValue);

                            if (index > -1)
                            {
                                Matrix[k][index] = mixedValue;
                                Matrix[i][j] = mainValue;
                                Console.WriteLine($"Swap ({i}, {j}) with ({k}, {index})");
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                }
            }
        }

        private static void MatrixMovements(int rowCol, string dirrection, long moves)
        {
            int m = (int)(moves % colsCount);
            var values = new Queue<int>();

            if (dirrection.Equals("left"))
            {
                for (int i = 0; i < colsCount; i++)
                {
                    values.Enqueue(Matrix[rowCol][i]);
                }
                for (int i = 0; i < m; i++)
                {
                    int v = values.Dequeue();
                    values.Enqueue(v);
                }
                for (int i = 0; i < colsCount; i++)
                {
                    Matrix[rowCol][i] = values.Dequeue();
                }
            }
            else if (dirrection.Equals("right"))
            {
                for (int i = colsCount - 1; i >= 0; i--)
                {
                    values.Enqueue(Matrix[rowCol][i]);
                }
                for (int i = 0; i < m; i++)
                {
                    int v = values.Dequeue();
                    values.Enqueue(v);
                }
                for (int i = colsCount - 1; i >= 0; i--)
                {
                    Matrix[rowCol][i] = values.Dequeue();
                }
            }
            else if (dirrection.Equals("up"))
            {
                for (int i = 0; i < rowsCount; i++)
                {
                    values.Enqueue(Matrix[i][rowCol]);
                }
                for (int i = 0; i < m; i++)
                {
                    int v = values.Dequeue();
                    values.Enqueue(v);
                }
                for (int i = 0; i < rowsCount; i++)
                {
                    Matrix[i][rowCol] = values.Dequeue();
                }
            }
            else if (dirrection.Equals("down"))
            {
                for (int i = rowsCount - 1; i >= 0; i--)
                {
                    values.Enqueue(Matrix[i][rowCol]);
                }
                for (int i = 0; i < m; i++)
                {
                    int v = values.Dequeue();
                    values.Enqueue(v);
                }
                for (int i = rowsCount - 1; i >= 0; i--)
                {
                    Matrix[i][rowCol] = values.Dequeue();
                }
            }
        }

        private static void FillMatrises()
        {
            Matrix = new int[rowsCount][];

            //filling matrix with increasing integers
            int increasingNum = 1;
            for (int row = 0; row < rowsCount; row++)
            {
                Matrix[row] = new int[colsCount];

                for (int col = 0; col < colsCount; col++)
                {
                    Matrix[row][col] = increasingNum;
                    increasingNum++;
                }
            }
        }
    }
}
