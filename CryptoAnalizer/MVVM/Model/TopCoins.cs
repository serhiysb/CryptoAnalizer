using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAnalizer.MVVM.Model
{
    public class TopCoin
    {
        public Item item { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public int coin_id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public int market_cap_rank { get; set; }
        public string thumb { get; set; }
        public string small { get; set; }
        public string large { get; set; }
        public string slug { get; set; }
        public double price_btc { get; set; }
        public int score { get; set; }
    }

    public class RootTop
    {
        public List<TopCoin> coins { get; set; }
        public List<object> nfts { get; set; }
        public List<object> exchanges { get; set; }
    }
}
