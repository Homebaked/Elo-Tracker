using Elo_Tracker.Models;
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
        private ObservableCollection<Player> _players;
        public ObservableCollection<Player> Players
        {
            get
            {
                return _players;
            }
            private set
            {
                _players = value;
                RaisePropertyChanged("Players");
            }
        }

        public AddPlayerVM AddPlayerVM { get; private set; }

        public MainViewModel()
        {
            this.Players = new ObservableCollection<Player>();
            AddPlayerVM = new AddPlayerVM();
            AddPlayerVM.PlayerAdded += addNewPlayer;
        }

        private void addNewPlayer(Player player)
        {
            Players.Add(player);
            Players = new ObservableCollection<Player>(Players.OrderByDescending(x => x.Score));
        }
    }
}