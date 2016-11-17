using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Metrolib;
using Serenity.BusinessLogic;
using Serenity.BusinessLogic.Handles;

namespace Serenity.Ui.Pages
{
	public sealed class EventTracingSessionViewModel
		: IPageViewModel
		, INotifyPropertyChanged
	{
		private readonly EventTracingSessionHandle _session;
		private readonly DelegateCommand _toggleRecordCommand;
		private bool _isRecording;

		public EventTracingSessionViewModel(EventTracingSessionHandle session)
		{
			_session = session;
			_toggleRecordCommand = new DelegateCommand(ToggleRecord);
		}

		private void ToggleRecord()
		{
			IsRecording = !IsRecording;
		}

		public bool IsRecording
		{
			get { return _isRecording; }
			private set
			{
				if (value == _isRecording)
					return;

				_isRecording = value;
				_session.IsRecording = value;
				EmitPropertyChanged();
			}
		}

		public ICommand ToggleRecordCommand
		{
			get { return _toggleRecordCommand; }
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void EmitPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}