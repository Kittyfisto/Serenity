using System.Windows;
using System.Windows.Controls;
using Serenity.BusinessLogic.Handles;

namespace Serenity.Ui.Pages
{
	/// <summary>
	///     Responsible for displaying an entire "page" for a given <see cref="IProjectItemHandle" />.
	///     The user should be at least able to view the project item in the page (i.e. if its a text
	///     file then the content could be displayed).
	///     If necessary, the user should be able to also configure the item.
	/// </summary>
	public class PageControl
		: Control
	{
		public static readonly DependencyProperty PageProperty =
			DependencyProperty.Register("Page", typeof (IPageViewModel), typeof (PageControl),
			                            new PropertyMetadata(default(IPageViewModel), OnPageChanged));

		private ContentControl _control;

		static PageControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof (PageControl), new FrameworkPropertyMetadata(typeof (PageControl)));
		}

		public IPageViewModel Page
		{
			get { return (IPageViewModel) GetValue(PageProperty); }
			set { SetValue(PageProperty, value); }
		}

		private static void OnPageChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
		{
			((PageControl)d).OnPageChanged((IPageViewModel)args.NewValue);
		}

		private void OnPageChanged(IPageViewModel newValue)
		{
			SetContent(newValue);
		}

		private void SetContent(IPageViewModel item)
		{
			if (_control != null)
				_control.Content = item;
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			_control = (ContentControl) GetTemplateChild("PART_ContentControl");
			SetContent(Page);
		}
	}
}