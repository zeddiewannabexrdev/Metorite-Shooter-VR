using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LazerGun : MonoBehaviour
{

    [SerializeField] private Animator laserAnimator;
    [SerializeField] private AudioClip laserSFX;

    [Header("Raycast Settings")]
    [SerializeField] private Transform raycastOrigin; 
    [SerializeField] private float raycastMaxDistance=800f;

    private AudioSource _laserAudioSource;

    private void Awake()
    {
        if(GetComponent<AudioSource>() != null)
        {
            _laserAudioSource = this.GetComponent<AudioSource>();
        }
    }



    RaycastHit hit; 
    public void LazerGunFired()
    {
        //Animate de gun 
        laserAnimator.SetTrigger("Fire");
        //Play lazer effects 
        _laserAudioSource.PlayOneShot(laserSFX);
        //Raycast
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, raycastMaxDistance))
        {
            if (hit.transform.GetComponent<AsteroidDestroyed>() != null && hit.transform.GetComponent<PooledObject>()!=null)
            {
                hit.transform.GetComponent<AsteroidDestroyed>().AsteroidHitted();
            }
            else if(hit.transform.GetComponent<IRaycastInterface>() != null){
                //Aqui estamos disparando el evento de cualquier objeto que tenga una clase que implemente de IRaycastInterface 
                hit.transform.GetComponent<IRaycastInterface>().HitByRaycast(); 
            }
            //Debug.DrawRay(raycastOrigin.position, transform.TransformDirection(raycastOrigin.forward) * hit.distance, Color.yellow);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

  

}
