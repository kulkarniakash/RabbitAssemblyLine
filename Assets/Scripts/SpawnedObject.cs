using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnedObject : Draggable
{
    public Spawner spawner;
    protected List<GameObject> eligibleColliders;
    protected GameObject lastObj;
    protected Vector3 pivotOffset;
    protected bool clicked;

    // Start is called before the first frame update
    // initialize eligible colliders in child class
    override protected void Start()
    {
        base.Start();
        clicked = false;
        lastObj = spawner.gameObject;
        transform.position = spawner.transform.position;
        pivotOffset = new Vector3();
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        clicked = true;
    }

    protected abstract bool collisionCallback(GameObject collider);

    protected virtual void OnMouseUp()
    {
        

        bool hasCollided = false;

        for (int i = 0; i < eligibleColliders.Count; i++)
        {
            if (overlaps(eligibleColliders[i].gameObject))
            {
                if (lastObj.Equals(spawner.gameObject) && !eligibleColliders[i].gameObject.Equals(spawner.gameObject))
                {
                    spawner.minusQuantity();

                }
                hasCollided = collisionCallback(eligibleColliders[i].gameObject);
                if (hasCollided)
                    break;
            }
        }

        if (!hasCollided)
        {
            transform.position =  lastObj.Equals(spawner.gameObject) ?  lastObj.transform.position : lastObj.transform.position + pivotOffset;
        }
    }

    private bool overlaps(GameObject obj)
    {
        RectTransform rt = obj.GetComponent<RectTransform>();
        RectTransform ch = GetComponent<RectTransform>();
        Vector3[] objCorners = new Vector3[4];
        Vector3[] chCorners = new Vector3[4];
        rt.GetWorldCorners(objCorners);
        ch.GetWorldCorners(chCorners);

        float horizontal = Mathf.Max(Mathf.Abs(objCorners[0].x - chCorners[3].x), Mathf.Abs(chCorners[0].x - objCorners[3].x));
        float vertical = Mathf.Max(Mathf.Abs(objCorners[1].y - chCorners[0].y), Mathf.Abs(chCorners[1].y - objCorners[0].y));

        float horizontalSum = objCorners[3].x - objCorners[0].x + chCorners[3].x - chCorners[0].x;
        float verticalSum = objCorners[1].y - objCorners[3].y + chCorners[1].y - chCorners[3].y;

        if (horizontal <= horizontalSum && vertical <= verticalSum)
        {
            return true;
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {

    }


}
