using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FruitProducer : MonoBehaviour
{
    [SerializeField] FruitSpawner fruitSpawner;
    [SerializeField] float productionTime = 1f;
    [SerializeField] UnityEvent<Fruit> producedEvent;
    int level;

    [ContextMenu(nameof(ProduceFruit))]
    public void ProduceFruit()
    {
        StartCoroutine((CoProduceFruit(productionTime)));
    }

    IEnumerator CoProduceFruit(float duration)
    {
        yield return new WaitForSeconds(duration);
    
        level = Random.Range(0, fruitSpawner.prefabFruits.Length);
        var fruit = fruitSpawner.Spawn(level);
        producedEvent.Invoke(fruit);

    }
}
