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

        public string Name { get; }

        public int Score { get; private set; }

        private Player() { }
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

        public void SetScore(int score)
        {
            this.Score = score;
        }

        public static int compareScores(Player p1, Player p2)
        {
            if (p1.Score > p2.Score)
            {
                return 1;
            }
            else if (p1.Score < p2.Score)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        
    }
}
