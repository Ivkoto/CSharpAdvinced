using System;
using System.Collections.Generic;
using System.Text;

namespace January_2020
{
    public class SetsAndDictationaries
    {
        public static void UniqueUsernames()
        {
            var usernames = new HashSet<string>();

            var inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                var curName = Console.ReadLine();
                usernames.Add(curName);
            }

            Console.WriteLine($"The inputed name are:\n{string.Join(Environment.NewLine, usernames)}");

            //foreach (var name in usernames)
            //{
            //    Console.WriteLine(name);
            //}
        }
    }
}
