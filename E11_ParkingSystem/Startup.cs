namespace E11_ParkingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Cell
    {
        public int Row { get; set; }

        public int Col { get; set; }
    }

    class Startup
    {
        static void Main()
        {
            var parkingDimentions = ParkingDimentions();

            var usedCells = new HashSet<Cell>();

            var input = Console.ReadLine().Split(' ');
            while (input[0] != "stop")
            {
                var entryRow = int.Parse(input[0]);
                var parkingLot = new Cell
                {
                    Row = int.Parse(input[1]),
                    Col = int.Parse(input[2])
                };

                if (IsCarParked(parkingLot, usedCells, parkingDimentions))
                {
                    Console.WriteLine(Math.Abs(entryRow - parkingLot.Row) + 1 + parkingLot.Col);
                    usedCells.Add(parkingLot);
                }
                else
                {
                    Console.WriteLine($"Row {parkingLot.Row} full");
                }

                input = Console.ReadLine().Split(' ');
            }
        }

        private static bool IsCarParked(Cell parkingLot, HashSet<Cell> usedCells, int[] parkingDimentions)
        {
            if (usedCells
                .Where(c => c.Row == parkingLot.Row && c.Col == parkingLot.Col)
                .FirstOrDefault() == null)
            {
                return true;
            }

            var testCounter = 1;

            while (true)
            {
                var checkLeft = parkingLot.Col - testCounter;
                var checkRight = parkingLot.Col + testCounter;

                
                if (checkLeft <= 0 && checkRight >= parkingDimentions[1])
                {
                    break;
                }

                if (checkLeft > 0 && usedCells
                    .Where(c => c.Row == parkingLot.Row && c.Col == checkLeft)
                    .FirstOrDefault() == null)
                {
                    parkingLot.Col = checkLeft;
                    return true;
                }

                if (checkRight < parkingDimentions[1] && usedCells
                    .Where(c => c.Row == parkingLot.Row && c.Col == checkRight)
                    .FirstOrDefault() == null)
                {
                    parkingLot.Col = checkRight;
                    return true;
                }

                testCounter++;
            }

            return false;
        }

        private static int[] ParkingDimentions()
        {
            var rowsCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            return new int[] { rowsCols[0], rowsCols[1] };
        }
    }
}
