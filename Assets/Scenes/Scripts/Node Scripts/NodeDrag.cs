using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeDrag : MonoBehaviour
{
    private bool wasHoveredOver;
    private void Update()
    {
        MoveNode();
    }

    private void OnMouseOver()
    {
        wasHoveredOver = true;
    }

    public void MoveNode()
    {
        if (Input.GetMouseButton(0) && wasHoveredOver)
        {
            GraphController.DisableDragExceptProvided(this.gameObject);
            GraphController.SelectedNode = this.gameObject;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition;   
        }
        else
        {
            wasHoveredOver = false;
            GraphController.EnableDrag();
            GraphController.SelectedNode = null;
        }
    }
}
