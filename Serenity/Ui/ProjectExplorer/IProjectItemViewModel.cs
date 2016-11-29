using System.ComponentModel;
using Serenity.BusinessLogic.Handles;

namespace Serenity.Ui.ProjectExplorer
{
	public interface IProjectItemViewModel
		: INotifyPropertyChanged
	{
		IProjectItemHandle Item { get; }

		string DisplayName { get; }

		void Update();
	}
}