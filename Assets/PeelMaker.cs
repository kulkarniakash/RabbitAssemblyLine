using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeelMaker : Machine
{
    public PeelCollector collector;
    public GameObject peel;
    public GameObject peelSpawner;

    private int speed;
    private bool animationPlaying;
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
        animationPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void hitMachine()
    {
        state = MachineState.One;
    }

    public override void drainMachine()
    {
        // throw new System.NotImplementedException();
    }

    public void startAnimation()
    {
        animationPlaying = true;
        GetComponent<Animator>().SetTrigger("switch on");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }

    public override void feedMachine()
    {
        if (!state.Equals(MachineState.Off) && !animationPlaying)
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
        animationPlaying = false;
    }
}
