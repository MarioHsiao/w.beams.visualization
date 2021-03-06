﻿using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using w.beams.visualization.Views;

namespace w.beams.visualization
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            // fix to Current.MainWindow being null
            Application.Current.MainWindow = Window.GetWindow(this.Shell);
            if (Application.Current.MainWindow != null) Application.Current.MainWindow.Show();
        }
        public class AcadApp : Application
        {
        }
        protected override void ConfigureModuleCatalog()
        {
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<BeamSelectionView>();
        }
    }
}
