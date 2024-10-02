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
		
		public RelayCommand HomeViewCommand {  get; set; }
		public HomeViewModel HomeVm { get; set; }


		//DetailedInfoViewModel
		public RelayCommand DetailedInfoViewCommand { get; set; }
		public DetailedInfoViewModel DetailedInfoVm { get; set; }


		//ConvertCurrencyViewModel
		public RelayCommand ConvertCurrencyViewCommand { get; set; }
		public ConvertCurrencyViewModel ConvertCurrencyVm { get; set; }


		//ChartsViewModel
		public RelayCommand ChartsViewCommand { get; set; }
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

		public MainViewModel(HomeViewModel homeVm,
			DetailedInfoViewModel detailedInfoVm,
			ConvertCurrencyViewModel convertCurrencyVm,
			ChartsViewModel chartsVm) 
		{
			HomeVm = homeVm;
			DetailedInfoVm = detailedInfoVm;
			ConvertCurrencyVm = convertCurrencyVm;
			ChartsVm = chartsVm;

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
