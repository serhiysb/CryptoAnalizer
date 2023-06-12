using CryptoAnalizer.Core;
using CryptoAnalizer.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoAnalizer.MVVM.ViewModel
{
    public class GeneralViewModel : ObservableObject
    {

        private List<TopCoin>? currentCoins;
        public List<TopCoin> CurrentCoins
        {
            get
            {
                if (currentCoins == null)
                    currentCoins = new List<TopCoin>();
                return currentCoins;
            }
            set
            {
                currentCoins = value;
                OnPropertyChanged();
            }
        }


        ApiService _apiService = new ApiService();

        public GeneralViewModel()
        {
            GetTopCoinsFromApi();
        }

        private async void GetTopCoinsFromApi()
        {
            RootTop tmpRoot = await _apiService.GetTopCoinsFromApi();
            for (int i = 0; i < tmpRoot.coins.Count; i++)
            {
                double tmpDigit = tmpRoot.coins[i].item.price_btc;
                string truncatedNumber = tmpDigit.ToString();
                tmpRoot.coins[i].item.price_btc = double.Parse(truncatedNumber.Substring(0,truncatedNumber.Length-15));
            }
            CurrentCoins = tmpRoot.coins.ToList();
        }
    }
}
