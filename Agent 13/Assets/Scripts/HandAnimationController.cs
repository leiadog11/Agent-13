using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class HandAnimationController : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer mesh;
    [SerializeField] private InputActionProperty GripAction;
    [SerializeField] private InputActionProperty TriggerAction;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = TriggerAction.action.ReadValue<float>();
        float gripValue = GripAction.action.ReadValue<float>();

        anim.SetFloat("Trigger", triggerValue);
        anim.SetFloat("Grip", gripValue);
    }

    public void ToggleVisibility()
    {
        mesh.enabled = !mesh.enabled;
    }
}
