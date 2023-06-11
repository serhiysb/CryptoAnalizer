using CryptoAnalizer.Core;
using CryptoAnalizer.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public GeneralViewModel()
        {
            GetCoinsFromApi();
        }

        private async void GetCoinsFromApi()
        {
            RootDatum tmpRoot = await _apiService.GetCoinsFromApi();
            for (int i = 0; i < 10; i++)
            {
                tmpRoot.data[i].priceUsd = tmpRoot.data[i].priceUsd.Substring(0, tmpRoot.data[i].priceUsd.Length-13);
            }
            CurrentCoins = tmpRoot.data.Take(10).ToList();
        }
    }
}
