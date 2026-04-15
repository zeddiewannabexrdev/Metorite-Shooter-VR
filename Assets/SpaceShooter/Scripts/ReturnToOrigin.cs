using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; 
public class ReturnToOrigin : MonoBehaviour
{
    [SerializeField] private Pose originPose; 
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        originPose.position = transform.position;
        originPose.rotation = transform.rotation;
    }

    private void OnEnable()
    {
        interactable.selectExited.AddListener(Released); 
    }

    private void OnDisable()
    {
        interactable.selectExited.RemoveListener(Released);
    }
    private void Released(SelectExitEventArgs arg0)
    {
        transform.position = originPose.position;
        transform.rotation = originPose.rotation;   
    }

}
