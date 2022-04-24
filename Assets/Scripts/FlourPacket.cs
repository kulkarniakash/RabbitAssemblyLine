using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourPacket : SpawnedObject
{
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        eligibleColliders = new List<GameObject>(new GameObject[] { GameObject.FindGameObjectWithTag("Flour Machine") });
    }

    protected override bool collisionCallback(GameObject collider)
    {
        FlourMachine mach = eligibleColliders[0].GetComponent<FlourMachine>();
        mach.feedMachine();

        Destroy(gameObject);

        return true;
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
