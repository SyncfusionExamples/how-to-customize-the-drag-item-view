using Syncfusion.Maui.Core.Carousel;
using Syncfusion.Maui.TreeView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITreeView
{
    public class Behavior : Behavior<SfTreeView>
    {
        private FileManagerViewModel viewModel;
        private SfTreeView treeView;
        protected override void OnAttachedTo(SfTreeView bindable)
        {
            base.OnAttachedTo(bindable);
            treeView = bindable;
            bindable.Loaded += OnTreeViewLoaded;            
            bindable.ItemDragging += OnTreeViewDragging;
        }

        private void OnTreeViewLoaded(object? sender, TreeViewLoadedEventArgs e)
        {
            viewModel = treeView.BindingContext as FileManagerViewModel;
        }

        private void OnTreeViewDragging(object? sender, ItemDraggingEventArgs e)
        {
            if (e.Action == Syncfusion.Maui.TreeView.DragAction.Dragging)
            {
                viewModel.BlockIconVisible = e.DropPosition == Syncfusion.Maui.TreeView.DropPosition.None;
            }
        }

        protected override void OnDetachingFrom(SfTreeView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Loaded -= OnTreeViewLoaded;
            bindable.ItemDragging -= OnTreeViewDragging;
        }
    }
}
