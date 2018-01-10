using Elo_Tracker.Models;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        public ObservableCollection<Player> Players { get; private set; }
        public AddPlayerVM AddPlayerVM { get; private set; }

        public MainViewModel()
        {
            this.Players = new ObservableCollection<Player>();
            AddPlayerVM = new AddPlayerVM();
        }


    }
}