# w.beams.visualization Overview

A simple AutoCAD .NET plugin which can be used to visualize and sort amongst different W, S, M, and HP Shapes. These sections can then be drawn as 
columns or beams. 

# How to Use

Use `netload` within AutoCAD and locate `w.beams.visualization.dll`.
Use command `createBeam` to open the UI.

# Implementation

The shapes are based on the AISC Manual of Steel Construction. JSON data was scraped from the website (https://www.engineersedge.com/materials/aisc_structural_shapes/aisc_structural_shapes_viewer.htm).


# Screenshots

![Image of the user interface]()




# Dependencies

<ul>
<li>AutoCAD .NET 23.0 - AutoCAD .NET API</li>
<li>MahApps.Metro - UI Framework</li>
<li>MaterialDesignThemes - UI Framework</li>
<li>MaterialDesignColors - UI Framework</li>
<li>MaterialDesignThemes.MahApps - UI Framework</li>
<li>Newtonsoft.Json - JSON Library</li>
<li>Prism.Unity - WPF/MVVM Framework</li>
<li>RestSharp - Web Requests</li>
</ul>

