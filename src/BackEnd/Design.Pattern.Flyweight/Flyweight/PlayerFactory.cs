using Design.Pattern.Flyweight.Interfaces;
using Design.Pattern.Flyweight.Model;
using System.Collections.Generic;

namespace Design.Pattern.Flyweight.Flyweight
{
    public class PlayerFactory
    {
        public PlayerFactory()
        {
            Players = new Dictionary<string, IPlayer>();
        }

        private Dictionary<string, IPlayer> Players { get; set; }

        public IPlayer GetPlayer(string type)
        {
            if (Players.ContainsKey(type))
                return Players[type];
            else
            {
                switch (type.ToUpper())
                {
                    case "TERRORIST":
                        Players.Add(type, new Terrorist());
                        return Players[type];
                    case "COUNTERTERRORIST":
                        Players.Add(type, new CounterTerrorist());
                        return Players[type];
                    default:
                        throw new KeyNotFoundException();
                }
            }
        }
    }
}
