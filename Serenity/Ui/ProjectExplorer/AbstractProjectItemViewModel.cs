using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Serenity.BusinessLogic.Handles;

namespace Serenity.Ui.ProjectExplorer
{
	public abstract class AbstractProjectItemViewModel
		: IProjectItemViewModel
	{
		private readonly IProjectItemHandle _item;
		private readonly string _name;

		protected AbstractProjectItemViewModel(string name)
		{
			_name = name;
		}

		protected AbstractProjectItemViewModel(IProjectItemHandle item)
		{
			if (item == null)
				throw new ArgumentNullException("item");

			_item = item;
			_name = item.Name;
		}

		public IProjectItemHandle Item
		{
			get { return _item; }
		}

		public string DisplayName
		{
			get { return _name; }
		}

		public virtual void Update()
		{}

		protected void Synchronize<T>(ObservableCollection<T> viewModels, IEnumerable<IProjectItemHandle> handles)
			where T : IProjectItemViewModel
		{
			foreach (IProjectItemHandle handle in handles)
			{
				if (viewModels.All(x => !ReferenceEquals(x.Item, handle)))
				{
					IProjectItemViewModel viewModel = ProjectExplorerFactory.Create(handle);
					viewModels.Add((T) viewModel);
				}
			}

			// TODO: Sort
			// TODO: Remove

			viewModels.Foreach(x => x.Update());
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void EmitPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}