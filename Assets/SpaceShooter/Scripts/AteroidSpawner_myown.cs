using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * El proposito de esta clase es generar asteroides de forma aleatoria 
 * Problema 1 : Mover de un lado a otro un objeto 
 * 
 */
public class AteroidSpawner_myown : MonoBehaviour
{
    [Header("Spawn directions")]
    [SerializeField] public Transform origin;
    [SerializeField] public Transform target;
    [SerializeField] public GameObject asteroid;

    private float _speed = 0.5f; 
    private List<GameObject> asteroids = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //Generamos un pool de asteroides 
        for(int i = 0; i < 5; i++)
        {
            GameObject _newAsteroid = Instantiate(asteroid, origin);
            _newAsteroid.SetActive(false);
            asteroids.Add(_newAsteroid);
        }
        //asteroid.transform.position = origin.position;
    }


    private float timer = 0.0f; 

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int currentIndex = 0; 
        bool readyToSpawn = false;

        Debug.Log(timer); 
        if (timer > 20.0f )
        {
            asteroids[currentIndex].SetActive(true);
            readyToSpawn = true;
            timer = 0;    
        }

        if(readyToSpawn)
        {
            asteroids[currentIndex].transform.Translate(target.position * Time.deltaTime * _speed);

        }


        //newAsteroid.transform.Translate(target.position * Time.deltaTime);
        //asteroid.transform.Translate(target.position * Time.deltaTime * _speed); 
    }

    
}
