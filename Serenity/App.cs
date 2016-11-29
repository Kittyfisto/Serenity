using System;
using System.Reflection;
using System.Windows;
using Serenity.BusinessLogic.EventTracing;
using Serenity.Settings;
using log4net;

namespace Serenity
{
	public class App
		: Application
	{
		private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		public App()
		{
			Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("pack://application:,,,/Metrolib;component/Themes/Generic.xaml") });
		}

		public static int Start(string[] args)
		{
			var application = new App();
			using (var eventTracingEngine = new EventTracingEngine())
			{
				var settings = new ApplicationSettings();
				var viewModel = new MainWindowViewModel();
				var window = new MainWindow(viewModel);

				try
				{
					settings.Restore();
					settings.MainWindowSettings.RestoreTo(window);
				}
				catch (Exception e)
				{
					Log.WarnFormat("Unable to restore settings: {0}", e);
				}

				window.Show();
				int ret = application.Run();

				settings.MainWindowSettings.UpdateFrom(window);

				try
				{
					settings.Save();
				}
				catch (Exception e)
				{
					Log.ErrorFormat("Unable to save settings: {0}", e);
				}

				return ret;
			}
		}
	}
}