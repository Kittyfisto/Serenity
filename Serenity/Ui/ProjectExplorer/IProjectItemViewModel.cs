using Serenity.BusinessLogic;
using Serenity.BusinessLogic.Handles;

namespace Serenity.Ui.ProjectExplorer
{
	public interface IProjectItemViewModel
	{
		IProjectItemHandle Item { get; }
	}
}