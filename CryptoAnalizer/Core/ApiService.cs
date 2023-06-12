using CryptoAnalizer.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptoAnalizer.Core
{
    public class ApiService
    {
        private HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<RootCoin> GetCoinsFromApi()
        {
            string apiUrl = "https://api.coingecko.com/api/v3/search?query";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                RootCoin coin = JsonSerializer.Deserialize<RootCoin>(responseContent);
                return coin;
            }
            else
                return new RootCoin();
        }


        public async Task <RootTop> GetTopCoinsFromApi()
        {
            //string apiUrl = "https://api.coincap.io/v2/assets";
            string apiUrl = "https://api.coingecko.com/api/v3/search/trending";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                RootTop coin = JsonSerializer.Deserialize <RootTop>(responseContent);
                return coin;
            }
            else
                return new RootTop();
        }

        public async Task<RootCoin> GetCoinByName(string name)
        {
            string apiUrl;
            if (name.Length > 0)
                apiUrl = "https://api.coingecko.com/api/v3/search?query=" + name;
            else
                apiUrl = "https://api.coingecko.com/api/v3/search?query";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                RootCoin coin = JsonSerializer.Deserialize<RootCoin>(responseContent);
                return coin;
            }
            else
                return new RootCoin();
        }
        
        public async Task<RootMarkets> GetMarketsByCoin(string name)
        {
            string apiUrl = "https://api.coincap.io/v2/assets/"+name+"/markets";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                RootMarkets markets = JsonSerializer.Deserialize<RootMarkets>(responseContent);
                return markets;
            }
            else
                return new RootMarkets();
        }
    }

   
}
