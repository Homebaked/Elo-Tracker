using Elo_Tracker.Models;
using Elo_Tracker.ObjectSerializers;
using Elo_Tracker.Utilities;
using GalaSoft.MvvmLight;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
            loadExecute();
        }

        private void addNewPlayer(Player player)
        {
            _players.Add(player);
            _players.Sort(Player.compareScores);
            saveExecute();
        }

        private void addNewGame(Game game)
        {
            History.AddGame(game);
            //saveExecute();
        }

        private void saveExecute()
        {
            string playerSaveFile = Path.Combine(dataDir, "players.elo");
            List<PlayerSerializer> pSerials = PlayerSerializer.SerializeList(Players);
            Serializer<PlayerSerializer>.Save(pSerials, playerSaveFile);

            string gameSaveFile = Path.Combine(dataDir, "games.elo");
            //Serializer<Game>.Save(History.GameHistory, gameSaveFile);
        }
        private void loadExecute()
        {
            string playerSaveFile = Path.Combine(dataDir, "players.elo");
            if (!File.Exists(playerSaveFile)) return;
            IEnumerable<PlayerSerializer> pSerials = Serializer<PlayerSerializer>.Load(playerSaveFile);
            _players = new ObservableCollection<Player>(PlayerSerializer.UnserializeList(pSerials));
            RaisePropertyChanged("Players");

            string gameSaveFile = Path.Combine(dataDir, "games.elo");
            //History.Refresh(Serializer<Game>.Load(gameSaveFile));
        }

        private static string dataDir
        {
            get
            {
                string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string dir = Path.Combine(appData, "ELO/");
                return dir;
            }
        }
    }
}