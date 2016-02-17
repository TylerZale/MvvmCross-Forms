using MvvmCross.Platform.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using UIKit;
using Xamarin.Forms;
using MvvmCross.Forms.Presenter.iOS;
using MvvmCross.Forms.Presenter.Core;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Example.ViewModels;
using Example.Pages;
using System;
using MvvmCross.Platform;
using MvvmCross.Core.Views;

namespace Example.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override IMvxIosViewPresenter CreatePresenter()
        {
            Forms.Init();

            var xamarinFormsApp = new MvxFormsApp();

            return new MvxFormsIosPagePresenter(Window, xamarinFormsApp);
        }

        ///ADDED FROM HERE
        protected override IEnumerable<Assembly> GetViewModelAssemblies()
        {
            var result = base.GetViewModelAssemblies();
            var assemblyList = result.ToList();
            assemblyList.Add(typeof(FirstViewModel).Assembly);
            return assemblyList.ToArray();
        }

        protected override IEnumerable<Assembly> GetViewAssemblies()
        {
            var result = base.GetViewAssemblies();
            var assemblyList = result.ToList();
            assemblyList.Add(typeof(FirstPage).Assembly);
            return assemblyList.ToArray();
        }

        protected override void InitializeViewLookup()
        {
            base.InitializeViewLookup();

            var vmLookup = new Dictionary<Type, Type> {
                {typeof (FirstViewModel), typeof (FirstPage)},
                {typeof (AboutViewModel), typeof (AboutPage)}
            };

            var container = Mvx.Resolve<IMvxViewsContainer>();
            container.AddAll(vmLookup);
        }
        ///TO HERE
    }
}
