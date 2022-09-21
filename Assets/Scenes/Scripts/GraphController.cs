using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GraphController
{
    //The singular node in the graph currently selected by the User, used both for node movement and for UI
    private static GameObject selectedNode = null;
    public static List<GameObject> Nodes = new List<GameObject>();
    public static List<LineRenderer> Edges = new List<LineRenderer>();

    public static GameObject SelectedNode
    {
        get => selectedNode;
        set => selectedNode = value;
    }


    public static void DisableDragExceptProvided(GameObject keepEnabled)
    {
        foreach (var node in Nodes)
        {
            if(node != keepEnabled) node.GetComponent<NodeDrag>().enabled = false;
        }
    }

    public static void EnableDrag()
    {
        foreach (var node in Nodes) node.GetComponent<NodeDrag>().enabled = true;
    }
}
