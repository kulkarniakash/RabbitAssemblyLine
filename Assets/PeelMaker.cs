using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeelMaker : Machine
{
    public PeelCollector collector;
    public GameObject peel;
    public GameObject peelSpawner;

    private int speed;
    enum MachineState
    {
        Off,
        One,
    }

    private MachineState state;

    // Start is called before the first frame update
    void Start()
    {
        state = MachineState.Off;
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void hitMachine()
    {
        Debug.Log("hit");
        state = MachineState.One;
    }

    public override void drainMachine()
    {
        // throw new System.NotImplementedException();
    }

    public void startAnimation()
    {
        GetComponent<Animator>().SetTrigger("switch on");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.GetContact(0).normal.y < 0)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
    }

    public override void feedMachine()
    {
        if (!state.Equals(MachineState.Off))
        {
            startAnimation();
        }
    }

    public void spawnPeel()
    {
        if (peel)
        {
            Instantiate(peel, peelSpawner.transform.position, Quaternion.identity);
        }
    }

    public void destroyDoughBall()
    {
        collector.destroyDoughBall();
    }
}
