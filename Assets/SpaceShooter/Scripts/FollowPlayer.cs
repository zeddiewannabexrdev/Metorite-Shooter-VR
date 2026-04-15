using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    void Update()
    {
        this.gameObject.transform.position = Camera.main.transform.position + new Vector3(0,4,5);
        transform.LookAt(Camera.main.transform);
    }
}
