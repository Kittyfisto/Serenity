using System.Reflection;
using Serenity.BusinessLogic.Handles;
using log4net;

namespace Serenity.Ui.Pages
{
	public static class PageFactory
	{
		private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		public static IPageViewModel Create(IProjectItemHandle item)
		{
			var project = item as ProjectHandle;
			if (project != null)
				return new ProjectViewModel(project);

			var etw = item as EventTracingSessionHandle;
			if (etw != null)
				return new EventTracingSessionViewModel(etw);

			return null;
		}
	}
}