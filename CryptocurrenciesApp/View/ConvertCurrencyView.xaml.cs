﻿using CryptocurrenciesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptocurrenciesApp.View
{
	/// <summary>
	/// Interaction logic for ConvertCurrencyView.xaml
	/// </summary>
	public partial class ConvertCurrencyView : UserControl
	{
		public ConvertCurrencyView()
		{
			InitializeComponent();
		}

		private void ConvertButton_Click(object sender, RoutedEventArgs e)
		{
			var viewModel = DataContext as ConvertCurrencyViewModel;
			viewModel?.ConvertCurrencies();
		}
    }
}
