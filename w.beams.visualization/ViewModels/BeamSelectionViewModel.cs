using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Media;
using Prism.Commands;
using Prism.Mvvm;
using w.beams.visualization.Helpers;
using w.beams.visualization.Models;

namespace w.beams.visualization.ViewModels
{
    public class BeamSelectionViewModel : BindableBase
    {
        private StringBuilder _stringBuilder;
        public string Legend
        {
            get
            {
                if (_stringBuilder == null)
                {
                    _stringBuilder = new StringBuilder();
                    _stringBuilder.AppendLine("A = Cross-sectional area of member (in.\xB2)");
                    _stringBuilder.AppendLine("d = Depth of member, parallel to Y-axis (in.)");
                    _stringBuilder.AppendLine("tw = Thickness of web of member (in.)");
                    _stringBuilder.AppendLine("bf = Width of flange member, parallel to X-axis (in.)");
                    _stringBuilder.AppendLine("tf = Thickenss of flange of member (in.)");
                    _stringBuilder.AppendLine("k = Distance from outer face of flange to web toe of fillet (in.)");
                    _stringBuilder.AppendLine("k1 = Distance from web centerline to flange toe of fillet (in.)");
                    _stringBuilder.AppendLine("T = Distance between fillets for wide-flange");
                    _stringBuilder.AppendLine("gage = Standard gage (bolt spacing) for member (in.)");
                    _stringBuilder.AppendLine("wt./ft. = pounds per lineal feet (plf), denoted as the number after the X (e.g. W16x[45])");
                    _stringBuilder.AppendLine("Ix = Moment of inertia of member taken about X-axis (in.\xB4)");
                    _stringBuilder.AppendLine("Sx = Elastic section modulus of member taken about X-axis (in.\xB3)");
                    _stringBuilder.AppendLine("rx = Radius of gyration of member taken about X-axis (in.) = SQRT(Ix/A)");
                    _stringBuilder.AppendLine("Zx = Plastic section modulus of member taken about X-axis (in.\xB3)");
                    _stringBuilder.AppendLine("ly = Moment of inertia of member taken about Y-axis (in.\xB4)");
                    _stringBuilder.AppendLine("Sy = Elastic section modulus of member taken about Y-axis (in.\xB3)");
                    _stringBuilder.AppendLine("ry = Radius of gyration of member taken about Y-axis (in.) = SQRT(ly/A)");
                    _stringBuilder.AppendLine("Zy = Plastic section modulus of member taken about Y-axis (in.\xB3)");
                    _stringBuilder.AppendLine("rts = SQRT( SQRT(ly*Cw/Sx) (in.)");
                    _stringBuilder.AppendLine("ho = Horizontal distance from designatied memner");
                    _stringBuilder.AppendLine("J = Torsional moment of inertia of member (in.\xB4)");
                    _stringBuilder.AppendLine("Cw = Warping constant (in.\xB6)");
                    _stringBuilder.AppendLine("a = Torsional property, a = SQRT(E*Cw/G*J) (in.)");
                    _stringBuilder.AppendLine("Wno = Normalized warping function at a point at the flange edge (in. \xB2)");
                    _stringBuilder.AppendLine("Sw = Warping statical moment at a point on the cross section (in.\xB4)");
                    _stringBuilder.AppendLine("Qf = Statical moment for a point in the flange directly above the vertical edge of the web (in.\xB3)");
                    _stringBuilder.AppendLine("Qw = Statical moment at the mid-depth of the section (in.\xB3)");
                }
                return _stringBuilder.ToString();
            }
        }

        public static ObservableCollection<Beam> BeamCollection { get; set; }

        private Beam _selectedBeam;
        public Beam SelectedBeam
        {
            get => _selectedBeam;
            set
            {
                SetProperty(ref _selectedBeam, value);
                if (_selectedBeam != null)
                {
                    PointCollection = _selectedBeam.Section.ConvertToWpfPointCollection();
                }
            }
        }

        private PointCollection _pointCollection;
        public PointCollection PointCollection
        {
            get { return _pointCollection; }
            set { SetProperty(ref _pointCollection, value); }
        }


        public DelegateCommand DrawBeamCommand { get; set; }
        public DelegateCommand DrawColumnCommand { get; set; }

        public BeamSelectionViewModel()
        {
            BeamCollection = BeamJsonHelper.BeamCollectionFromJson();
            DrawBeamCommand = new DelegateCommand(_drawBeam);
            DrawColumnCommand = new DelegateCommand(_drawColumn);
        }

        private void _drawBeam()
        {
            SelectedBeam?.DrawBeam();
        }

        private void _drawColumn()
        {
            SelectedBeam?.DrawColumn();
        }

    }
}
