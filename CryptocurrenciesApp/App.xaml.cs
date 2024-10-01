using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CryptocurrenciesApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			ApplyTheme("Dark"); // За замовчуванням темна тема
		}

		public void ApplyTheme(string theme)
		{
			Resources.MergedDictionaries.Clear();

			if (theme == "Light")
			{
				Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("LightTheme/LightListViewTheme.xaml", UriKind.Relative) });
				Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("LightTheme/LightMenuButtonTheme.xaml", UriKind.Relative) });
				Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("LightTheme/LightTextBoxTheme.xaml", UriKind.Relative) });
				Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("LightTheme/LightTextBlockTheme.xaml", UriKind.Relative) });
				Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("LightTheme/LightBorderTheme.xaml", UriKind.Relative) });
				Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("LightTheme/LightStackPanelTheme.xaml", UriKind.Relative) });
				Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("LightTheme/LightComboBoxTheme.xaml", UriKind.Relative) });
				Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("Theme/CloseButtonTheme.xaml", UriKind.Relative) });
			}
			else
			{
				Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("Theme/ListViewTheme.xaml", UriKind.Relative) });
				Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("Theme/MenuButtonTheme.xaml", UriKind.Relative) });
				Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("Theme/TextBoxTheme.xaml", UriKind.Relative) });
				Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("Theme/TextBlockTheme.xaml", UriKind.Relative) });
				Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("Theme/BorderTheme.xaml", UriKind.Relative) });
				Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("Theme/StackPanelTheme.xaml", UriKind.Relative) });
				Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("Theme/ComboBoxTheme.xaml", UriKind.Relative) });
				Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("Theme/CloseButtonTheme.xaml", UriKind.Relative) });
			}
		}
	}
}

