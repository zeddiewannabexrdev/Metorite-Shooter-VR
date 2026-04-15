using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    private ObjectPool pool;
    public ObjectPool Pool { get => pool; set => pool = value; }
    // Start is called before the first frame update
    public void Release()
    {
        pool.ReturnToPool(this);
    }
}
