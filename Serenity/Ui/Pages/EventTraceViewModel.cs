using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Metrolib;
using Serenity.BusinessLogic.Handles;

namespace Serenity.Ui.Pages
{
	public sealed class EventTraceViewModel
		: IPageViewModel
		, INotifyPropertyChanged
	{
		private readonly EventTraceHandle _file;
		private readonly DelegateCommand _toggleRecordCommand;
		private bool _isRecording;

		public EventTraceViewModel(EventTraceHandle file)
		{
			_file = file;
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
				_file.IsRecording = value;
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