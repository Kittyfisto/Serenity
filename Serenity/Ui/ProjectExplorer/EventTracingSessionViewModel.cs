using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Serenity.BusinessLogic;
using Serenity.BusinessLogic.Handles;

namespace Serenity.Ui.ProjectExplorer
{
	public sealed class EventTracingSessionViewModel
		: IProjectItemViewModel
	{
		private readonly EventTracingSessionHandle _session;
		private readonly ObservableCollection<EventTraceViewModel> _traces;

		public EventTracingSessionViewModel(EventTracingSessionHandle session)
		{
			_session = session;
			_traces = new ObservableCollection<EventTraceViewModel>(session.EventTraces.Select(CreateViewModel));
		}

		private EventTraceViewModel CreateViewModel(EventTraceHandle eventTrace)
		{
			return new EventTraceViewModel(eventTrace);
		}

		public IEnumerable<EventTraceViewModel> Traces
		{
			get { return _traces; }
		}

		public string Name
		{
			get { return _session.Name; }
		}

		public IProjectItemHandle Item
		{
			get { return _session; }
		}
	}
}