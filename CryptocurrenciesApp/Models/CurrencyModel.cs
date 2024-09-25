using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrenciesApp.Models
{
	public class CurrencyModel
	{
		public string Name { get; set; }
		public string Symbol { get; set; }         //(наприклад, BTC)
		public decimal Price { get; set; }
		public decimal Volume { get; set; }        // Торговий обсяг за останні 24 години
		public decimal PriceChange { get; set; }

		public CurrencyModel(string name, string symbol, decimal price, decimal volume, decimal priceChange)
		{
			Name = name;
			Symbol = symbol;
			Price = price;
			Volume = volume;
			PriceChange = priceChange;
		}
	}
}
