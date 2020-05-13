using Design.Pattern.Flyweight.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Design.Pattern.Flyweight.Flyweight
{
    public class PlayersMapFactory
    {
        public PlayersMapFactory()
        {
            Players = new Dictionary<int, IPlayer>();
        }

        private Dictionary<int, IPlayer> Players { get; set; }

        public bool AddPlayer(int position, IPlayer player)
        {
            if (Players.ContainsKey(position))
                return false;
            else
                Players.Add(position, player);
            return true;
        }

        public int GetTerrorist()
        {
            return Players.Values.Count(x => x.IsTerrorist());
        }

        public int GetPolice()
        {
            return Players.Values.Count(x => !x.IsTerrorist());
        }

        public void ShowPlayers()
        {
            foreach (var item in Players)
            {
                Console.WriteLine($"Jogador {item.Key}");
                item.Value.Show();
            }
        }
    }
}
