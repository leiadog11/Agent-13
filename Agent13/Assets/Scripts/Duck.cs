using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Duck : MonoBehaviour
{
    private XRGrabInteractable grabInteractable; // Reference to the XRGrabInteractable component
    public GameObject voiceLines;
    private bool grabbed;
    private AudioSource source;

    [System.Obsolete]
    void Start()
    {
        grabbed = false;
        source = GetComponent<AudioSource>();

        // Get the XRGrabInteractable component attached to the object
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Subscribe to the OnSelectEntered event
        grabInteractable.onSelectEntered.AddListener(OnGrabbed);
    }

    [System.Obsolete]
    void OnDestroy()
    {
        // Unsubscribe from the event to avoid memory leaks
        grabInteractable.onSelectEntered.RemoveListener(OnGrabbed);
    }

    void OnGrabbed(XRBaseInteractor interactor)
    {
        source.Play();
        if(!grabbed)
        {
            voiceLines.GetComponent<VoiceLines>().PlaySpecificLine(6);
            grabbed = true;
        }
    }
}
