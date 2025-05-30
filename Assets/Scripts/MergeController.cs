using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MergeController : MonoBehaviour
{
    [SerializeField] FruitSpawner fruitSpawner;
    [SerializeField] UnityEvent<Fruit, Fruit, Fruit> mergedEvent;

    [Header("For Testing")]
    [SerializeField] Fruit from;
    [SerializeField] public Fruit to;
    [SerializeField] float mergeSpeed = 10f;

    [ContextMenu(nameof(MergeFruits))]
    void MergeFruits()
    {
        MergeFruits(from, to);
    }

    public void MergeFruits(Fruit from, Fruit to)
    {
        StartCoroutine(CoMerge(from, to));
    }

    IEnumerator CoMerge(Fruit from, Fruit to)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * mergeSpeed;
            var pos = Vector3.Lerp(from.transform.position, to.transform.position, t);
            from.transform.position = pos;
            yield return null;
        }

        to.PlayBombFX();    
        var nextLevel = from.level + 1; 
        if(from.isBoss) 
        {   
            nextLevel = 0;  
        }   
        var obj = fruitSpawner.Spawn(nextLevel); 
        obj.transform.SetParent(from.transform.parent);
        obj.transform.position = to.transform.position; 
        mergedEvent.Invoke(from, to, obj);  
        Destroy(from.gameObject);   
        Destroy(to.gameObject); 
    }
}
