using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fruit : MonoBehaviour
{
    [field: SerializeField] public int level { get; private set; } = 0;
    [field: SerializeField] public bool isBoss { get; private set; }
    [SerializeField] public UnityEvent<Fruit, Fruit> ContactedEvent;
    [SerializeField] BombFX prefabBombFX;
    [SerializeField] Animator animator;

    protected bool contacted { get; set; }

    public void OnBeginDrop()
    {
        if(animator == null) return;
        animator.SetBool("IsSpawned", true);
    }

    public void OnEndDrop()
    {
        if (animator == null) return;
        animator.SetBool("IsSpawned", false);
    }

    public void StopPhysics()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public void StartPhysics()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Fruit>(out var fruit))
        {
            if (level == fruit.level && contacted == false && fruit.contacted == false)
            {
                contacted = true;
                fruit.contacted = true;
                StopPhysics();
                fruit.StopPhysics();
                ContactedEvent.Invoke(this, fruit);
            }
        }
    }

    public void PlayBombFX()
    {
        var fx = Instantiate(prefabBombFX);
        fx.transform.position = transform.position;
    }
}
