using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCreator : MonoBehaviour
{
    public GameObject nodePrefab;

    private void Update()
    {
        SpawnNode();
    }

    

    private void SpawnNode()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition, new Vector2(0, 0), 0.01f);
         
            if(hits.Length == 0)
            {
                GameObject node = Instantiate(nodePrefab, mousePosition, Quaternion.identity);
                node.transform.parent = this.gameObject.transform;
            }
        }
    }

    //Assigns a name to the node based on current node count and 'word' availability. Default is (A-Z) (AA-ZZ) (AAA-ZZZ) and so on
    //Randomly selects a name to use if a namelist is provided
    void AssignName()
    {

    }
}
