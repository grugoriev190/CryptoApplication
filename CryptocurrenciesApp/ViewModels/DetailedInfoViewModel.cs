using CryptocurrenciesApp.Core;
using CryptocurrenciesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CryptocurrenciesApp.ViewModels
{
	class DetailedInfoViewModel : ObservableObjects
	{
		private readonly ApiService _cryptoApiService;
		private CurrencyModel _selectedCurrency;

		public ObservableCollection<CurrencyModel> Currencies { get; set; }

		public CurrencyModel SelectedCurrency
		{
			get => _selectedCurrency;
			set => SetProperty(ref _selectedCurrency, value);
		}

		private async Task LoadCurrenciesAsync()
		{
			var infoCurrencies = await _cryptoApiService.GetDetailedCurrenciesInfoAsync();
			foreach (var currency in infoCurrencies)
			{
				Currencies.Add(currency);
			}

		}

        public DetailedInfoViewModel()
        {
			_cryptoApiService = new ApiService();
			Currencies = new ObservableCollection<CurrencyModel>();
			LoadCurrenciesAsync();

			if (Currencies.Count > 0)
			{
				SelectedCurrency = Currencies.First();
			}

			var view = CollectionViewSource.GetDefaultView(Currencies);
			view.Filter = FilterCurrencies;
		}

		private string _currencySearchText;
		public string CurrencySearchText
		{
			get => _currencySearchText;
			set
			{
				_currencySearchText = value;
				OnPropertyChanged();
				Debug.WriteLine($"Search text is: {CurrencySearchText}");
				// Оновлюємо список при кожній зміні
				var view = CollectionViewSource.GetDefaultView(Currencies);
				if (view != null)
				{
					Debug.WriteLine($"Refreshing filter for search text: {CurrencySearchText}");
					view.Refresh();
				}
			}
		}


		private bool FilterCurrencies(object item)
		{
			if (item is CurrencyModel currency)
			{
				// Якщо поле пошуку пусте, показати всі валюти
				if (string.IsNullOrWhiteSpace(CurrencySearchText))
				{
					Debug.WriteLine($"Showing all currencies with empty search text.");
					return true;
				}

				// Логіка порівняння введеного тексту з ім'ям або символом валюти
				bool nameMatches = currency.Name.IndexOf(CurrencySearchText, StringComparison.OrdinalIgnoreCase) >= 0;
				bool symbolMatches = currency.Symbol.IndexOf(CurrencySearchText, StringComparison.OrdinalIgnoreCase) >= 0;

				Debug.WriteLine($"Filtering {currency.Name} with search text: {CurrencySearchText}");

				return nameMatches || symbolMatches;
			}
			return false;
		}


	}
}
