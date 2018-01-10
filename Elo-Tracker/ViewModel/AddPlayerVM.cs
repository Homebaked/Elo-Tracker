using Elo_Tracker.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Elo_Tracker.ViewModel
{
    public class AddPlayerVM : ViewModelBase
    {
        private Random rand;

        private string _playerName;

        public string PlayerName
        {
            get { return _playerName; }
            set
            {
                _playerName = value;
                RaisePropertyChanged("PlayerName");
            }
        }

        public ICommand AddPlayerCommand { get; private set; }

        public event Action<Player> PlayerAdded;

        public AddPlayerVM()
        {
            _playerName = "";
            AddPlayerCommand = new RelayCommand(addPlayerExecute, addPlayerCanExecute);
            rand = new Random();
        }

        private void addPlayerExecute()
        {
            Player newPlayer = Player.CreateNewPlayer(PlayerName);
            newPlayer.SetScore(rand.Next(0, 2000));
            PlayerAdded?.Invoke(newPlayer);
            PlayerName = "";
        }
        private bool addPlayerCanExecute()
        {
            return PlayerName != "";
        }        
    }
}
