using System;
using System.Windows;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using MaterialDesignColors;
using MaterialDesignThemes.MahApps;
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
        private void LoadResources()
        {
            if (Application.Current == null)
            {

                // Application will be null, so create one
                var application = new Application { Resources = new ResourceDictionary() };

                // mahapps
                // controls
                application.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri("/MahApps.Metro;component/Styles/Controls.xaml", UriKind.Relative)));
                // fonts and colors
                application.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri("/MahApps.Metro;component/Styles/Fonts.xaml", UriKind.Relative)));
                application.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri("/MahApps.Metro;component/Styles/Colors.xaml", UriKind.Relative)));
                // themes
                application.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri("/MahApps.Metro;component/Styles/Accents/Blue.xaml", UriKind.Relative)));
                application.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri("/MahApps.Metro;component/Styles/Accents/BaseLight.xaml", UriKind.Relative)));
                
                // material design

                // Work-around: This forces the Material Design .dlls to be compiled and copied. 
                // Otherwise, they won't and loading the assemblies below will throw FileNotFound.
                // https://github.com/ButchersBoy/MaterialDesignInXamlToolkit/issues/427
                ShadowAssist.SetShadowDepth(this, ShadowDepth.Depth0);
                var provider = new SwatchesProvider();
                FlyoutAssist.GetHeaderShadowDepth(this);

                application.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri("/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml", UriKind.Relative)));
                application.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri("/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml", UriKind.Relative)));
                application.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri("/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Blue.xaml", UriKind.Relative)));
                application.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri("/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Orange.xaml", UriKind.Relative)));
                application.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri("/MaterialDesignThemes.MahApps;component/Themes/MaterialDesignTheme.MahApps.Fonts.xaml", UriKind.Relative)));
                
            }
        }
    }
}
