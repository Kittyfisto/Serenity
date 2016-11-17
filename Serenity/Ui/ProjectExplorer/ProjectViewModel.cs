using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Serenity.BusinessLogic;
using Serenity.BusinessLogic.Handles;

namespace Serenity.Ui.ProjectExplorer
{
	public sealed class ProjectViewModel
		: IProjectItemViewModel
	{
		private readonly ProjectHandle _project;
		private readonly ObservableCollection<IProjectItemViewModel> _items;

		public ProjectViewModel(ProjectHandle project)
		{
			if (project == null)
				throw new ArgumentNullException("project");

			_project = project;
			_items = new ObservableCollection<IProjectItemViewModel>();
			foreach (var item in project.Items)
			{
				_items.Add(ProjectExplorerFactory.Create(item));
			}
		}

		public string Name { get { return _project.Name; } }

		public IEnumerable<IProjectItemViewModel> Items
		{
			get { return _items; }
		}

		public IProjectItemHandle Item
		{
			get { return _project; }
		}
	}
}