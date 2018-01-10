﻿using Elo_Tracker.Models;
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
            AddPlayerCommand = new RelayCommand(AddPlayerExecute, AddPlayerCanExecute);
        }

        private void AddPlayerExecute()
        {
            Player newPlayer = Player.CreateNewPlayer(PlayerName);
            PlayerAdded?.Invoke(newPlayer);
            PlayerName = "";
        }
        private bool AddPlayerCanExecute()
        {
            return PlayerName != "";
        }        
    }
}
