using UnityEngine;

public class FlourMachine : Machine
{
    enum MachineState
    {
        Off,
        One,
        Two,
    };

    public FlourBar flourBar;
    public GameObject dumplingSpawner;
    public GameObject dumpling;
    public int maxTimeBase;

    private int state;
    private const int maxState = 2;
    private int time;
    private bool animationStarted;
    private int currentMaxTime;
    

    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        time = 0;
        currentMaxTime = maxTimeBase;
        GetComponent<Animator>().SetBool("is empty", true);
    }

    public override void feedMachine()
    {
        flourBar.increase(1);
        fillAnimation();
    }

    public override void hitMachine()
    {
        startAnimation();
        if (state < maxState)
        {
            
            state++;
            Debug.Log("state up to " + state);
            currentMaxTime = maxTimeBase / state;
            GetComponent<Animator>().speed = state;
        }
    }


    public override void drainMachine()
    {
        if (state > 1)
        {
            state--;
            currentMaxTime = maxTimeBase / state;
            GetComponent<Animator>().speed = state;
        } else if (state == 1)
        {
            state = 0;
            stopAnimation();
        }

        Debug.Log("state " + state);

        /*if (state > 0)
        {
            state--;
            if (state > 0)
            {
                currentMaxTime = maxTimeBase / state;
                GetComponent<Animator>().speed = state;
            }
        } else
        {
            stopAnimation();
        }*/
    }

    public void spawnDumpling()
    {
        Instantiate(dumpling, dumplingSpawner.transform.position, Quaternion.identity);
    }

    private void stopAnimation()
    {
        GetComponent<Animator>().ResetTrigger("switch on");
        GetComponent<Animator>().SetTrigger("switch off");
    }

    private void startAnimation()
    {
        GetComponent<Animator>().ResetTrigger("switch off");
        GetComponent<Animator>().SetTrigger("switch on");
    }

    private void fillAnimation()
    {
        if (flourBar.getLevel() > 0)
        {
            GetComponent<Animator>().SetBool("is empty", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("is empty", true);
        }
    }


    // Update is called once per frame
    void Update()
    {

        
        if (state != 0 && flourBar.getLevel() > 0)
        {

            time = (time + 1) % currentMaxTime;
            if (time == currentMaxTime - 1)
            {
                if (flourBar.getLevel() > 0)
                {
                    spawnDumpling();
                } 

                flourBar.decrease(1);
                fillAnimation();
            }
        } 
    }
}
