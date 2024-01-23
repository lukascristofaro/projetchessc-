using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand createRoomViewCommand { get; set; }

        createroomViewModel createRoomView { get; set; }

        private object m_currentView;

        public object CurrentView
        {
            get { return m_currentView; }
            set 
            { 
                m_currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            createRoomView = new createroomViewModel();


            CurrentView = createRoomView;

        }
    }
}