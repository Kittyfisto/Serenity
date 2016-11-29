using Serenity.BusinessLogic.Handles;

namespace Serenity.Ui.ProjectExplorer
{
	public sealed class EventTracingSessionViewModel
		: AbstractProjectItemViewModel
	{
		private readonly EventTracingSessionHandle _eventTrace;

		public EventTracingSessionViewModel(EventTracingSessionHandle eventTrace)
			: base(eventTrace)
		{
			_eventTrace = eventTrace;
		}

		public string Name
		{
			get { return _eventTrace.Name; }
		}

		public override void Update()
		{
		}
	}
}