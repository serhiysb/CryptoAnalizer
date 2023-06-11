using CryptoAnalizer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAnalizer.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public GeneralViewModel GeneralViewModel { get; set; }
        public CurrencyViewModel CurrencyViewModel { get; set; }

        public RelayCommand GeneralViewCommand { get; set; }
        public RelayCommand CurrencyViewCommand{ get; set; }

        private object _currentView = new GeneralViewModel();

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            GeneralViewModel = new GeneralViewModel();
            CurrencyViewModel = new CurrencyViewModel();

            GeneralViewCommand = new RelayCommand(g =>
            {
                CurrentView = GeneralViewModel;
            });

            CurrencyViewCommand = new RelayCommand(c =>
            {
                CurrentView = CurrencyViewModel;
            });
        }
    }
}
