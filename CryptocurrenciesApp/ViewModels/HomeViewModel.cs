using CryptocurrenciesApp.Core;
using CryptocurrenciesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CryptocurrenciesApp.ViewModels
{
	class HomeViewModel : ObservableObjects
	{
		private readonly ApiService _cryptoApiService;
		private CurrencyModel _selectedCurrency;

		public ObservableCollection<CurrencyModel> Currencies { get; set; }

		public CurrencyModel SelectedCurrency
		{
			get => _selectedCurrency;
			set => SetProperty(ref _selectedCurrency, value);
		}

		private async Task LoadTopCurrenciesAsync()
		{
			var topCurrencies = await _cryptoApiService.GetTopNCurrenciesAsync(5);
			Debug.WriteLine("Top currencies loaded: " + topCurrencies.Count());
			foreach (var currency in topCurrencies)
			{
				Debug.WriteLine($"Currency: {currency.Name}, Price: {currency.Price}");
				Currencies.Add(currency);
			}
		}

		public HomeViewModel()
		{

			_cryptoApiService = new ApiService();
			Currencies = new ObservableCollection<CurrencyModel>();
			LoadTopCurrenciesAsync();
		}

	}
}
