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
        private ObservableCollection<Game> _gameHistory;
        public ReadOnlyObservableCollection<Game> GameHistory
        {
            get
            {
                return new ReadOnlyObservableCollection<Game>(_gameHistory);
            }
        }

        public History(IEnumerable<Game> history = null)
        {
            if (history == null)
            {
                _gameHistory = new ObservableCollection<Game>();
            }
            else
            {
                _gameHistory = new ObservableCollection<Game>(history);
            }
        }

        public void AddGame(Game game)
        {
            _gameHistory.Add(game);
        }
    }
}
