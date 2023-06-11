using CryptoAnalizer.Core;
using CryptoAnalizer.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoAnalizer.MVVM.ViewModel
{
    public class GeneralViewModel : ObservableObject
    {

        private List<Datum>? currentCoins;
        public List<Datum> CurrentCoins
        {
            get
            {
                if (currentCoins == null)
                    currentCoins = new List<Datum>();
                return currentCoins;
            }
            set
            {
                currentCoins = value;
                OnPropertyChanged();
            }
        }


        ApiService _apiService = new ApiService();
        public RelayCommand ShowCoins { get; set; }

        public GeneralViewModel()
        {
            GetCoinsFromApi();
        }

        private async void GetCoinsFromApi()
        {
            Root tmpRoot = await _apiService.GetCoinsFromApi();
            CurrentCoins = tmpRoot.data.Take(10).ToList();
        }
    }
}
