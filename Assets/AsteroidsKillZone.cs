using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsKillZone : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid" && other.gameObject.GetComponent<PooledObject>()!=null)
        {
            //Destroy(other.gameObject);
            other.gameObject.GetComponent<Animator>().SetTrigger("FadeOut");  
            other.gameObject.GetComponent<PooledObject>().Release();
        }
    }
}
