using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement_myown : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Movement speed")]
    public float movementSpeed = 2.0f; 

    // Update is called once per frame
    void Update()
    {
        //this.gameObject.transform.Translate(transform.parent.forward*Time.deltaTime*movementSpeed);
        this.gameObject.transform.Translate(transform.parent.forward * Time.deltaTime);


    }
}
