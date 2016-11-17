using Serenity.BusinessLogic;
using Serenity.BusinessLogic.Handles;

namespace Serenity.Ui.ProjectExplorer
{
	public sealed class EventTraceViewModel
		: IProjectItemViewModel
	{
		private readonly EventTraceHandle _eventTrace;

		public EventTraceViewModel(EventTraceHandle eventTrace)
		{
			_eventTrace = eventTrace;
		}

		public string Name
		{
			get { return _eventTrace.Name; }
		}

		public IProjectItemHandle Item
		{
			get { return _eventTrace; }
		}
	}
}