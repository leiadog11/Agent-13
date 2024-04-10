using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
    public GameObject rightHandController; 
    public GameObject voiceLines;

    public float xOffset = 0.19f;
    public float yOffset = 0.03f;
    public float zOffset = 0.01f;
    private Vector3 offset;

    private AudioSource audioSource;
    private float distanceThreshold = 3f;
    private Vector3 initialPosition;
    private bool can;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        can = false;
        offset = new Vector3(xOffset, yOffset, zOffset);
    }

    public void SpawnGun()
    {
        initialPosition = rightHandController.transform.position;

        // Parent the item to the right hand controller
        gameObject.transform.parent = rightHandController.transform;

        // Reset position and rotation of the item relative to the controller
        gameObject.transform.localPosition = Vector3.zero + offset;
        //gameObject.transform.localRotation = Quaternion.identity;
        can = true;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = Vector3.zero + offset;
        //gameObject.transform.localRotation = Quaternion.identity;
        float distanceMoved = Vector3.Distance(initialPosition, rightHandController.transform.position);

        if (distanceMoved >= distanceThreshold && can)
        {
            audioSource.Play();
            voiceLines.GetComponent<VoiceLines>().Lines();
            can = false;
            StartCoroutine(WaitToDestroy());
        }
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);

    }
}
