using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public LayerMask playerLayer;
    public float raycastDistance = 5f;
    public AudioSource alarm;
    public GameObject cc;
    private bool canCast = false;
    public GameObject effect;
    public AudioSource source;
    public GameObject voiceLines;


    // Start is called before the first frame update
    void Start()
    {
        canCast = false;
        StartCoroutine(Cast());
    }

    // Update is called once per frame
    void Update()
    {
        if(canCast)
        {
            CastRay(Quaternion.AngleAxis(-180, transform.up) * transform.forward);
        }
    }
    public void CastRay(Vector3 direction)
    {
        Vector3 raycastOrigin = transform.position + transform.up * 0.1f;
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin, direction, out hit, raycastDistance, playerLayer))
        {
            if (hit.collider.CompareTag("Player"))
            {
                if(!cc.GetComponent<CameraController>().spotted)
                {
                    voiceLines.GetComponent<VoiceLines>().PlaySpecificLine(12);
                    cc.GetComponent<CameraController>().spotted = true;
                }
                alarm.Play();
                cc.GetComponent<CameraController>().alert = true;
                cc.GetComponent<CameraController>().cameraPos = transform;
            }
        }

        // Debug drawing of rays in the scene view
        Debug.DrawRay(raycastOrigin, direction * raycastDistance, Color.red);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Mop"))
        {
            if(!cc.GetComponent<CameraController>().erased)
            {
                voiceLines.GetComponent<VoiceLines>().PlaySpecificLine(13);
                cc.GetComponent<CameraController>().erased = true;
            }
            effect.transform.position = gameObject.transform.position;
            source.Play();
            effect.GetComponent<ParticleSystem>().Play();
            //cc.GetComponent<CameraController>().Pop();
            Destroy(gameObject);
        }
    }

    IEnumerator Cast()
    {
        yield return new WaitForSeconds(3);
        canCast = true;
    }

}
