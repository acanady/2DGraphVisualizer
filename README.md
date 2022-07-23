# 2DGraphVisualizer

## WIP

The goal of this project is to develop a visual education tool that allows the user to create custom graphs (or select from pre-existing graphs) and then step through pre-made search and shortest path algorithms in real time and visually depict how each line of code affects graph traversal.

Supported search alorithms are Breadth First Search, Depth First Search, Djikstra, and A*

### Update 1: 
For the initial work done we have a background and ```nodes``` can be placed where ever the user hovers and presses [left-click]
![GIF placing nodes](nodeplacing.gif)
 
### Update 2:
After a bit of trial and error we can now place nodes and, when hovering over a node and pressing [left-click] drag that node around, deletion
of already existing ```nodes``` is also possible when pressing the [D] key while hovered over a ```node```. This is accomplished using GameObject.Destroy() which admittedly may not be the best practice, but as long as all refrences of the gameObject are also removed at the same time, then there won't be any access issues.
![GIF moving nodes](nodemoving.gif)
