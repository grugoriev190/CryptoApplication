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
using System.Windows.Data;

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
			var topCurrencies = await _cryptoApiService.GetTopNCurrenciesAsync(10);
			foreach (var currency in topCurrencies)
			{
				Debug.WriteLine($"Currency: {currency.Name}, Price: {currency.Price}");
				Currencies.Add(currency);
			}
		}

		public HomeViewModel(ApiService cryptoApiService)
		{
			_cryptoApiService = cryptoApiService;
			Currencies = new ObservableCollection<CurrencyModel>();
			LoadTopCurrenciesAsync();
		}

	}
}
