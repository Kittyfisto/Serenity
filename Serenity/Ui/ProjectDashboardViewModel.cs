using System.ComponentModel;
using System.Runtime.CompilerServices;
using Serenity.BusinessLogic.Handles;
using Serenity.Ui.Pages;
using Serenity.Ui.ProjectExplorer;
using ProjectViewModel = Serenity.Ui.ProjectExplorer.ProjectViewModel;

namespace Serenity.Ui
{
	public sealed class ProjectDashboardViewModel
		: IViewModel
		  , INotifyPropertyChanged
	{
		private readonly ProjectHandle _project;
		private readonly ProjectViewModel _projectViewModel;
		private IPageViewModel _selectItemPageViewModel;
		private IProjectItemViewModel _selectedItemViewModel;

		public ProjectDashboardViewModel(ProjectHandle project)
		{
			_project = project;
			_projectViewModel = new ProjectViewModel(_project);
			SelectedItemViewModel = _projectViewModel;
		}

		public IPageViewModel SelectItemPageViewModel
		{
			get
			{
				return _selectItemPageViewModel;
			}
			private set
			{
				if (value == _selectItemPageViewModel)
					return;

				_selectItemPageViewModel = value;
				EmitPropertyChanged();
			}
		}

		public ProjectHandle Project
		{
			get { return _project; }
		}

		public ProjectViewModel ProjectViewModel
		{
			get { return _projectViewModel; }
		}

		public IProjectItemViewModel SelectedItemViewModel
		{
			get { return _selectedItemViewModel; }
			set
			{
				if (value == _selectedItemViewModel)
					return;

				_selectedItemViewModel = value;
				EmitPropertyChanged();

				SelectItemPageViewModel = value != null ? PageFactory.Create(value.Item) : null;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void Update()
		{
			_projectViewModel.Update();
		}

		private void EmitPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}