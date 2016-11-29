using System.Collections.Generic;
using Serenity.BusinessLogic.Handles;

namespace Serenity.Ui.ProjectExplorer
{
	public sealed class EventTraceViewModel
		: AbstractProjectItemViewModel
	{
		private readonly EventTraceHandle _trace;
		private readonly FakeFolderViewModel[] _folders;
		private readonly FakeFolderViewModel _sessions;
		private readonly FakeFolderViewModel _providers;

		public EventTraceViewModel(EventTraceHandle trace)
			: base(trace)
		{
			_trace = trace;
			_sessions = new FakeFolderViewModel("Sessions", trace.Sessions);
			_providers = new FakeFolderViewModel("Providers", trace.Providers);

			_folders = new[]
				{
					_sessions,
					_providers
				};
		}

		public IEnumerable<FakeFolderViewModel> Items
		{
			get { return _folders; }
		}

		public string Name
		{
			get { return _trace.Name; }
		}

		public override void Update()
		{
			_sessions.Update();
			_providers.Update();
		}
	}
}