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

        public async Task <Root> GetCoinsFromApi()
        {
            string apiUrl = "https://api.coincap.io/v2/assets";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Root coin = JsonSerializer.Deserialize <Root>(responseContent);
                return coin;
            }
            else
                return new Root();
        }
    }
}
