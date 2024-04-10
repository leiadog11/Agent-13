using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Mop2 : XRGrabInteractable
{
    private XRBaseInteractor interactor;
    private Rigidbody mopRigidbody;
    private bool isGrabbed = false;
    private Vector3 grabOffset;
    public GameObject voiceLines;
    private AudioSource source;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        source = GetComponent<AudioSource>();
    }

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);
        AttachMopToHand(interactor);
    }

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        return;
    }

    private void AttachMopToHand(XRBaseInteractor interactor)
    {
        source.Play();
        voiceLines.GetComponent<VoiceLines>().PlaySpecificLine(7);
        this.interactor = interactor;
        isGrabbed = true;
        if (interactor is XRDirectInteractor directInteractor)
        {
            // Disable direct interactor to prevent interaction with other objects
            directInteractor.enabled = false;
        }

        mopRigidbody = GetComponent<Rigidbody>();
        mopRigidbody.isKinematic = true; // Prevent physics interactions while attached to hand

        // Store the offset between the mop's position and the hand's position
        grabOffset = transform.position - interactor.transform.position;

        // Parent the mop to the hand
        transform.SetParent(interactor.transform);

    }

    private void DetachMopFromHand()
    {
        if (interactor is XRDirectInteractor directInteractor)
        {
            // Re-enable direct interactor
            directInteractor.enabled = true;
        }

        // Unparent the mop from the hand
        transform.SetParent(null);
        isGrabbed = false;
        mopRigidbody.isKinematic = false; // Allow physics interactions again
    }

    private void Update()
    {
        // If the mop is attached to a hand, update its position and rotation
        if (interactor != null && isGrabbed)
        {
            // Match mop's position and rotation to the hand's
            transform.position = interactor.transform.position + grabOffset;

            //Quaternion roundedRotation = RoundQuaternion(interactor.transform.rotation);
            //transform.rotation = roundedRotation;
        }
    }

    private Quaternion RoundQuaternion(Quaternion input)
    {
        return new Quaternion(
            Mathf.Round(input.x * 10f) / 10f,
            Mathf.Round(input.y * 10f) / 10f,
            Mathf.Round(input.z * 10f) / 10f,
            Mathf.Round(input.w * 10f) / 10f
        );
    }
}
