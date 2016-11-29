using System.Collections.Generic;

namespace Serenity.BusinessLogic.Handles
{
	public sealed class EventTraceHandle
		: IProjectItemHandle
	{
		private readonly List<EventTraceProvider> _providers;
		private readonly List<EventTracingSessionHandle> _sessions;

		public EventTraceHandle()
		{
			_sessions = new List<EventTracingSessionHandle>();
			_providers = new List<EventTraceProvider>();
		}

		public IEnumerable<EventTraceProvider> Providers
		{
			get { return _providers; }
		}

		public IEnumerable<EventTracingSessionHandle> Sessions
		{
			get { return _sessions; }
		}

		public bool IsRecording { get; set; }

		public string Name { get; set; }

		public void Add(EventTracingSessionHandle eventTrace)
		{
			_sessions.Add(eventTrace);
		}
	}
}