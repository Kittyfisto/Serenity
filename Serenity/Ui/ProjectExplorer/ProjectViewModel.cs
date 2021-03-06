﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Serenity.BusinessLogic.Handles;

namespace Serenity.Ui.ProjectExplorer
{
	public sealed class ProjectViewModel
		: AbstractProjectItemViewModel
	{
		private readonly ObservableCollection<IProjectItemViewModel> _items;
		private readonly ProjectHandle _project;

		public ProjectViewModel(ProjectHandle project)
			: base(project)
		{
			if (project == null)
				throw new ArgumentNullException("project");

			_project = project;
			_items = new ObservableCollection<IProjectItemViewModel>();
			Update();
		}

		public IEnumerable<IProjectItemViewModel> Items
		{
			get { return _items; }
		}

		public override void Update()
		{
			Synchronize(_items, _project.Items);
		}
	}
}