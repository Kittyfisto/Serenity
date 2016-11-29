using System.ComponentModel;
using System.Runtime.CompilerServices;
using Serenity.BusinessLogic.Handles;
using Serenity.Ui;

namespace Serenity
{
	public sealed class MainWindowViewModel
		: INotifyPropertyChanged
	{
		private IViewModel _content;

		public MainWindowViewModel()
		{
			_content = new DashboardViewModel(this);
		}

		public IViewModel Content
		{
			get { return _content; }
			private set
			{
				if (value == _content)
					return;

				_content = value;
				EmitPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void EmitPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}

		public void CreateProject()
		{
			var project = new ProjectHandle("New Project");
			Content = new ProjectDashboardViewModel(project);
		}

		public void Update()
		{
			if (Content != null)
				Content.Update();
		}
	}
}