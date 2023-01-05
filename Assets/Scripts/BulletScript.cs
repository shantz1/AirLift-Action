using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletScript : MonoBehaviour
{

    public static BulletScript instance;
    private List<GameObject> poolObjects = new();
    public int poolCount;

    [SerializeField] private GameObject bulletPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < poolCount; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            poolObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }
        }
        return null;
    }

}
