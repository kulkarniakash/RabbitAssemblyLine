using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 offset;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    protected virtual void OnMouseDown()
    {
        offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    protected virtual void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
