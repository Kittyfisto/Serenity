using System.Collections.Generic;

namespace Serenity.BusinessLogic.Handles
{
	public sealed class ProjectHandle
		: IProjectItemHandle
	{
		private readonly List<IProjectItemHandle> _items;

		public ProjectHandle(string name)
		{
			Name = name;
			_items = new List<IProjectItemHandle>();
		}

		public IEnumerable<IProjectItemHandle> Items
		{
			get { return _items; }
		}

		public void Add(IProjectItemHandle item)
		{
			_items.Add(item);
		}

		public string Name { get; set; }
	}
}