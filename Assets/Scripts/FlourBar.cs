using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourBar : MonoBehaviour
{
    public GameObject flourFill;
    public int maxLevel;
    private int level;

    private float fillHeight;
    private GameObject[] flourFillInstances;
 
    // Start is called before the first frame update
    void Start()
    {
        flourFillInstances = new GameObject[maxLevel];
        fillHeight = flourFill.GetComponent<RectTransform>().rect.height;
    }

    private void renderFillAtLevel(int level)
    {
        if (level > 0 && level <= maxLevel)
        {
            Vector3[] corners = new Vector3[4];
            GetComponent<RectTransform>().GetWorldCorners(corners);
            float y = corners[0].y;

            float newX = transform.position.x;
            float newY = y + fillHeight/2 + (fillHeight) * (level-1);

            flourFillInstances[level - 1] = Instantiate(flourFill, new Vector3(newX, newY, 1), Quaternion.identity);
        }
    }

    public int getLevel()
    {
        return level;
    }

    public void increase(int qty)
    {
        if (level + qty <= maxLevel)
        {
            int finalLevel = level + qty;
            level++;
            for (; level <  finalLevel; level++)
            {
                renderFillAtLevel(level);
            }

            renderFillAtLevel(finalLevel);
        }
    }

    public void decrease(int qty)
    {
        if (level - qty >= 0)
        {
            int finalLevel = level - qty;
            for(;level > finalLevel; level--)
            {
                Destroy(flourFillInstances[level - 1]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
