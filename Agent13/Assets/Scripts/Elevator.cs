using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private Animator anim;
    public GameObject button;
    public bool isStart;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if (button.GetComponent<ButtonVR>().level == 1)
        {
            //play elevator ding
            anim.Play("ElevatorOpen");
        }

        if (button.GetComponent<ButtonVR>().level == 2 && isStart)
        {
            anim.Play("ElevatorOpen");
        }
        else if (button.GetComponent<ButtonVR>().level == 2)
        {
            anim.Play("ElevatorClose");
        }

        if (button.GetComponent<ButtonVR>().level == 3)
        {
            anim.Play("ElevatorClose");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
