using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumplingCollector : MonoBehaviour
{
    public CuttingMachine machine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        machine.feedMachine();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
