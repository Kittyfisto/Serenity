using System;
using System.Windows;
using Serenity.BusinessLogic.EventTracing;

namespace Serenity
{
	public class App
		: Application
	{
		public App()
		{
			Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("pack://application:,,,/Metrolib;component/Themes/Generic.xaml") });
		}

		public static int Start(string[] args)
		{
			var application = new App();
			using (var eventTracingEngine = new EventTracingEngine())
			{
				var viewModel = new MainWindowViewModel();
				var window = new MainWindow(viewModel);
				window.Show();
				return application.Run();
			}
		}
	}
}