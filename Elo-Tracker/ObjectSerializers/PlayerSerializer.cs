using Elo_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elo_Tracker.ObjectSerializers
{
    public class PlayerSerializer
    {
        public readonly Guid Guid;
        public readonly string Name;
        public readonly int Score;

        public PlayerSerializer() { }

        public PlayerSerializer(Player player)
        {
            Guid = player.Guid;
            Name = player.Name;
            Score = player.Score;
        }

        public Player GetPlayer()
        {
            return Player.CreateExistingPlayer(Name, Score, Guid);
        }

        public static List<PlayerSerializer> SerializeList(IEnumerable<Player> players)
        {
            List<PlayerSerializer> pSerials = new List<PlayerSerializer>();
            foreach(Player player in players)
            {
                pSerials.Add(new PlayerSerializer(player));
            }
            return pSerials;
        }

        public static List<Player> UnserializeList(IEnumerable<PlayerSerializer> pSerials)
        {
            List<Player> players = new List<Player>();
            foreach(PlayerSerializer pSerial in pSerials)
            {
                players.Add(pSerial.GetPlayer());
            }
            return players;
        }
    }
}
