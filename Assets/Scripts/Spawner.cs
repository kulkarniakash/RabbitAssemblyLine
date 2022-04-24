using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject spawnedObject;
    public Text qty;
    public GameObject qtyDisplay;
    private GameObject newObject;
    // private GameObject qtyText;
    private int quantity;

    // Start is called before the first frame update
    void Start()
    {
        Physics.queriesHitTriggers = true;
        quantity = 0;
        qtyDisplay.SetActive(false);
        // qtyText = transform.GetChild(0).GetChild(0).gameObject;
        // newObject = spawn();
        // showQty();
    }

    private void showQty()
    {
        qtyDisplay.SetActive(true);
        qty.text = quantity.ToString();
        // qtyText.GetComponent<TextMesh>().text = "x" + quantity;
    }

    public void minusQuantity()
    {
        if (quantity > 0)
        {
            quantity--;
            if (quantity == 0)
            {
                qtyDisplay.SetActive(false);
            } else
            {
                showQty();
            }
        }



    }

    public void spawn()
    {
        GameObject obj = Instantiate(spawnedObject,transform.position, Quaternion.identity);
        obj.GetComponent<SpriteRenderer>().sortingOrder = quantity + 1;
        obj.GetComponent<SpawnedObject>().spawner = this;
        quantity++;
        showQty();
    }





    // Update is called once per frame
    void Update()
    {

    }
}
