using Prism.Mvvm;
using Prism.Regions;
using w.beams.visualization.Views;

namespace w.beams.visualization.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "W Beams Visualization";
        private IRegionManager _regionManager;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(BeamSelectionView));

        }
    }
}
