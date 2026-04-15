using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [Header("Control the speed of the asteroid")]
    public float maxSpeed; 
    public float minSpeed;
    [Header("Control rotational speed")]
    public float rotationSpeedMax;
    public float rotationSpeedMin;

    private float _rotationalSpeed; 
    private float _xAngle, _yAngle, _zAngle;

    public Vector3 movementDirection;

    private float _asteroidSpeed; 


    // Start is called before the first frame update
    void Start()
    {
        _asteroidSpeed = Random.Range(minSpeed, maxSpeed);

        _xAngle = Random.Range(0, 360);
        _yAngle = Random.Range(0, 360);
        _zAngle = Random.Range(0, 360);

        transform.Rotate(_xAngle, _yAngle, _zAngle);

        _rotationalSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementDirection * Time.deltaTime*_asteroidSpeed,Space.World);
        transform.Rotate(Vector3.up*Time.deltaTime*_rotationalSpeed);
    }
}
