using System;

using UIKit;
using Foundation;

using MvvmCross.tvOS.Views;
using MvvmCross.tvOS.Views.Presenters.Attributes;
using MvvmCross.Binding.BindingContext;

using Playground.Core.ViewModels;

namespace Playground.TvOS
{
    [MvxFromStoryboard("Main")]
    [MvxModalPresentation(WrapInNavigationController = true)]
    public partial class NestedModalView : MvxViewController<NestedModalViewModel>
	{
		public NestedModalView (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.Blue;

            var set = this.CreateBindingSet<NestedModalView, NestedModalViewModel>();

            set.Bind(btnTabs).To(vm => vm.ShowTabsCommand);
            set.Bind(btnClose).To(vm => vm.CloseCommand);

            set.Apply();
        }
	}
}
