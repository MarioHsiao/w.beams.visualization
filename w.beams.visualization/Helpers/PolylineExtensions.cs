using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace w.beams.visualization.Helpers
{
    public static class PolylineExtensions
    {

        /// <summary>
        ///  Adds vertices to a polyline and adds it to a transaction.
        /// </summary>
        /// <param name="pline"></param>
        /// <param name="ptColl"></param>
        public static void AddVertices(this Polyline3d pline, Point3dCollection ptColl)
        {
            AutoCadHelper.AppendAndAddToTransaction(pline);

            foreach (Point3d pt3d in ptColl)
            {
                var vertex = new PolylineVertex3d(pt3d);
                pline.AppendVertex(vertex);
                AutoCadHelper.AddToTransaction(vertex);
            }

            // Erase the polyline before commiting so it's not drawn.
            pline.Erase();
        }
    }
}
