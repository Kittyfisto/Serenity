using System;

namespace Serenity.BusinessLogic.EventTracing
{
	/// <summary>
	///     Responsible for creating / destroying ETW sessions, recording
	///     etl files and allowing access to them.
	/// </summary>
	public interface IEventTracingEngine
		: IDisposable
	{
		IEventTracingSession Create(EventTracingSessionSettings settings);
	}
}