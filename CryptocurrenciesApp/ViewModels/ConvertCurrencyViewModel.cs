using CryptocurrenciesApp.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CryptocurrenciesApp.ViewModels
{
	class ConvertCurrencyViewModel : ObservableObjects
	{
		private readonly ApiService _cryptoApiService;

		private string _fromCurrencyText;
		private string _conversionResult;

		public ConvertCurrencyViewModel(ApiService cryptoApiService)
        {
			_cryptoApiService = cryptoApiService;
			Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
		}
        public string FromCurrencyText
		{
			get => _fromCurrencyText;
			set => SetProperty(ref _fromCurrencyText, value);
		}

		private string _toCurrencyText;
		public string ToCurrencyText
		{
			get => _toCurrencyText;
			set => SetProperty(ref _toCurrencyText, value);
		}

		private string _amountText;
		public string AmountText
		{
			get => _amountText;
			set => SetProperty(ref _amountText, value);
		}

		public string ConversionResult
		{
			get => _conversionResult;
			set => SetProperty(ref _conversionResult, value);
		}


		public async void ConvertCurrencies()
		{
			ResourceManager rm = new ResourceManager("CryptocurrenciesApp.Properties.Resources", typeof(ConvertCurrencyViewModel).Assembly);

			if (decimal.TryParse(AmountText, out decimal amount))
			{
				try
				{
					var result = await _cryptoApiService.ConvertCurrencyAsync(FromCurrencyText.ToUpper(), ToCurrencyText.ToUpper(), amount);
					ConversionResult = $"{AmountText}{FromCurrencyText.ToUpper()} = {result} {ToCurrencyText.ToUpper()}";
				}
				catch (Exception ex)
				{
					ConversionResult = $"Error: {ex.Message}";
				}
			}
			else
			{
				ConversionResult = "Please enter a valid amount to convert.";
			}
		}
	}
}
