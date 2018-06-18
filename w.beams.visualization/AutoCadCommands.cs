﻿using Autodesk.AutoCAD.Runtime;
using w.beams.visualization;

[assembly: CommandClass(typeof(AutoCadCommands))]
namespace w.beams.visualization
{
    public class AutoCadCommands
    {
        [CommandMethod("createBeam")]
        public void ShowBeamWindow()
        {
            var bs = new Bootstrapper();
            bs.Run();
        }
    }
}