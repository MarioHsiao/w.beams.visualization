using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace w.beams.visualization.Helpers
{
    public static class PolylineExtensions
    {

        /// <summary>
        ///  Adds vertices to a polyline and adds it to a transaction.
        /// </summary>
        /// <param name="polyLine"></param>
        /// <param name="pointCollection"></param>
        public static void AddVertices(this Polyline3d polyLine, Point3dCollection pointCollection)
        {
            AutoCadHelper.AppendAndAddToTransaction(polyLine);

            foreach (Point3d point in pointCollection)
            {
                var vertex = new PolylineVertex3d(point);
                polyLine.AppendVertex(vertex);
                AutoCadHelper.AddToTransaction(vertex);
            }

            // Erase the polyline before commiting so it's not drawn.
            polyLine.Erase();
        }
    }
}
