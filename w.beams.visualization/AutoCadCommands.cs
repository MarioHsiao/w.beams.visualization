using using AutoCADCommands;
using Autodesk.AutoCAD.Runtime;
using w.beams.visualization;
using w.beams.visualization.Models;

[assembly: CommandClass(typeof(AutoCadCommands))]
namespace w.beams.visualization
{
    public class AutoCadCommands
    {
        [CommandMethod("createBeam")]
        public void ShowBeamWindow()
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }

        private BeamEngine beamEngine { get; }

        [CommandMethod("beam")]
        public void CreateBeam()
        {
            var mark = Interaction.GetString("Enter the W-Beam Mark:");
            var line = Interaction.GetDistance("Enter the beam extents:");
            
            beamEngine.DrawBeam(mark, line);
        }

    }
}
