using CryptoAnalizer.MVVM.Model;
using CryptoAnalizer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace CryptoAnalizer.MVVM.ViewModel
{
    public class CurrencyViewModel : ObservableObject
    {
        private string searchName = string.Empty;
        public string SearchName
        {
            get
            {
                return searchName;
            }
            set
            {
                searchName = value;
                OnPropertyChanged();
                GetCoinByName();
            }
        }

        private RootData? currentCoin;
        public RootData CurrentCoin
        {
            get
            {
                if (currentCoin == null)
                    currentCoin = new RootData();
                return currentCoin;
            }
            set
            {
                currentCoin = value;
                OnPropertyChanged();
            }
        }

        ApiService _apiService = new ApiService();

        private async void GetCoinByName()
        {
            RootData coin = await _apiService.GetCoinByName(SearchName);
            CurrentCoin = coin;
        }
    }
}
