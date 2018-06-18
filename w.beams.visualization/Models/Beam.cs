using System;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Newtonsoft.Json;
using w.beams.visualization.Helpers;

namespace w.beams.visualization.Models
{
    public class Beam : IDrawBeam
    {
        // Naming conventions from AISC Steel Construction Manual
        public string mark { get; set; }
        public double A { get; set; }
        public double d { get; set; }
        public double tw { get; set; }
        public double bf { get; set; }
        public double tf { get; set; }

        [JsonProperty("k(des)")]
        public double k_des { get; set; }

        [JsonProperty("k(det)")]
        public double k_det { get; set; }

        public double k1 { get; set; }
        public double T { get; set; }
        public double gage { get; set; }

        [JsonProperty("wt./ft.")]
        public double wt_over_ft { get; set; }

        [JsonProperty("bf/(2*tf)")]
        public double bf_over_2tf { get; set; }

        [JsonProperty("h/tw")]
        public double h_over_tw { get; set; }

        public double Ix { get; set; }
        public double Sx { get; set; }
        public double rx { get; set; }
        public double Zx { get; set; }
        public double Iy { get; set; }
        public double Sy { get; set; }
        public double ry { get; set; }
        public double Zy { get; set; }
        public double rts { get; set; }
        public double ho { get; set; }
        public double J { get; set; }
        public double Cw { get; set; }
        public double a { get; set; }
        public double Wno { get; set; }
        public double Sw { get; set; }
        public double Qf { get; set; }
        public double Qw { get; set; }


        public override string ToString()
        {
            return mark;
        }

        /// <summary>
        /// Returns the point collection of a section of a beam.
        /// </summary>
        public Point3dCollection Section
        {
            get
            {
                var g = bf / 2 + k1;
                var gP = bf / 2 - k1;
                var gD = bf / 2 + tw / 2;
                var dP = bf / 2 - tw / 2;
                var kT = d - k_det;
                var dtf = d - tf;
                return new Point3dCollection(
                    new[]
                    {
                        new Point3d(0  , 0     , 0),
                        new Point3d(bf , 0     , 0),
                        new Point3d(bf , -tf   , 0),
                        new Point3d(g  , -tf   , 0),
                        new Point3d(gD  , -k_det, 0),
                        new Point3d(gD  , -kT   , 0),
                        new Point3d(g  , -dtf   , 0),
                        new Point3d(bf , -dtf  , 0),
                        new Point3d(bf , -d    , 0),
                        new Point3d(0  , -d    , 0),
                        new Point3d(0  , -dtf  , 0),
                        new Point3d(gP , -dtf  , 0),
                        new Point3d(dP , -kT   , 0),
                        new Point3d(dP , -k_det, 0),
                        new Point3d(gP , -tf   , 0),
                        new Point3d(0  , -tf   , 0),
                        new Point3d(0  , 0     , 0),
                    });
            }
        }

        private Region Region
        {
            get
            {
                // Create a polyline and append the vertices of the section to it.
                var polyline = new Polyline3d();
                polyline.AddVertices(Section);

                var acDbObjColl = new DBObjectCollection { polyline };
                var regionColl = Region.CreateFromCurves(acDbObjColl);
                return (Region)regionColl[0];
            }
        }
        private void _drawColumn()
        {
            var solidColumn = new Solid3d();
            solidColumn.Extrude(Region, d, 0);

            AutoCadHelper.AppendAndAddToTransaction(solidColumn);
        }

        public void DrawColumn()
        {
            AutoCadHelper.Do(_drawColumn);
        }

        private void _drawBeam()
        {
            const double angle = (Math.PI / 2);

            var solidBeam = new Solid3d();
            solidBeam.Extrude(Region, d, 0);

            // Rotate along flange
            solidBeam.TransformBy(Matrix3d.Rotation(angle, Vector3d.XAxis, Point3d.Origin));
            AutoCadHelper.AppendAndAddToTransaction(solidBeam);
        }
        public void DrawBeam()
        {
            AutoCadHelper.Do(_drawBeam);
        }
    }

    public interface IDrawBeam
    {
        void DrawColumn();
        void DrawBeam();
    }
}
