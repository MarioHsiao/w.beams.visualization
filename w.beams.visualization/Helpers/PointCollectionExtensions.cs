using System.Windows;
using System.Windows.Media;
using Autodesk.AutoCAD.Geometry;

namespace w.beams.visualization.Helpers
{
    public static class PointCollectionExtensions
    {

        /// <summary>
        /// Flattens and converts an AutoCad Point3dCollection to a WPF-usable System.Windows.Media.PointCollection.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static PointCollection ConvertToWpfPointCollection(this Point3dCollection acadPtCollection)
        {
            var pointColl = new PointCollection(acadPtCollection.Count);
            foreach (Point3d point in acadPtCollection)
            {
                pointColl.Add(new Point(point.X, point.Y));
            }

            return pointColl;
        }
    }
}
