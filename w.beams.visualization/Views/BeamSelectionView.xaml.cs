using System.Windows.Controls;

namespace w.beams.visualization.Views
{
    /// <summary>
    /// Interaction logic for BeamSelectionView.xaml
    /// </summary>
    public partial class BeamSelectionView : UserControl
    {
        public BeamSelectionView()
        {
            InitializeComponent();
            BeamInfoDataGrid.DataContext = BeamListView;
        }
    }
}
