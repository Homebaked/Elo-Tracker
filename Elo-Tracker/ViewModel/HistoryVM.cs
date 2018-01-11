using Elo_Tracker.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elo_Tracker.ViewModel
{
    public class HistoryVM : ViewModelBase
    {
        private History totalHistory;

        private History _activeHistory;
        public History ActiveHistory
        {
            get
            {
                return _activeHistory;
            }
            set
            {
                _activeHistory = value;
                RaisePropertyChanged("ActiveHistory");
            }
        }

        public HistoryVM(History history)
        {
            totalHistory = history;
            ActiveHistory = totalHistory;
        }
    }
}
