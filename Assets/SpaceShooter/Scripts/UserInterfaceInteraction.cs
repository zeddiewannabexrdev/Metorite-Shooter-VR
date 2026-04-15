using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class UserInterfaceInteraction : MonoBehaviour,IRaycastInterface
{
    public UnityEvent onHitByRayCast;
    
    public void HitByRaycast()
    {
        onHitByRayCast.Invoke();
    }

   

}
