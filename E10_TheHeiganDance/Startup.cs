namespace E10_TheHeiganDance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PLayer
    {
        public int HitPoints { get; set; }

        public int[] Position { get; set; }

        public double Damage { get; set; }

        public bool IsHitByCloud { get; set; }
    }

    class Startup
    {
        static double heiganHitPoints = 3000000;
        static string spell = string.Empty;
        static int hitRow;
        static int hitCol;

        static void Main()
        {
            var player = new PLayer
            {
                HitPoints = 18500,
                Damage = double.Parse(Console.ReadLine()),
                Position = new int[] { 7, 7 },
                IsHitByCloud = false
            };

            StartDansing(player);

        }

        private static void StartDansing(PLayer player)
        {
            while (true)
            {
                if (player.IsHitByCloud)
                {
                    player.HitPoints -= 3500;
                    player.IsHitByCloud = false;
                }

                heiganHitPoints -= player.Damage;

                if (IsGameOver(player))
                {
                    break;
                }

                var heiganAttac = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                spell = heiganAttac[0];
                hitRow = int.Parse(heiganAttac[1]);
                hitCol = int.Parse(heiganAttac[2]);

                if (IsPlayerAffected(player.Position[0], player.Position[1], hitRow, hitCol)
                    && IsPLayerCantMove(player, hitRow, hitCol))
                {
                    switch (spell)
                    {
                        case "Cloud":
                            player.HitPoints -= 3500;
                            player.IsHitByCloud = true;
                            break;
                        case "Eruption":
                            player.HitPoints -= 6000;
                            break;
                        default:
                            break;
                    }
                }

                if (IsGameOver(player))
                {
                    break;
                }
                
            }
        }

        private static bool IsPLayerCantMove(PLayer player, int hitRow, int hitCol)
        {
            //try move up
            if (player.Position[0] > 0 && !IsPlayerAffected(player.Position[0] - 1, player.Position[1], hitRow, hitCol))
            {
                player.Position[0]--;
                return false;
            }
            //try move right
            if (player.Position[1] < 14 && !IsPlayerAffected(player.Position[0], player.Position[1] + 1, hitRow, hitCol))
            {
                player.Position[1]++;
                return false;
            }
            //try move down
            if (player.Position[0] < 14 && !IsPlayerAffected(player.Position[0] + 1, player.Position[1], hitRow, hitCol))
            {
                player.Position[0]++;
                return false;
            }
            //try move left
            if (player.Position[1] > 0 && !IsPlayerAffected(player.Position[0], player.Position[1] - 1, hitRow, hitCol))
            {
                player.Position[1]--;
                return false;
            }

            return true;
        }

        private static bool IsPlayerAffected(int pRow, int pCol, int hitRow, int hitCol)
        {
            return (pRow >= hitRow - 1) && (pRow <= hitRow + 1) && (pCol >= hitCol - 1) && (pCol <= hitCol + 1);
        }

        private static bool IsGameOver(PLayer player)
        {
            if (player.HitPoints <= 0 || heiganHitPoints <= 0)
            {
                if (spell == "Cloud")
                {
                    spell = "Plague Cloud";
                }

                Console.WriteLine(heiganHitPoints > 0 ? $"Heigan: {heiganHitPoints:f2}" : $"Heigan: Defeated!");
                Console.WriteLine(player.HitPoints > 0 ? $"Player: {player.HitPoints}" : $"Player: Killed by {spell}");
                Console.WriteLine($"Final position: {player.Position[0]}, {player.Position[1]}");

                return true;
            }
            return false;
        }
    }
}