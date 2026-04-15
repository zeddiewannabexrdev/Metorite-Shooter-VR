using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AsteroidDestroyed : MonoBehaviour
{
    [SerializeField] private GameObject asteroidExplosion;
    [SerializeField] private GameController gameController;
    [SerializeField] private GameObject popupcanvas; 


    private Vector3 _playerLocation;

    private void Awake()
    {
        gameController = FindAnyObjectByType<GameController>();
        
        
    }


    public void AsteroidHitted()
    {
        Instantiate(asteroidExplosion,transform.position,transform.rotation);

        

        if (GameController.currentGameStatus == GameController.GameStates.Playing)
        {
            float distanceFrom = Vector3.Distance(transform.position, Vector3.zero);
            int bonusPoints = (int)distanceFrom;
            int asteroidScore = 10 * bonusPoints;


            //Esto se puede mejorar con un evento 
            //Aqui se dispara el evento de 



            popupcanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = asteroidScore.ToString();
            GameObject asteroidPopUp = Instantiate(popupcanvas,transform.position,Quaternion.identity);
            asteroidPopUp.transform.localScale = new Vector3(transform.localScale.x * (distanceFrom / 10),
                                                             transform.localScale.y * (distanceFrom / 10),
                                                             transform.localScale.z * (distanceFrom / 10)
                ); 
        
        
        
            gameController.UpdatePlayerScore(asteroidScore);
        }


        this.gameObject.GetComponent<PooledObject>().Release();


        //Calculate score for hitting 
        //La idea es que gane puntos por cada meteorito igual a la distancia a la que se encuentra. 



        //Destroy(this.gameObject);
    }


   
}
