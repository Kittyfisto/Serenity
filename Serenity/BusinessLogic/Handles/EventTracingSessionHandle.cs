using System.Collections.Generic;
using System.IO;

namespace Serenity.BusinessLogic.Handles
{
	/// <summary>
	///     Represents an event tracing file that may consume events live and / or record events onto the disk.
	/// </summary>
	public sealed class EventTracingSessionHandle
		: IProjectItemHandle
	{
		private string _fileName;

		public EventTracingSessionHandle(string fileName)
		{
			_fileName = fileName;
			Name = Path.GetFileName(_fileName);
		}

		public string Name { get; set; }

		public string FileName
		{
			get { return _fileName; }
		}
	}
}