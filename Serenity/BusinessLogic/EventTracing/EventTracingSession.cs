using System;
using System.Reflection;
using Microsoft.Diagnostics.Tracing.Session;
using log4net;

namespace Serenity.BusinessLogic.EventTracing
{
	public sealed class EventTracingSession
		: IEventTracingSession
	{
		private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		private readonly EventTracingEngine _eventTracingEngine;
		private readonly EventTracingSessionSettings _settings;
		private readonly string _sessionName;

		#region ETW

		private readonly TraceEventSession _session;

		#endregion

		public EventTracingSession(EventTracingEngine eventTracingEngine, string sessionName, EventTracingSessionSettings settings)
		{
			if (eventTracingEngine == null)
				throw new ArgumentNullException("eventTracingEngine");
			if (sessionName == null)
				throw new ArgumentNullException("sessionName");
			if (settings == null)
				throw new ArgumentNullException("settings");

			_eventTracingEngine = eventTracingEngine;
			_sessionName = sessionName;
			_settings = settings;

			Log.InfoFormat("Starting ETW session '{0}'", sessionName);

			_session = new TraceEventSession(sessionName)
				{
					CircularBufferMB = (int) settings.CircularBufferSize.Megabytes,
					StopOnDispose = true
				};
		}

		public void Dispose()
		{
			try
			{
				_session.Dispose();
			}
			catch (Exception e)
			{
				Log.ErrorFormat("Caught unexpected exception while trying to dispose ETW session '{0}': {1}",
				                _sessionName,
				                e);
			}
			_eventTracingEngine.OnDisposed(this);
		}
	}
}