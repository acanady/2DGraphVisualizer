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

    private void OnEnable() => GraphController.Nodes.Add(this.transform.gameObject);
    private void OnDisable() => GraphController.Nodes.Remove(this.transform.gameObject);


    public void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Destroy(this.gameObject);
        }
        
    }

   
}
