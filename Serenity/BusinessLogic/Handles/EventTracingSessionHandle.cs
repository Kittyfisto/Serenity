using System.Collections.Generic;

namespace Serenity.BusinessLogic.Handles
{
	/// <summary>
	///     Represents an event tracing session that may consume events live and / or record events onto the disk.
	/// </summary>
	public sealed class EventTracingSessionHandle
		: IProjectItemHandle
	{
		private readonly List<EventTraceHandle> _eventTraces;

		public EventTracingSessionHandle()
		{
			_eventTraces = new List<EventTraceHandle>();
		}

		public IEnumerable<EventTraceHandle> EventTraces
		{
			get { return _eventTraces; }
		}

		public bool IsRecording { get; set; }

		public string Name { get; set; }

		public void Add(EventTraceHandle eventTrace)
		{
			_eventTraces.Add(eventTrace);
		}
	}
}