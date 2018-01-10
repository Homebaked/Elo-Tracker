using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elo_Tracker.Models
{
    public class Player
    {
        public readonly Guid Guid;

        public readonly string Name;

        public int Score { get; private set; }

        private Player(string name, int score = 1200, Guid? guid = null)
        {
            this.Name = name;
            this.Score = score;
            if (guid.HasValue)
            {
                this.Guid = guid.Value;
            }
            else
            {
                Guid = Guid.NewGuid();
            }
            
        }

        public static Player CreateNewPlayer(string name)
        {
            return new Player(name);
        }

        public static Player CreateExistingPlayer(string name, int score, Guid guid)
        {
            return new Player(name, score, guid);
        }
    }
}
