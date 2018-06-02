namespace E12_StringMatrixRotation
{
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main()
        {
            var inputDegree = Console.ReadLine()
                .Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);            

            var rotation = int.Parse(inputDegree[1]) % 360;
            var maxLenght = 0;
            var wordList = new List<char[]>();

            maxLenght = AllWordsInList(maxLenght, wordList);

            if (rotation == 0)
            {
                PrintRotation0(rotation, wordList);
                return;
            }

            char[][] matrix = InitializeAndFill(wordList);

            switch (rotation)
            {
                case 90:
                    PrintRotation90(rotation, maxLenght, matrix);
                    break;
                case 180:
                    PrintRotation180(rotation, maxLenght, matrix);
                    break;
                case 270:
                    PrintRotation270(rotation, maxLenght, matrix);
                    break;
                default:
                    break;
            }
        }

        private static int AllWordsInList(int maxLenght, List<char[]> wordList)
        {
            var input = Console.ReadLine();
            while (!input.Equals("END"))
            {
                var word = input.ToCharArray();
                if (maxLenght < word.Length)
                {
                    maxLenght = word.Length;
                }
                wordList.Add(word);

                input = Console.ReadLine();
            }

            return maxLenght;
        }

        private static char[][] InitializeAndFill(List<char[]> wordList)
        {
            var matrix = new char[wordList.Count][];
            for (int row = 0; row < wordList.Count; row++)
            {
                matrix[row] = wordList[row];
            }

            return matrix;
        }

        private static void PrintRotation0(int rotation, List<char[]> wordList)
        {
            for (int i = 0; i < wordList.Count; i++)
            {
                Console.WriteLine(wordList[i]);
            }
        }

        private static void PrintRotation90(int rotation, int maxLenght, char[][] matrix)
        {
            if (rotation == 90)
            {
                for (int col = 0; col < maxLenght; col++)
                {
                    for (int row = matrix.Length - 1; row >= 0; row--)
                    {
                        if (col >= matrix[row].Length)
                        {
                            Console.Write(" ");
                            continue;
                        }
                        else
                        {
                            Console.Write(matrix[row][col]);
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void PrintRotation180(int rotation, int maxLenght, char[][] matrix)
        {
            if (rotation == 180)
            {
                for (int row = matrix.Length - 1; row >= 0; row--)
                {
                    for (int col = maxLenght - 1; col >= 0; col--)
                    {
                        if (col >= matrix[row].Length)
                        {
                            Console.Write(" ");
                            continue;
                        }
                        else
                        {
                            Console.Write(matrix[row][col]);
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void PrintRotation270(int rotation, int maxLenght, char[][] matrix)
        {
            if (rotation == 270)
            {
                for (int col = maxLenght - 1; col >= 0; col--)
                {
                    for (int row = 0; row < matrix.Length; row++)
                    {
                        if (col >= matrix[row].Length)
                        {
                            Console.Write(" ");
                            continue;
                        }
                        else
                        {
                            Console.Write(matrix[row][col]);
                        }
                    }
                    Console.WriteLine();
                }
            }
        }  
    }
}
