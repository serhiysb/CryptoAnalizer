using CryptoAnalizer.MVVM.Model;
using CryptoAnalizer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Input;
using System.Threading;
using MvvmHelpers.Interfaces;
using MvvmHelpers.Commands;

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
                OnPropertyChanged(searchName);
                GetCoinByName();
            }
        }

        private List<Coin>? currentSearchedCoins;
        public List<Coin> CurrentSearchedCoins
        {
            get
            {
                if (currentSearchedCoins == null)
                    currentSearchedCoins = new List<Coin>();
                return currentSearchedCoins;
            }
            set
            {
                currentSearchedCoins = value;
                OnPropertyChanged();
            }
        }

        private ApiService _apiService = new ApiService();
        

        public CurrencyViewModel()
        {
            GetCoins();
        }

        private async void GetCoins()
        {
            RootCoin coins = await _apiService.GetCoinsFromApi();
            CurrentSearchedCoins = coins.coins;
        }

        private async void GetCoinByName()
        {

            RootCoin coin = await _apiService.GetCoinByName(SearchName);
            CurrentSearchedCoins = coin.coins;

        }

    }
}
