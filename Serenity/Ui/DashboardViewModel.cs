using System.Windows.Input;
using Metrolib;

namespace Serenity.Ui
{
	public sealed class DashboardViewModel
		: IViewModel
	{
		private readonly MainWindowViewModel _viewModel;
		private readonly ICommand _createProjectCommand;

		public DashboardViewModel(MainWindowViewModel viewModel)
		{
			_createProjectCommand = new DelegateCommand(viewModel.CreateProject);
		}

		public ICommand CreateProjectCommand
		{
			get { return _createProjectCommand; }
		}

		public void Update()
		{
			
		}
	}
}