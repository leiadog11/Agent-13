using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Unity.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonVR : MonoBehaviour
{
    //public Transform visualTarget;
    //public Vector3 localAxis;
    //private Vector3 offset;
    //private Vector3 initialLocalPos;
    //private Transform pokeAttachTransform;
    //private XRBaseInteractable interactable;
    //private bool isFollowing = false;
    //private bool freeze = false;
    //public float resetSpeed = 5;
    public int level;
    public GameObject elevator, cc;
    private AudioSource source;
    //public float followAngleThreshold = 45;

    public GameObject gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        /*
        initialLocalPos = new Vector3(-0.029f, -0.6f, -0.872f);
        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(Follow);
        interactable.hoverExited.AddListener(Reset);
        interactable.selectEntered.AddListener(Freeze);
        */
    }

    /*
    public void Follow(BaseInteractionEventArgs hover)
    {
        if(hover.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;

            pokeAttachTransform = interactor.attachTransform;
            offset = visualTarget.position - pokeAttachTransform.position;

            float pokeAngle = Vector3.Angle(offset, visualTarget.TransformDirection(localAxis));

           
            isFollowing = true;
            freeze = false;
        }
    }

    public void Reset(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            isFollowing = false;
            freeze = false;
        }
    }

    public void Freeze(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            freeze = true;
            NextLevel();
        }
    }
    */

    private void Update()
    {
        /*
        if (freeze)
        {
            return;
        }
        if (isFollowing)
        {
            Vector3 localTargetPosition = visualTarget.InverseTransformPoint(pokeAttachTransform.position + offset);
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTargetPosition, localAxis);

            visualTarget.position = visualTarget.TransformPoint(constrainedLocalTargetPosition);
        }
        else
        {
            visualTarget.localPosition = Vector3.Lerp(visualTarget.localPosition, initialLocalPos, Time.deltaTime * resetSpeed);
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the tag "LeftHand"
        if (other.CompareTag("LeftHand"))
        {
            // Call the NextLevel function
            NextLevel();
            gameObject.GetComponent<BoxCollider>().enabled = false; 
        }
    }


    public void NextLevel()
    {
        cc.SetActive(false);
        source.Play();
        gameManager.GetComponent<GameManager>().level += 1;
        elevator.GetComponent<Animator>().Play("ElevatorClose");
        StartCoroutine(LoadNextLevel());
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level" + gameManager.GetComponent<GameManager>().level);
    }

}
