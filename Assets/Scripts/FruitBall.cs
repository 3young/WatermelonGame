using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FruitBall : Fruit
{
    [SerializeField] int bounceCount = 0;
    [SerializeField] int maxBounceCount = 5;
    [SerializeField] public UnityEvent<Fruit> HitSkillEvent;

    private void Start()
    {
        contacted = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Fruit> (out Fruit fruit))
        {
            HitSkillEvent?.Invoke(fruit);
            return;
        }

        bounceCount++;

        if(bounceCount >= maxBounceCount)
        {
            PlayBombFX();        
            Destroy(gameObject);
        }
    }
}
