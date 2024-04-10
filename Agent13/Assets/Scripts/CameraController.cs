using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool alert;
    public bool spotted;
    public bool erased;
    public Transform cameraPos;

    // Start is called before the first frame update
    void Start()
    {
        spotted = false;
        alert = false;
        cameraPos = null;
        erased = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
