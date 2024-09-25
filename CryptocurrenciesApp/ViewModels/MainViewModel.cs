using CryptocurrenciesApp.Core;
using CryptocurrenciesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			foreach (var currency in topCurrencies)
			{
				Currencies.Add(currency);
			}
		}
		#endregion


		public RelayCommand HomeViewCommand {  get; set; }
		public RelayCommand DetailedInfoViewCommand { get; set; }
		public RelayCommand ConvertCurrencyViewCommand { get; set; }
		public RelayCommand ChartsViewCommand { get; set; }

		#region HomePaige
		public HomeViewModel HomeVm { get; set; }
		public DetailedInfoViewModel DetailedInfoVm { get; set; }
		public ConvertCurrencyViewModel ConvertCurrencyVm { get; set; }
		public ChartsViewModel ChartsVm { get; set; }

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
		#endregion

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
