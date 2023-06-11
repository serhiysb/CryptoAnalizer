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

        public async Task <RootDatum> GetCoinsFromApi()
        {
            string apiUrl = "https://api.coincap.io/v2/assets";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                RootDatum coin = JsonSerializer.Deserialize <RootDatum>(responseContent);
                return coin;
            }
            else
                return new RootDatum();
        }

        public async Task<RootData> GetCoinByName(string name)
        {
            string apiUrl = "https://api.coincap.io/v2/assets/"+name;
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                RootData coin = JsonSerializer.Deserialize<RootData>(responseContent);
                return coin;
            }
            else
                return new RootData();
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
