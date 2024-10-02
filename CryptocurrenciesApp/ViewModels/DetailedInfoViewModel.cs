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
			Debug.WriteLine("Currencies loaded: " + infoCurrencies.Count());
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
				// Оновлюємо список при кожній зміні
				var view = CollectionViewSource.GetDefaultView(Currencies);
				if (view != null)
				{
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
					return true;
				}

				// Логіка порівняння введеного тексту з ім'ям або символом валюти
				bool nameMatches = currency.Name.IndexOf(CurrencySearchText, StringComparison.OrdinalIgnoreCase) >= 0;
				bool symbolMatches = currency.Symbol.IndexOf(CurrencySearchText, StringComparison.OrdinalIgnoreCase) >= 0;
				return nameMatches || symbolMatches;
			}
			return false;
		}


	}
}
