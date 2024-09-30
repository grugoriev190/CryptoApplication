using CryptocurrenciesApp.ViewModels;
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
	/// Interaction logic for HomeView.xaml
	/// </summary>
	public partial class HomeView : UserControl
	{
		public HomeView()
		{
			InitializeComponent();
			DataContext = new MainViewModel();
		}
		private void ThemeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var comboBox = sender as ComboBox;
			if (comboBox.SelectedItem is ComboBoxItem selectedItem)
			{
				string theme = selectedItem.Tag.ToString();

				if (theme == "Light")
				{
					// Застосувати світлу тему
					Resources.MergedDictionaries.Clear();
					Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("App.xaml", UriKind.Relative) });
				}
				else
				{
					// Застосувати темну тему
					Resources.MergedDictionaries.Clear();
					Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("App.xaml", UriKind.Relative) });
				}
			}
		}


	}
}
