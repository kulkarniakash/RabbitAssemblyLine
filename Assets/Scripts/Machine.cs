using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Machine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public abstract void hitMachine();

    public abstract void drainMachine();

    public abstract void feedMachine();

    // Update is called once per frame
    void Update()
    {
        
    }
}
