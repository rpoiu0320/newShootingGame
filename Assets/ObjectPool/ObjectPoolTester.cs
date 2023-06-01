using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolTester : MonoBehaviour
{
    private ObjectPool objectPool;
    private Poolable poolable;

    private void Awake()
    {
        objectPool = GetComponent<ObjectPool>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            poolable = objectPool.GetPool();
            poolable.transform.position = new Vector3(-10f, -10f, Random.Range(-10f, 10f));
        }
    }
}
