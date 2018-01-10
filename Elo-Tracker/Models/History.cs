using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elo_Tracker.Models
{
    public class History
    {
        public List<Game> GameHistory;

        public History(List<Game> history = null)
        {
            if (history == null)
            {
                GameHistory = new List<Game>();
            }
        }

        public void AddGame(Game game)
        {
            GameHistory.Add(game);
        }
    }
}
