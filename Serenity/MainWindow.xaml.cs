using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Serenity
{
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();

			Loaded += OnLoaded;
		}

		private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
		{
			var uri = new Uri("pack://application:,,,/Resources/Serenity.ico");
			Icon = BitmapFrame.Create(uri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
		}
	}
}
