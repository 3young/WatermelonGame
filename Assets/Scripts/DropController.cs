using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DropController : MonoBehaviour
{
    [SerializeField] FruitSpawner fruitSpawner;
    [SerializeField] Transform dropPoint;
    [SerializeField] int fruitLevel;
    [SerializeField] UnityEvent dropEvent;
    [SerializeField] Transform fruitContainer;

    [SerializeField] Fruit fruit;

    private void OnMouseDown()
    {
        if (fruit != null)
        {
            fruit.transform.SetParent(fruitContainer);
            fruit.StartPhysics();
            dropEvent.Invoke();
            var fruits = fruitContainer.GetComponentsInChildren<Fruit>();
            foreach(var f in fruits)
            {
                f.OnBeginDrop();
            }
            fruit = null;
        }
    }

    private void OnMouseOver()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.y = dropPoint.position.y;
        pos.z = 0;
        dropPoint.position = pos;
    }

    public void SetFruit(Fruit newFruit)
    {
        if(fruit != null)
        {
            Destroy(fruit.gameObject);
        }

        fruit = newFruit;
        fruit.transform.SetParent(dropPoint);
        fruit.transform.localPosition = Vector3.zero;
        fruit.StopPhysics();
        var fruits = fruitContainer.GetComponentsInChildren<Fruit>();
        foreach (var f in fruits)
        {
            f.OnEndDrop();
        }
    }
}
