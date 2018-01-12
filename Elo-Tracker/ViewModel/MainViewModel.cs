using Elo_Tracker.Models;
using Elo_Tracker.Utilities;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Elo_Tracker.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public History History { get; }

        private ObservableCollection<Player> _players;
        public ReadOnlyObservableCollection<Player> Players
        {
            get
            {
                return new ReadOnlyObservableCollection<Player>(_players);
            }
        }

        public AddPlayerVM AddPlayerVM { get; private set; }
        public AddGameVM AddGameVM { get; private set; }
        public HistoryVM HistoryVM { get; private set; }

        public MainViewModel()
        {
            this.History = new History();
            this._players = new ObservableCollection<Player>();
            AddPlayerVM = new AddPlayerVM();
            AddPlayerVM.PlayerAdded += addNewPlayer;
            AddGameVM = new AddGameVM(Players);
            AddGameVM.GameAdded += addNewGame;
            HistoryVM = new HistoryVM(this.History, Players);
        }

        private void addNewPlayer(Player player)
        {
            _players.Add(player);
            _players.Sort(Player.compareScores);
        }

        private void addNewGame(Game game)
        {
            History.AddGame(game);
        }
    }
}