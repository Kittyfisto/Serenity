using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Serenity.BusinessLogic;
using Serenity.BusinessLogic.Handles;

namespace Serenity.Ui.ProjectExplorer
{
	public sealed class FolderViewModel
		: IProjectItemViewModel
	{
		private readonly ProjectFolderHandle _folder;
		private readonly ObservableCollection<IProjectItemViewModel> _items;

		public FolderViewModel(ProjectFolderHandle folder)
		{
			if (folder == null)
				throw new ArgumentNullException("folder");

			_folder = folder;
			_items = new ObservableCollection<IProjectItemViewModel>();
		}

		public IEnumerable<IProjectItemViewModel> Items
		{
			get { return _items; }
		}

		public string Name
		{
			get { return _folder.Name; }
		}

		public IProjectItemHandle Item
		{
			get { return _folder; }
		}
	}
}