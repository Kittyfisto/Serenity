using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Serenity.BusinessLogic.Handles;

namespace Serenity.Ui.ProjectExplorer
{
	public sealed class FakeFolderViewModel
		: AbstractProjectItemViewModel
	{
		private readonly IEnumerable<IProjectItemHandle> _handles;
		private readonly ObservableCollection<IProjectItemViewModel> _items;

		public FakeFolderViewModel(string name, IEnumerable<IProjectItemHandle> handles)
			: base(name)
		{
			if (handles == null)
				throw new ArgumentNullException("handles");

			_handles = handles;
			_items = new ObservableCollection<IProjectItemViewModel>();
			Update();
		}

		public IEnumerable<IProjectItemViewModel> Items
		{
			get { return _items; }
		}

		public override void Update()
		{
			Synchronize(_items, _handles);
		}
	}
}