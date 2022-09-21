using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    public Material LineMaterial;
    public bool creatingEdge = false;
    public LineRenderer lr;

    private List<GameObject> points = new List<GameObject>();
    private GameObject originNode;


    public LineRenderer LR => lr;
    public GameObject OriginNode => originNode;
    public List<GameObject> Points => points;

    public void Start()
    {
        lr.material = LineMaterial;
    }
}
