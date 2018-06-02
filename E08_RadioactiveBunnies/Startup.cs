namespace E08_RadioactiveBunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Startup
    {
        static void Main()
        {
            int[] playerPosition;

            var bunnies = InitializeMatrix(out playerPosition);

            RunTheGame(bunnies, playerPosition);
        }

        private static void RunTheGame(bool[][] bunnies, int[] playerPosition)
        {
            //while (true)
            //{
            var playerMoves = Console.ReadLine().ToCharArray();
            var isPlayerEscaped = false;

            foreach (var move in playerMoves)
            {
                isPlayerEscaped = IsPlayerEscape(bunnies, playerPosition, move);
                MultiplyBunnies(bunnies);

                if (isPlayerEscaped)
                {
                    PrinBunniesMatrix(bunnies);
                    Console.WriteLine($"won: {playerPosition[0]} {playerPosition[1]}");
                    return;
                }
                if (bunnies[playerPosition[0]][playerPosition[1]])
                {
                    PrinBunniesMatrix(bunnies);
                    Console.WriteLine($"dead: {playerPosition[0]} {playerPosition[1]}");
                    return;
                }
            }
        }

        private static void MultiplyBunnies(bool[][] bunnies)
        {
            var newBunnies = new Stack<int[]>();
            for (int row = 0; row < bunnies.Length; row++)
            {
                for (int col = 0; col < bunnies[row].Length; col++)
                {
                    if (bunnies[row][col])
                    {
                        newBunnies.Push(new int[] { row + 1, col });
                        newBunnies.Push(new int[] { row - 1, col });
                        newBunnies.Push(new int[] { row, col + 1 });
                        newBunnies.Push(new int[] { row, col - 1 });
                    }
                    
                }
            }

            while (newBunnies.Count > 0)
            {
                var getBunny = newBunnies.Pop();
                if (IsInsideTheLayer(getBunny, bunnies))
                {
                    bunnies[getBunny[0]][getBunny[1]] = true;
                }
            }
        }

        private static void PrinBunniesMatrix(bool[][] bunnies)
        {
            var result = new StringBuilder();

            for (int row = 0; row < bunnies.Length; row++)
            {
                for (int col = 0; col < bunnies[row].Length; col++)
                {
                    result.Append(bunnies[row][col] ? 'B' : '.');
                }
                result.Append(Environment.NewLine);
            }
            Console.WriteLine(result.ToString().Trim());
        }

        private static bool IsPlayerEscape(bool[][] bunnies, int[] playerPosition, char move)
        {
            switch (move)
            {
                case 'U':
                    playerPosition[0]--;
                    if (!IsInsideTheLayer(playerPosition, bunnies))
                    {
                        playerPosition[0]++;
                        return true;
                    }
                    break;
                case 'D':
                    playerPosition[0]++;
                    if (!IsInsideTheLayer(playerPosition, bunnies))
                    {
                        playerPosition[0]--;
                        return true;
                    }
                    break;
                case 'L':
                    playerPosition[1]--;
                    if (!IsInsideTheLayer(playerPosition, bunnies))
                    {
                        playerPosition[1]++;
                        return true;
                    }
                    break;
                case 'R':
                    playerPosition[1]++;
                    if (!IsInsideTheLayer(playerPosition, bunnies))
                    {
                        playerPosition[1]--;
                        return true;
                    }
                    break;
            }
            return false;
        }

        private static bool IsInsideTheLayer(int[] position, bool[][] matrix)
        {
            return position[0] >= 0 && position[0] < matrix.Length && position[1] >= 0 && position[1] < matrix[0].Length;
        }

        private static bool[][] InitializeMatrix(out int[] playerPosition)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            playerPosition = new int[] { 0, 0 };

            var bunnies = new bool[dimensions[0]][];

            for (int i = 0; i < bunnies.Length; i++)
            {
                var input = Console.ReadLine();
                bunnies[i] = new bool[input.Length];

                for (int j = 0; j < bunnies[i].Length; j++)
                {
                    if (input[j] == 'B')
                    {
                        bunnies[i][j] = true;
                    }
                    else if (input[j] == 'P')
                    {
                        playerPosition[0] = i;
                        playerPosition[1] = j;
                    }
                }
            }

            return bunnies;
        }
    }
}
