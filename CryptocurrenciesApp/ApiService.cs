using CryptocurrenciesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace CryptocurrenciesApp
{
	public class ApiService
	{

		private readonly string _apiKey = "41c8c058-15d2-4ebb-bef7-cae80473f187";
		private readonly HttpClient _httpClient;
		
		public ApiService()
		{
			_httpClient = new HttpClient();
			_httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", _apiKey);
		}

		public async Task<List<CurrencyModel>> GetTopNCurrenciesAsync(int n)
		{
			var url = $"https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest?limit={n}&convert=USD";

			var response = await _httpClient.GetAsync(url);
			var json = await response.Content.ReadAsStringAsync();

			var currencies = new List<CurrencyModel>();

			if (response.IsSuccessStatusCode)
			{
				var data = JObject.Parse(json)["data"];
				foreach (var item in data)
				{
					var name = item["name"].ToString();
					var price = decimal.Parse(item["quote"]["USD"]["price"].ToString());

					currencies.Add(new CurrencyModel(name, price));
				}
			}


			return currencies;
		}

		public async Task<List<CurrencyModel>> GetDetailedCurrenciesInfoAsync(int n)
		{
			var url = $"https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest?limit={n}&convert=USD";

			var response = await _httpClient.GetAsync(url);
			var json = await response.Content.ReadAsStringAsync();

			var currencies = new List<CurrencyModel>();

			if (response.IsSuccessStatusCode)
			{
				var data = JObject.Parse(json)["data"];
				foreach (var item in data)
				{
					var name = item["name"].ToString();
					var symbol = item["symbol"].ToString();
					var price = decimal.Parse(item["quote"]["USD"]["price"].ToString());
					var volume = decimal.Parse(item["quote"]["USD"]["volume_24h"].ToString());
					var priceChange = decimal.Parse(item["quote"]["USD"]["percent_change_24h"].ToString());

					currencies.Add(new CurrencyModel(name, symbol, price, volume, priceChange));
				}
			}

			return currencies;
		}
	}
}
