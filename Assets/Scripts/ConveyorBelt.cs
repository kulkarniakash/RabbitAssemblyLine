using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    private float speed;
    private int payloadNum;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
        payloadNum = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.GetContact(0).normal.y < 0)
        {
            payloadNum += 1;
            GetComponent<Animator>().ResetTrigger("switch off");
            GetComponent<Animator>().SetTrigger("switch on");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.GetContact(0).normal.y < 0)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        payloadNum -= 1;
        if (payloadNum <= 0)
        {
            GetComponent<Animator>().ResetTrigger("switch on");
            GetComponent<Animator>().SetTrigger("switch off");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
