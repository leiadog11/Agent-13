using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Mop : MonoBehaviour
{

    public XRDirectInteractor interactor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ParentMop(SelectEnterEventArgs Hand)
    {
        transform.SetParent(interactor.transform);
    }

    public void UnparentMop(SelectExitEventArgs Hand)
    {
        transform.SetParent(null);
    }
}
