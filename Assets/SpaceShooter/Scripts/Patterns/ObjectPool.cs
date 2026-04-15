using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int initPoolSize;
    [SerializeField] private PooledObject objectToPool;

    //Store the pooled object in a collection 
    private Stack<PooledObject> pool;


    // Start is called before the first frame update
    void Start()
    {
        SetUpPool();
    }

    private void SetUpPool()
    {
        pool = new Stack<PooledObject>();
        PooledObject instance = null;

        for (int i = 0; i < initPoolSize; i++) {

            instance = Instantiate(objectToPool);
            instance.Pool = this;
            instance.gameObject.SetActive(false);
            pool.Push(instance);

        }


    }

    public PooledObject GetPooledObject()
    {
        if(pool.Count == 0) {
            PooledObject newInstance = Instantiate(objectToPool);
            newInstance.Pool = this;
            return newInstance;
        }

        PooledObject nexInstance = pool.Pop();
        nexInstance.gameObject.SetActive(true);

        Debug.Log(pool.Count);

        return nexInstance;
    }

    public void ReturnToPool(PooledObject pooledObject)
    {
        pool.Push(pooledObject);
        pooledObject.gameObject.SetActive(false );
    }


   
}
