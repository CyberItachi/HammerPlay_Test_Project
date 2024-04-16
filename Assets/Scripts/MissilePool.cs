using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePool : MonoBehaviour
{
    public static MissilePool instance;
    List<GameObject> pooledMissiles = new List<GameObject>();
    [SerializeField] int amountToPool = 20;
    [SerializeField] GameObject missilePrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(missilePrefab);
            obj.SetActive(false);
            pooledMissiles.Add(obj);
        }
    }

    public GameObject GetMissile()
    {
        for (int i = 0; i < pooledMissiles.Count; i++)
        {
            if (!pooledMissiles[i].activeInHierarchy)
            {
                return pooledMissiles[i];
            }
        }
        return null;
    }
}