using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FruitSword : Fruit
{
    [SerializeField] public UnityEvent<Fruit> HitSkillEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Fruit>(out Fruit fruit))
        {
            HitSkillEvent?.Invoke(fruit);
            return;
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            PlayBombFX();
            Destroy(gameObject);
        }
    }
}
