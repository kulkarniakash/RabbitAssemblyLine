using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public Machine machine;

    private bool isOn;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        animator = GetComponent<Animator>();
    }

    public void switchOn()
    {
        isOn = true;
        Debug.Log("wheel name: " + gameObject.name);
        machine.hitMachine();
        animator.ResetTrigger("switch off");
        animator.SetTrigger("switch on");

    }

    public void switchOff()
    {
        isOn = false;
        machine.drainMachine();
        animator.ResetTrigger("switch on");
        animator.SetTrigger("switch off");

    }

    public bool getIsOn()
    {
        return isOn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
