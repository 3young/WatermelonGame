using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] public Fruit[] prefabFruits;
    [SerializeField] UnityEvent<Fruit> spawnedEvent;

    public Fruit Spawn(int level)
    {
        var obj = Instantiate(prefabFruits[level]);
        spawnedEvent.Invoke(obj);

        return obj;
    }
 
}
