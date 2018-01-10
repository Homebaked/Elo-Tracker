using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elo_Tracker.Models
{
    public class History
    {
        public ObservableCollection<Game> GameHistory { get; private set; }

        public History(IEnumerable<Game> history = null)
        {
            if (history == null)
            {
                GameHistory = new ObservableCollection<Game>();
            }
            else
            {
                GameHistory = new ObservableCollection<Game>(history);
            }
        }

        public void AddGame(Game game)
        {
            GameHistory.Add(game);
        }
    }
}
