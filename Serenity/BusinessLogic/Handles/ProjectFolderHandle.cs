using System.Collections.Generic;
using System.Linq;

namespace Serenity.BusinessLogic.Handles
{
	public sealed class ProjectFolderHandle
		: IProjectItemHandle
	{
		public string Name { get; set; }

		public IEnumerable<IProjectItemHandle> Files
		{
			get { return Enumerable.Empty<IProjectItemHandle>(); }
		}
	}
}