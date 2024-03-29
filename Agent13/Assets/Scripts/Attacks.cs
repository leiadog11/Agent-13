using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Attacks : MonoBehaviour
{
    public float objectLifetime = 5f;
    public int theWay;
    private float moveSpeed = 2f;
    public int result;
    // Called when the spawned object collides with another object

    private void Start()
    {
        result = 0;
        int layerToIgnoreIndex = LayerMask.NameToLayer("Wall");
        Physics.IgnoreLayerCollision(gameObject.layer, layerToIgnoreIndex);

        if (theWay == 1)
        {
            StartCoroutine(MoveObject(gameObject, Vector3.right));
            Debug.Log("LEFT!");
        }
        else if (theWay == 2)
        {
            StartCoroutine(MoveObject(gameObject, Vector3.down));
            Debug.Log("UP!");
        }
        else if (theWay == 3)
        {
            StartCoroutine(MoveObject(gameObject, Vector3.left));
            Debug.Log("RIGHT!");
        }
        else if (theWay == 4)
        {
            StartCoroutine(MoveObject(gameObject, Vector3.up));
            Debug.Log("DOWN!");
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Block"))
        {
            result = 2; //blocked
            StartCoroutine(Die());
        }
        if (coll.gameObject.CompareTag("HitBox"))
        {
            result = 1; //damage
            StartCoroutine(Die());
        }
    }

    private IEnumerator MoveObject(GameObject obj, Vector3 direction)
    {
        float elapsedTime = 0f;
        float duration = objectLifetime;
        direction.Normalize();

        while (elapsedTime < duration)
        {
            obj.transform.Translate(direction * moveSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
