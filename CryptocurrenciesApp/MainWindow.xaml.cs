using CryptocurrenciesApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace CryptocurrenciesApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = App.ServiceProvider.GetService<MainViewModel>();
			SwitchLanguage("en");
		}

		private void ThemeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var comboBox = sender as ComboBox;
			if (comboBox.SelectedItem is ComboBoxItem selectedItem)
			{
				string theme = selectedItem.Tag.ToString();
				(Application.Current as App).ApplyTheme(theme);
			}
		}
		private void RadioButton_Checked(object sender, RoutedEventArgs e)
		{
			Close();
        }

		private void LanguageSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (LanguageSelector.SelectedItem is ComboBoxItem selectedItem)
			{
				string languageCode = selectedItem.Tag.ToString();
				SwitchLanguage(languageCode);
			}
		}

		private void SwitchLanguage(string languageCode)
		{
			ResourceDictionary dictionary = new ResourceDictionary();

			try
			{
				this.Resources.MergedDictionaries.Add(dictionary);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error loading language resource: {ex.Message}");
			}


			switch (languageCode)
			{
				case "en-US":
					dictionary.Source = new Uri("Resources/StringResources.en.xaml", UriKind.Relative);
					break;
				case "ua-UA":
					dictionary.Source = new Uri("Resources/StringResources.ua.xaml", UriKind.Relative);
					break;
				default:
					dictionary.Source = new Uri("Resources/StringResources.en.xaml", UriKind.Relative);
					break;
			}

			this.Resources.MergedDictionaries.Clear();
			this.Resources.MergedDictionaries.Add(dictionary);
		}
	}
}
