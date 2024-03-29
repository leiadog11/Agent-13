using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public LayerMask playerLayer;
    public float raycastDistance = 5f;
    public AudioSource alarm;
    public GameObject cc;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CastRay(Quaternion.AngleAxis(-180, transform.up) * transform.forward);
    }
    public void CastRay(Vector3 direction)
    {
        Vector3 raycastOrigin = transform.position + transform.up * 0.1f;
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin, direction, out hit, raycastDistance, playerLayer))
        {
            if (hit.collider.CompareTag("Player"))
            {
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
            cc.GetComponent<CameraController>().Pop();
            Destroy(gameObject);
        }
    }

}
