using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Serenity.BusinessLogic.EventTracing
{
	/// <summary>
	///     Responsible for creating / destroying ETW sessions, recording
	///     etl files and allowing access to them.
	/// </summary>
	public sealed class EventTracingEngine : IEventTracingEngine
	{
		private readonly List<EventTracingSession> _sessions;
		private int _sessionIndex;

		public EventTracingEngine()
		{
			_sessions = new List<EventTracingSession>();
		}

		public IEventTracingSession Create(EventTracingSessionSettings settings)
		{
			if (settings == null)
				throw new ArgumentNullException("settings");

			var index = Interlocked.Increment(ref _sessionIndex);
			var sessionName = string.Format("Serenity Trace Session #{0}", index);
			var session = new EventTracingSession(this, sessionName, settings);
			try
			{
				lock (_sessions)
				{
					_sessions.Add(session);
				}
				return session;
			}
			catch (Exception)
			{
				session.Dispose();
				throw;
			}
		}

		public void Dispose()
		{
			List<EventTracingSession> sessions;
			lock (_sessions)
			{
				sessions = _sessions.ToList();
				_sessions.Clear();
			}

			foreach (var session in sessions)
			{
				session.Dispose();
			}
		}

		internal void OnDisposed(EventTracingSession eventTracingSession)
		{
			lock (_sessions)
			{
				_sessions.Remove(eventTracingSession);
			}
		}
	}
}