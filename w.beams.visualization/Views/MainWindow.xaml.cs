using System;
using System.Windows;
using MahApps.Metro.Controls;

namespace w.beams.visualization.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            LoadResources();
            InitializeComponent();
        }

        // Work-around: Manually load resources due to WPF being hosted out-of-process and lack of App.xaml.
        private static void LoadResources()
        {
            if (Application.Current == null)
            {
                // Application will be null, so create one
                new Application { ShutdownMode = ShutdownMode.OnMainWindowClose };

                // controls
                Application.Current.Resources.MergedDictionaries.Add(Application.LoadComponent(new Uri("/MahApps.Metro;component/Styles/Controls.xaml", UriKind.Relative)) as ResourceDictionary);

                // fonts and colors
                Application.Current.Resources.MergedDictionaries.Add(Application.LoadComponent(new Uri("/MahApps.Metro;component/Styles/Fonts.xaml", UriKind.Relative)) as ResourceDictionary);
                Application.Current.Resources.MergedDictionaries.Add(Application.LoadComponent(new Uri("/MahApps.Metro;component/Styles/Colors.xaml", UriKind.Relative)) as ResourceDictionary);

                // themes
                Application.Current.Resources.MergedDictionaries.Add(Application.LoadComponent(new Uri("/MahApps.Metro;component/Styles/Accents/Blue.xaml", UriKind.Relative)) as ResourceDictionary);
                Application.Current.Resources.MergedDictionaries.Add(Application.LoadComponent(new Uri("/MahApps.Metro;component/Styles/Accents/BaseLight.xaml", UriKind.Relative)) as ResourceDictionary);

            }
        }
    }
}
