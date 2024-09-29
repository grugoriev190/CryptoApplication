using CryptocurrenciesApp.Core;
using CryptocurrenciesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Xml.Linq;

namespace CryptocurrenciesApp.ViewModels
{
	class MainViewModel : ObservableObjects
	{
		
		#region ApiService
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
			Debug.WriteLine("Top currencies loaded: " + topCurrencies.Count());
			foreach (var currency in topCurrencies)
			{
				Currencies.Add(currency);
			}
		}
		#endregion

		public RelayCommand HomeViewCommand {  get; set; }
		public HomeViewModel HomeVm { get; set; }

		#region Потім
		//DetailedInfoViewModel
		public RelayCommand DetailedInfoViewCommand { get; set; }
		public DetailedInfoViewModel DetailedInfoVm { get; set; }


		//ConvertCurrencyViewModel
		public RelayCommand ConvertCurrencyViewCommand { get; set; }
		public ConvertCurrencyViewModel ConvertCurrencyVm { get; set; }


		//ChartsViewModel
		public RelayCommand ChartsViewCommand { get; set; }
		public ChartsViewModel ChartsVm { get; set; }
		#endregion

		private object _currentView;

		public object CurrentView
		{
			get { return _currentView; }
			set
			{
				_currentView = value;
				OnPropertyChanged();
			}
		}

		public MainViewModel() 
		{

			_cryptoApiService = new ApiService();
			Currencies = new ObservableCollection<CurrencyModel>();
			LoadTopCurrenciesAsync();

			HomeVm = new HomeViewModel();
			DetailedInfoVm = new DetailedInfoViewModel();
			ConvertCurrencyVm = new ConvertCurrencyViewModel();
			ChartsVm = new ChartsViewModel();

			CurrentView = HomeVm;

			HomeViewCommand = new RelayCommand(o =>
			{
				CurrentView = HomeVm;
			});

			DetailedInfoViewCommand = new RelayCommand(o =>
			{
				CurrentView = DetailedInfoVm;
			});

			ConvertCurrencyViewCommand = new RelayCommand(o =>
			{
				CurrentView = ConvertCurrencyVm;
			});

			ChartsViewCommand = new RelayCommand(o =>
			{
				CurrentView = ChartsVm;
			});
		}
	}
}
