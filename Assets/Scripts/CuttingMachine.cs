using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingMachine : Machine
{
    public GameObject doughballSpawner;
    public List<GameObject> doughball;


    enum MachineState
    {
        Off,
        One,
    }

    private MachineState state;

    public override void hitMachine()
    {
        state = MachineState.One;
    }

    public override void drainMachine()
    {
        state = MachineState.Off;
    }

    private void startAnimation()
    {
        GetComponent<Animator>().SetTrigger("switch on");
    }

    // Start is called before the first frame update
    void Start()
    {
        state = MachineState.Off;
    }

    public void spawnDoughBall()
    {
        int index = Random.Range(0, doughball.Count);
        Instantiate(doughball[index], doughballSpawner.transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
      
    }

    public override void feedMachine()
    {
        if (!state.Equals(MachineState.Off))
        {
            startAnimation();
        }
    }
}
