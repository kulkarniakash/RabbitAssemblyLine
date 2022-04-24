using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : SpawnedObject
{
    private Wheel currentWheel;
    private Wheel lastWheel;

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        eligibleColliders = new List<GameObject>(GameObject.FindGameObjectsWithTag("Wheel"));
        float height = GetComponent<RectTransform>().rect.height;
        pivotOffset = new Vector3(0, height / 4, 0);
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        if (currentWheel)
        {
            lastWheel = currentWheel;
            currentWheel.switchOff();            
        }
            
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();
        if (lastWheel && lastWheel.Equals(currentWheel) && !currentWheel.getIsOn())
            currentWheel.switchOn();
    }


    protected override bool collisionCallback(GameObject collider)
    {
        /*if (currentWheel)
        {
            currentWheel.switchOff();
        }*/
        

        if (!collider.GetComponent<Wheel>().getIsOn())
        {
            transform.position = collider.transform.position + pivotOffset;
            /*if (currentWheel)
                currentWheel.switchOff();*/
            currentWheel = collider.GetComponent<Wheel>();
            currentWheel.switchOn();

            lastObj = collider;
            return true;
        }

        return false;
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
