namespace SetsAndDictionariesExercises
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            //E01_UniqueUsernames();
            //E02_SetsOfElements();
            //E03_PeriodicTable();
            //E04_CountSymbols();
            //E05_Phonebook();
            //E06_MinerTask();
            //E07_FixEmails();
            //E08_HandsOfCard();
            //E09_UserLogs();
            //E10_PopulationCounter();
            //E11_LogsAggregator();
            //E12_LegendaryFarming();
            //E13_SerbianUnleashed();
            //E14_DragonArmy();
        }

        private static void E14_DragonArmy()
        {
            var dragons = new Dictionary<string, SortedDictionary<string, List<int>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                var type = input[0];
                var name = input[1];
                var damage = CheckIsNull("damage", input[2]);
                var health = CheckIsNull("health", input[3]);
                var armur = CheckIsNull("armur", input[4]);

                List<int> statusList = new List<int>() { damage, health, armur };

                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new SortedDictionary<string, List<int>> { { name, statusList } });
                }
                else
                {
                    if (!dragons[type].ContainsKey(name))
                    {
                        dragons[type].Add(name, statusList);
                    }
                    else
                    {
                        dragons[type][name] = statusList;
                    }
                }

            }
            printResult(dragons);
        }

        private static void printResult(Dictionary<string, SortedDictionary<string, List<int>>> dragons)
        {
            foreach (var type in dragons)
            {
                var dragonStatusInfo = new StringBuilder();
                double avgDamage = 0, avgHealth = 0, avgArmur = 0;
                foreach (var dragon in type.Value)
                {
                    dragonStatusInfo.Append($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}\r\n");
                    avgDamage += dragon.Value[0];
                    avgHealth += dragon.Value[1];
                    avgArmur += dragon.Value[2];
                }
                avgDamage /= type.Value.Count;
                avgHealth /= type.Value.Count;
                avgArmur /= type.Value.Count;

                Console.WriteLine($"{type.Key}::({avgDamage :f2}/{avgHealth :f2}/{avgArmur :f2})");
                Console.Write(dragonStatusInfo.ToString());
            }
        }

        private static int CheckIsNull(string status, string inputValue)
        {
            int calculatedValue = 0;

            if (!inputValue.Equals("null"))
            {
                calculatedValue = int.Parse(inputValue);
            }
            else
            {
                switch (status)
                {
                    case "damage": calculatedValue = 45; break;
                    case "health": calculatedValue = 250; break;
                    case "armur": calculatedValue = 10; break;
                }
            }
            return calculatedValue;
        }
        //end E14

        private static void E13_SerbianUnleashed()
        {
            var input = string.Empty;
            var dict = new Dictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    var singerVenueTicketPrice = input.Split(new string[] { " @" }, StringSplitOptions.RemoveEmptyEntries);

                    if (singerVenueTicketPrice.Length != 2)
                    {                        
                        continue;
                    }
                    var singer = singerVenueTicketPrice[0];
                    var venuesTickets = singerVenueTicketPrice[1].Split(' ');
                    var venus = string.Join(" ", venuesTickets.Take(venuesTickets.Length - 2));
                    var tickets = int.Parse(venuesTickets[venuesTickets.Length - 2]);
                    var price = int.Parse(venuesTickets[venuesTickets.Length - 1]);
                    var totalPrice = price * tickets;

                    if (!dict.ContainsKey(venus))
                    {
                        dict.Add(venus, new Dictionary<string, int> { { singer, totalPrice } });
                    }
                    else
                    {
                        if (!dict[venus].ContainsKey(singer))
                        {
                            //dict[venus].Add(singer, totalPrice);
                            dict[venus][singer] = totalPrice;
                        }
                        else
                        {
                            dict[venus][singer] += totalPrice;
                        }
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}");
                Console.WriteLine("{0}", string.Join("\n", item.Value.OrderByDescending(v => v.Value).Select(v => $"#  {v.Key} -> {v.Value}")));
            }
        }

        private static void E12_LegendaryFarming()
        {
            var keyMaterials = new Dictionary<string, long>() { { "shards", 0 }, { "fragments", 0 }, { "motes", 0 } };
            var junk = new SortedDictionary<string, long>();
            bool isObtained = false;

            while (!isObtained)
            {
                var materials = Console.ReadLine().ToLower().Split(' ');

                for (int i = 0; i < materials.Length; i += 2)
                {
                    var material = materials[i + 1];
                    var quantity = int.Parse(materials[i]);

                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        keyMaterials[material] += quantity;

                        if (keyMaterials[material] >= 250)
                        {
                            switch (material)
                            {
                                case "shards": Console.WriteLine("Shadowmourne obtained!"); break;
                                case "fragments": Console.WriteLine("Valanyr obtained!"); break;
                                case "motes": Console.WriteLine("Dragonwrath obtained!"); break;
                            }
                            keyMaterials[material] -= 250;
                            isObtained = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!junk.ContainsKey(material))
                        {
                            junk.Add(material, quantity);
                        }
                        else
                        {
                            junk[material] += quantity;
                        }
                    }
                }
            }
            foreach (var m in keyMaterials.OrderByDescending(m => m.Value).ThenBy(m => m.Key))
            {
                Console.WriteLine($"{m.Key}: {m.Value}");
            }
            foreach (var j in junk)
            {
                Console.WriteLine($"{j.Key}: {j.Value}");
            }
        }

        private static void E11_LogsAggregator()
        {
            var orderLines = int.Parse(Console.ReadLine());
            var sesions = new SortedDictionary<string, SortedDictionary<string, int>>();
            for (int i = 0; i < orderLines; i++)
            {
                var input = Console.ReadLine().Split(' ');
                var ip = input[0];
                var user = input[1];
                var duration = int.Parse(input[2]);

                if (!sesions.ContainsKey(user))
                {
                    sesions[user] = new SortedDictionary<string, int>() { { ip, duration } };
                }
                else
                {
                    if (!sesions[user].ContainsKey(ip))
                    {
                        sesions[user][ip] = duration;
                    }
                    else
                    {
                        sesions[user][ip] += duration;
                    }
                }
            }
            foreach (var s in sesions)
            {
                Console.WriteLine("{0}: {1} [{2}]", s.Key, s.Value.Values.Sum(), string.Join(", ", s.Value.Select(v => v.Key)));
            }
        }

        private static void E10_PopulationCounter()
        {
            var input = Console.ReadLine();
            var dict = new Dictionary<string, Dictionary<string, long>>();
            while (input != "report")
            {
                var values = input.Split('|');
                var city = values[0];
                var country = values[1];
                var population = long.Parse(values[2]);

                if (!dict.ContainsKey(country))
                {
                    dict[country] = new Dictionary<string, long>() { { city, population } };
                }
                else
                {
                    dict[country][city] = population;
                }

                input = Console.ReadLine();
            }
            foreach (var country in dict.OrderByDescending(c => c.Value.Values.Sum()))
            {
                Console.WriteLine("{0} (total population: {1})", country.Key, country.Value.Values.Sum());
                Console.WriteLine("{0}", string.Join("\n", country.Value.OrderByDescending(c => c.Value).Select(c => $"=>{c.Key}: {c.Value}")));
            }
        }

        private static void E09_UserLogs()
        {
            var input = Console.ReadLine();
            var sortDict = new SortedDictionary<string, Dictionary<string, int>>();
            while (input != "end")
            {
                var inputValues = Regex.Split(input, " ");

                var user = inputValues[2].Remove(0, 5);
                var ip = inputValues[0].Remove(0, 3);

                if (sortDict.ContainsKey(user))
                {
                    if (sortDict[user].ContainsKey(ip))
                    {
                        sortDict[user][ip] += 1;
                    }
                    else
                    {
                        sortDict[user][ip] = 1;
                    }
                }
                else
                {
                    sortDict[user] = new Dictionary<string, int>() { { ip, 1 } };
                    //dict.Add(user, new Dictionary<string, int>() { { ip, 1 } });
                }

                input = Console.ReadLine();
            }
            PrintUserIpCount(sortDict);
        }

        private static void PrintUserIpCount(SortedDictionary<string, Dictionary<string, int>> sortDict)
        {
            foreach (var ithem in sortDict)
            {
                Console.WriteLine($"{ithem.Key}:");
                Console.WriteLine("{0}.", string.Join(", ", ithem.Value.Select(d => $"{d.Key} => {d.Value}")));
            }
        }
        //end E09

        private static void E08_HandsOfCard()
        {
            var input = Console.ReadLine();
            var players = new Dictionary<string, HashSet<string>>();
            while (input != "JOKER")
            {
                var index = input.IndexOf(":");
                var name = input.Substring(0, index);
                var cards = input.Substring(index + 1).Trim()
                    .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (players.ContainsKey(name))
                {
                    players[name].UnionWith(cards);
                }
                else
                {
                    players[name] = new HashSet<string>(cards);
                }
                input = Console.ReadLine();
            }

            PrintResult(players);
        }

        private static void PrintResult(Dictionary<string, HashSet<string>> players)
        {

            foreach (var player in players)
            {
                var score = scoreCalculation(player.Value);
                Console.WriteLine($"{player.Key}: {score}");
            }
        }

        private static int scoreCalculation(HashSet<string> cards)
        {
            int scores = 0;
            foreach (var card in cards)
            {
                var power = card.Substring(0, card.Length - 1);
                var type = card.Last();

                int score;
                var digit = int.TryParse(power, out score);
                if (!digit)
                {
                    switch (power)
                    {
                        case "J": score = 11; break;
                        case "Q": score = 12; break;
                        case "K": score = 13; break;
                        case "A": score = 14; break;
                    }
                }
                switch (type)
                {
                    case 'S': score *= 4; break;
                    case 'H': score *= 3; break;
                    case 'D': score *= 2; break;
                    case 'C': score *= 1; break;
                }
                scores += score;
            }
            return scores;
        }

        //end E08

        private static void E07_FixEmails()
        {
            var name = Console.ReadLine();
            var dict = new Dictionary<string, string>();
            while (name != "stop")
            {
                var email = Console.ReadLine();
                if (!dict.ContainsKey(name) && !(email.EndsWith("us") || email.EndsWith("uk")))
                {
                    dict.Add(name, email);
                }
                else if (dict.ContainsKey(name) && !(email.EndsWith("us", StringComparison.InvariantCultureIgnoreCase) || email.EndsWith("uk", StringComparison.InvariantCultureIgnoreCase)))
                {
                    dict[name] = email;
                }
                name = Console.ReadLine();
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }

        private static void E06_MinerTask()
        {
            var dict = new Dictionary<string, Int32>();
            var resource = Console.ReadLine();
            while (resource != "stop")
            {
                var quantity = Int32.Parse(Console.ReadLine());
                if (!dict.ContainsKey(resource))
                {
                    dict.Add(resource, quantity);
                }
                else
                {
                    dict[resource] += quantity;
                }
                resource = Console.ReadLine();
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }

        private static void E05_Phonebook()
        {
            var input = Console.ReadLine().Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            var phoneDict = new Dictionary<string, string>();
            //input or update contacts
            while (input[0] != "search")
            {
                if (!phoneDict.ContainsKey(input[0]))
                {
                    phoneDict.Add(input[0], input[1]);
                }
                else
                {
                    phoneDict[input[0]] = input[1];
                }

                input = Console.ReadLine().Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            }
            var name = Console.ReadLine();
            //search contacts
            while (name != "stop")
            {
                if (phoneDict.ContainsKey(name))
                {
                    var searchedContact = phoneDict.Where(c => c.Key.Equals(name)).First();
                    Console.WriteLine($"{searchedContact.Key} -> {searchedContact.Value}");

                }
                else
                {
                    Console.WriteLine($"Contact {name} does not exist.");
                }
                name = Console.ReadLine();
            }
        }

        private static void E04_CountSymbols()
        {
            var text = Console.ReadLine().ToCharArray();
            var list = new SortedList<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                var element = text[i];
                if (!list.ContainsKey(element))
                {
                    list.Add(element, 0);

                    for (int j = 0; j < text.Length; j++)
                    {
                        if (element == text[j])
                        {
                            list[element]++;
                        }
                    }
                }

            }

            foreach (var item in list)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }

        }

        private static void E03_PeriodicTable()
        {

            var count = Convert.ToInt32(Console.ReadLine());
            var set = new List<string>();

            for (int i = 0; i < count; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < elements.Count(); j++)
                {
                    if (!set.Contains(elements[j]))
                    {
                        set.Add(elements[j]);
                    }
                }
            }

            foreach (var item in set)
            {
                Console.Write($"{item} ");
            }
        }

        private static void E02_SetsOfElements()
        {
            int[] input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var setOne = new SortedSet<int>();
            var setTwo = new SortedSet<int>();

            for (int i = 0; i < input[0]; i++)
            {
                var number = int.Parse(Console.ReadLine());
                if (!setOne.Contains(number))
                {
                    setOne.Add(number);
                }
            }

            for (int j = 0; j < input[1]; j++)
            {
                var number = int.Parse(Console.ReadLine());
                if (!setTwo.Contains(number))
                {
                    setTwo.Add(number);
                }
            }

            var count = input[0] + input[1];

            foreach (var num1 in setOne)
            {
                foreach (var num2 in setTwo)
                {
                    if (num2 == num1)
                    {
                        Console.Write($"{num2}  ");
                    }
                }
            }
        }

        private static void E01_UniqueUsernames()
        {
            int nLines = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            var count = 0;
            for (int i = 0; i < nLines; i++)
            {
                var name = Console.ReadLine();
                if (!queue.Contains(name))
                {
                    queue.Enqueue(name);
                    count++;
                }
            }
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
