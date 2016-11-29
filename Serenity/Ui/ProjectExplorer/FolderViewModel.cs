using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Serenity.BusinessLogic.Handles;

namespace Serenity.Ui.ProjectExplorer
{
	public sealed class FolderViewModel
		: AbstractProjectItemViewModel
	{
		private readonly ProjectFolderHandle _folder;
		private readonly ObservableCollection<IProjectItemViewModel> _items;

		public FolderViewModel(ProjectFolderHandle folder)
			: base(folder)
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

		public override void Update()
		{
			Synchronize(_items, _folder.Files);
		}
	}
}