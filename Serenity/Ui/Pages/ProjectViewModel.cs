using System;
using System.Windows.Input;
using Metrolib;
using Serenity.BusinessLogic.Handles;

namespace Serenity.Ui.Pages
{
	public sealed class ProjectViewModel
		: IPageViewModel
	{
		private readonly ICommand _createEtwSessionCommand;
		private readonly ProjectHandle _project;

		public ProjectViewModel(ProjectHandle project)
		{
			if (project == null)
				throw new ArgumentNullException("project");

			_project = project;
			_createEtwSessionCommand = new DelegateCommand(CreateEtwSession);
		}

		public ICommand CreateEtwSessionCommand
		{
			get { return _createEtwSessionCommand; }
		}

		private void CreateEtwSession()
		{
		}
	}
}