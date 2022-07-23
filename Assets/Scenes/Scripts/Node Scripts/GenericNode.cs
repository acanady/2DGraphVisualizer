using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericNode<T> : MonoBehaviour
{
    //fields
    [SerializeField] private T data;
    [SerializeField] private List<GenericNode<T>> adjNodes;

    //Constructors
    public GenericNode()
    {
        data = default(T);
        adjNodes = null;
    }

    public GenericNode(T _data)
    {
        data = _data;
        adjNodes = null;
    }

    //Properties
    public T Data
    {
        get { return data; }
        set { data = value; }
    }

    public List<GenericNode<T>> AdjNodes
    {
        get { return adjNodes; }
        set { adjNodes = value; }
    }

    public void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            GraphController.Nodes.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        
    }
}
