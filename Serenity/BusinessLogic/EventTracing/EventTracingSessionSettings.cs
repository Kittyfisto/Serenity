using Metrolib;

namespace Serenity.BusinessLogic.EventTracing
{
	public sealed class EventTracingSessionSettings
	{
		/// <summary>
		///     The size of the circular buffer, if any.
		///     When set to zero, then all data is kept.
		/// </summary>
		public Size CircularBufferSize { get; set; }
	}
}