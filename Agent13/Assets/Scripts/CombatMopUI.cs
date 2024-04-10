using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMopUI : MonoBehaviour
{

    public Transform targetObject;  
    public float yOffset = 0f;
    private RectTransform rectTransform;
    private bool rotatedLeft = false;
    private bool rotatedRight = false;

    public GameObject gameManager;

    public void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        targetObject = gameManager.GetComponent<GameManager>().mop.transform;
    }

    private void Start()
    {
        yOffset = 0;
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = targetObject.position;

        // Apply y-axis offset if needed
        targetPosition.y += yOffset;

        // Update the position of this object, keeping its y and z coordinates unchanged
        transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);


        if (rectTransform.localPosition.x <= -120f && !rotatedLeft)
        {
            RotateObject(90f);
            rotatedLeft = true;
        }
        else if (rectTransform.localPosition.x > -115f && rotatedLeft)
        {
            RotateObject(-90f);
            rotatedLeft = false;
        }

        if (rectTransform.localPosition.x >= 90f && !rotatedRight)
        {
            RotateObject(-90f);
            rotatedRight = true;
        }
        else if (rectTransform.localPosition.x < 85f && rotatedRight)
        {
            RotateObject(90f);
            rotatedRight = false;
        }
    }

    private void RotateObject(float angle)
    {
        Vector3 currentRotation = transform.localRotation.eulerAngles;
        currentRotation.z += angle;
        transform.localRotation = Quaternion.Euler(currentRotation);
    }
}

