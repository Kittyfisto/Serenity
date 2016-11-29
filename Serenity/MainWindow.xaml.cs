using System;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using log4net;

namespace Serenity
{
	public partial class MainWindow
	{
		private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		private readonly MainWindowViewModel _viewModel;
		private readonly DispatcherTimer _timer;

		public MainWindow(MainWindowViewModel viewModel)
		{
			InitializeComponent();

			_viewModel = viewModel;
			DataContext = _viewModel;

			_timer = new DispatcherTimer
				{
					Interval = TimeSpan.FromMilliseconds(60)
				};
			_timer.Tick += TimerOnTick;
			_timer.Start();

			Loaded += OnLoaded;
		}

		private void TimerOnTick(object sender, EventArgs eventArgs)
		{
			try
			{
				_viewModel.Update();
			}
			catch (Exception e)
			{
				Log.ErrorFormat("Caught unexpected exception: {0}", e);
			}
		}

		private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
		{
			var uri = new Uri("pack://application:,,,/Resources/Serenity.ico");
			Icon = BitmapFrame.Create(uri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
		}
	}
}
