using System.Reflection;
using Serenity.BusinessLogic;
using Serenity.BusinessLogic.Handles;
using log4net;

namespace Serenity.Ui.ProjectExplorer
{
	/// <summary>
	///     Is responsible for creating the correct view models for <see cref="IProjectItemHandle" />s.
	/// </summary>
	public static class ProjectExplorerFactory
	{
		private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		public static IProjectItemViewModel Create(IProjectItemHandle item)
		{
			if (item == null)
				return null;

			var project = item as ProjectHandle;
			if (project != null)
				return new ProjectViewModel(project);

			var folder = item as ProjectFolderHandle;
			if (folder != null)
				return new FolderViewModel(folder);

			var etw = item as EventTracingSessionHandle;
			if (etw != null)
				return new EventTracingSessionViewModel(etw);

			var trace = item as EventTraceHandle;
			if (trace != null)
				return new EventTraceViewModel(trace);

			Log.ErrorFormat("Did not find a view model for '{0}' of type {1}", item, item.GetType());

			return null;
		}
	}
}