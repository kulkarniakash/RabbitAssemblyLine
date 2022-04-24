using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeelCollector : MonoBehaviour
{
    public PeelMaker maker;
    private GameObject doughball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "doughball")
        {
            doughball = collision.gameObject;
            // collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2();
            maker.feedMachine();
        }
        
    }

    public void destroyDoughBall()
    {
        if (doughball)
        {
            Destroy(doughball);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
