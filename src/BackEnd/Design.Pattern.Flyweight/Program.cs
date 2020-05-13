using Design.Pattern.Flyweight.Flyweight;
using System;

namespace Design.Pattern.Flyweight
{
    class Program
    {
        public static string[] PlayerType = { "Terrorist", "CounterTerrorist" };
        public static string[] Weapons = { "AK-47", "AWP", "Desert Eagle", "M4A4", "P90", "SSG 08", "MP7" };
        public static string[] PoliceObjective = { "Desarmar Bomba", "Salvar Reféns" };
        public static string[] TerroristObjective = { "Armar Bomba", "Pegar Reféns" };

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var playerFactory = new PlayerFactory();
            var playersMapFactory = new PlayersMapFactory();
            for (int i = 0; i < 10; i++)
            {
                var player = playerFactory.GetPlayer(GetPlayerType());
                player.AssignWeapon(GetWeapons());
                if (player.IsTerrorist())
                    player.Mission(GetTerroristObjective());
                else
                    player.Mission(GetPoliceObjective());

                playersMapFactory.AddPlayer(i+1, player);
            }
            Console.WriteLine($"Terroristas: {playersMapFactory.GetTerrorist()}");
            Console.WriteLine($"Policiais: {playersMapFactory.GetPolice()}");
            playersMapFactory.ShowPlayers();

            Console.ReadKey();
        }

        private static string GetPlayerType()
        {
            return PlayerType[new Random().Next(PlayerType.Length)];
        }

        private static string GetWeapons()
        {
            return Weapons[new Random().Next(Weapons.Length)];
        }
        private static string GetPoliceObjective()
        {
            return PoliceObjective[new Random().Next(PoliceObjective.Length)];
        }
        private static string GetTerroristObjective()
        {
            return TerroristObjective[new Random().Next(TerroristObjective.Length)];
        }
    }
}
