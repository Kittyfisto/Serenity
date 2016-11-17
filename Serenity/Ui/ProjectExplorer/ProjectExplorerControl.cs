using System.Windows;
using System.Windows.Controls;
using Serenity.BusinessLogic;
using Serenity.BusinessLogic.Handles;

namespace Serenity.Ui.ProjectExplorer
{
	public class ProjectExplorerControl
		: Control
	{
		public static readonly DependencyProperty ProjectProperty =
			DependencyProperty.Register("Project", typeof (ProjectHandle), typeof (ProjectExplorerControl),
										new PropertyMetadata(default(ProjectHandle), OnProjectChanged));

		public static readonly DependencyProperty SelectedItemProperty =
			DependencyProperty.Register("SelectedItem", typeof(IProjectItemHandle), typeof(ProjectExplorerControl),
			                            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedItemChanged));

		private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
		{
			((ProjectExplorerControl) d).OnSelectedItemChanged((IProjectItemHandle)args.NewValue);
		}

		private void OnSelectedItemChanged(IProjectItemHandle newValue)
		{
			Select(newValue);
		}

		private void Select(IProjectItemHandle newValue)
		{
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

		public IProjectItemHandle SelectedItem
		{
			get { return (IProjectItemHandle)GetValue(SelectedItemProperty); }
			set { SetValue(SelectedItemProperty, value); }
		}

		public ProjectHandle Project
		{
			get { return (ProjectHandle)GetValue(ProjectProperty); }
			set { SetValue(ProjectProperty, value); }
		}

		private static void OnProjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((ProjectExplorerControl)d).OnProjectChanged((ProjectHandle)e.NewValue);
		}

		private void OnProjectChanged(ProjectHandle project)
		{
			_items = new[] {ProjectExplorerFactory.Create(project)};
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
				SelectedItem = GetItem(_treeView.SelectedItem as IProjectItemViewModel);
				_treeView.SelectedItemChanged += TreeViewOnSelectedItemChanged;

				Select(SelectedItem);
			}
		}

		private void TreeViewOnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> args)
		{
			SelectedItem = GetItem(args.NewValue as IProjectItemViewModel);
		}

		private static IProjectItemHandle GetItem(IProjectItemViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return viewModel.Item;
		}
	}
}