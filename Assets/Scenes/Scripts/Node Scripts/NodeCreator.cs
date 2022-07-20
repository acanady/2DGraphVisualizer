using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCreator : MonoBehaviour
{
    public GameObject nodePrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Mathf.Abs(Camera.main.transform.position.z);
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0f;

            GameObject node = Instantiate(nodePrefab, mousePosition, Quaternion.identity);
            node.transform.parent = this.gameObject.transform;
        }
    }

    //Assigns a name to the node based on current node count and 'word' availability. Default is (A-Z) (AA-ZZ) (AAA-ZZZ) and so on
    //Randomly selects a name to use if a namelist is provided
    void AssignName()
    {

    }
}
