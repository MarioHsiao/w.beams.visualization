using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.DatabaseServices;
using w.beams.visualization.Helpers;

namespace w.beams.visualization.Models
{
    class BeamEngine
    {
        public List<Beam> BeamCollection { get; }

        public BeamEngine()
        {
            BeamCollection = BeamJsonHelper.BeamCollectionFromJson().ToList();
        }

        private Beam FindBeam(string mark)
        {
            return BeamCollection.FirstOrDefault(b => b.mark == mark);
        }
        public void DrawBeam(string mark, Line line)
        {
            var beam = FindBeam(mark);
            beam?.DrawBeam(line);
        }

        public void DrawColumn(string mark)
        {
            var column = FindBeam(mark);
            column?.DrawColumn();
        }
    }
}
