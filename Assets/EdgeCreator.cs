using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EdgeCreator : MonoBehaviour
{
    public Material LineMaterial;
    public bool creatingEdge = false;
    public List<GameObject> points = new List<GameObject>();
    public List<Edge> edges = new List<Edge>();
    private LineRenderer lr;
    private GameObject originNode;

    public GameObject edgePrefab;
    GameObject edgeObject;
    Edge edge;

    private void Start()
    {
        //this.gameObject.GetComponent<LineRenderer>().material = LineMaterial;
        //lr = this.gameObject.GetComponent<LineRenderer>();
        //lr.positionCount = 2;

        edgeObject = null;
        edge = null;

    }
    private void Update()
    {
        CreateEdge();
        UpdateEdges();
    }

    //Function creates an edge between two selected nodes
    private void CreateEdge()
    {
        Vector2 mousePosition;
        if (Input.GetMouseButton(1))
        {
            //Debug.Log("mouse button up");
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition, new Vector2(0, 0), 0.01f);

            //Start making the first edge following the mouse pointer after clicking down
            if (hits.Length > 0 && !creatingEdge)
            {
                if (hits[0].transform.gameObject.CompareTag("Node"))
                {
                    edgeObject = Instantiate(edgePrefab, mousePosition, Quaternion.identity);
                    edge = edgeObject.GetComponent<Edge>();
                    edge.LR.positionCount = 2;
                    edge.Points.Clear();
                    edge.LR.SetPosition(0, hits[0].transform.position);
                    originNode = hits[0].transform.gameObject;
                    edge.Points.Add(hits[0].transform.gameObject);
                    creatingEdge = true;   
                }
            }
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Set line renderer to follow the mouse position
        if (creatingEdge) edge.LR.SetPosition(1, mousePosition);
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("mouse button up");
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition, new Vector2(0, 0), 0.01f);
            
            //Mouse button up, stop creating edge and set secon dposition of line renderer
            if(hits.Length > 0 && creatingEdge)
            {
                if (hits[0].transform.gameObject != originNode)
                {
                    edge.LR.SetPosition(1, hits[0].transform.position);
                    edge.Points.Add(hits[0].transform.gameObject);
                    creatingEdge = false;

                    //finished creating the edge, add the edge to the list of edges
                    edges.Add(edge);
                }
            }
        }
    }

    private void UpdateEdges()
    {
        int count = 0;
        if (!creatingEdge)
        {
            foreach(Edge curredge in edges)
            {
                foreach (var node in curredge.Points)
                {
                    curredge.LR.SetPosition(count, node.transform.position);
                    count++;
                }
                count = 0;
            }

            
        }
    }
}

