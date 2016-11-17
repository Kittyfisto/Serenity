using System.IO;

namespace Serenity.BusinessLogic.Handles
{
	public sealed class EventTraceHandle
		: IProjectItemHandle
	{
		private string _fileName;

		public EventTraceHandle(string fileName)
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