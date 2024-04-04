using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool alert;
    public Transform cameraPos;
    public AudioSource pop;

    // Start is called before the first frame update
    void Start()
    {
        alert = false;
        cameraPos = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pop()
    {
        //pop.Play();
    }
}
