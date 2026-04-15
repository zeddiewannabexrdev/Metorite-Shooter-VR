using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpControl : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject,3f);
    }

    private void Update()
    {
        transform.LookAt(Camera.main.transform);
        
    }
}
