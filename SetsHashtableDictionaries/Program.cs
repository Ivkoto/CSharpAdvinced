namespace SetsHashtableDictionaries
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            //E01_ParkingLot();
            //E02_SoftuniParty();
            //E04_CountSameValuesArray();
            //E05_AcademyGraduation();
        }

        private static void E05_AcademyGraduation()
        {
            int numStudent = int.Parse(Console.ReadLine());
            var dict = new SortedDictionary<string, double[]>();

            for (int i = 0; i < numStudent; i++)
            {
                var name = Console.ReadLine();
                var scores = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();
                dict.Add(name, scores);
            }

            foreach (var student in dict)
            {
                Console.WriteLine($"{student.Key} is graduated with {student.Value.Average()}");
            }
        }

        private static void E04_CountSameValuesArray()
        {
            double[] input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            SortedDictionary<double, int> dict = new SortedDictionary<double, int>();

            foreach (var item in input)
            {
                if (!dict.ContainsKey(item))
                {
                    dict.Add(item, 1);
                }
                else
                {
                    dict[item]++;
                }
            }

            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        } 

        private static void E02_SoftuniParty()
        {
            var reservations = new SortedSet<string>();
            var input = Console.ReadLine();

            while (input != "PARTY")
            {
                reservations.Add(input);
                input = Console.ReadLine();
            }

            while (input != "END")
            {
                reservations.Remove(input);
                input = Console.ReadLine();
            }

            Console.WriteLine(reservations.Count);
            foreach (var gest in reservations)
            {
                Console.WriteLine(gest);
            }
        }

        private static void E01_ParkingLot()
        {
            var input = Console.ReadLine();
            var parking = new SortedSet<string>();

            while (input != "END")
            {
                var parameters = Regex.Split(input, ", ");
                if (parameters[0] == "IN")
                {
                    parking.Add(parameters[1]);
                }
                else
                {
                    parking.Remove(parameters[1]);
                }
                input = Console.ReadLine();
            }

            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car.Trim());
                }
            }
        }
    }
}
