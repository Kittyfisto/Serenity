using System.Windows;
using System.Windows.Controls;

namespace Serenity.Ui.ProjectExplorer
{
	public class ProjectExplorerControl
		: Control
	{
		public static readonly DependencyProperty ProjectProperty =
			DependencyProperty.Register("Project", typeof (ProjectViewModel), typeof (ProjectExplorerControl),
										new PropertyMetadata(default(ProjectViewModel), OnProjectChanged));

		public static readonly DependencyProperty SelectedItemProperty =
			DependencyProperty.Register("SelectedItem", typeof(IProjectItemViewModel), typeof(ProjectExplorerControl),
			                            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedItemChanged));

		private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
		{
			((ProjectExplorerControl)d).OnSelectedItemChanged((IProjectItemViewModel)args.NewValue);
		}

		private void OnSelectedItemChanged(IProjectItemViewModel newValue)
		{
			Select(newValue);
		}

		private void Select(IProjectItemViewModel newValue)
		{
			if (_treeView == null)
				return;

			var treeViewItem = _treeView.ItemContainerGenerator.ContainerFromItem(newValue) as TreeViewItem;
			if (treeViewItem != null)
			{
				treeViewItem.IsSelected = true;
			}
		}

		private IProjectItemViewModel[] _items;
		private TreeView _treeView;

		static ProjectExplorerControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof (ProjectExplorerControl),
			                                         new FrameworkPropertyMetadata(typeof (ProjectExplorerControl)));
		}

		public IProjectItemViewModel SelectedItem
		{
			get { return (IProjectItemViewModel)GetValue(SelectedItemProperty); }
			set { SetValue(SelectedItemProperty, value); }
		}

		public ProjectViewModel Project
		{
			get { return (ProjectViewModel)GetValue(ProjectProperty); }
			set { SetValue(ProjectProperty, value); }
		}

		private static void OnProjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((ProjectExplorerControl)d).OnProjectChanged((ProjectViewModel)e.NewValue);
		}

		private void OnProjectChanged(ProjectViewModel project)
		{
			_items = new IProjectItemViewModel[] {project};
			if (_treeView != null)
			{
				_treeView.ItemsSource = _items;
			}
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			if (_treeView != null)
			{
				_treeView.SelectedItemChanged -= TreeViewOnSelectedItemChanged;
			}

			_treeView = (TreeView) GetTemplateChild("PART_TreeView");
			if (_treeView != null)
			{
				_treeView.ItemsSource = _items;
				_treeView.SelectedItemChanged += TreeViewOnSelectedItemChanged;

				Select(SelectedItem);
			}
		}

		private void TreeViewOnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> args)
		{
			SelectedItem = args.NewValue as IProjectItemViewModel;
		}

	}
}