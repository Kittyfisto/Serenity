using System.ComponentModel;
using System.Runtime.CompilerServices;
using Serenity.BusinessLogic.Handles;

namespace Serenity.Ui
{
	public sealed class ProjectDashboardViewModel
		: INotifyPropertyChanged
	{
		private readonly ProjectHandle _currentProject;
		private IProjectItemHandle _selectedItem;

		public ProjectDashboardViewModel(ProjectHandle project)
		{
			_currentProject = project;
		}

		public ProjectHandle CurrentProject
		{
			get { return _currentProject; }
		}

		public IProjectItemHandle SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				if (value == _selectedItem)
					return;

				_selectedItem = value;
				EmitPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void EmitPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}