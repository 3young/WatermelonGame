using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeadlineController : MonoBehaviour
{
    [SerializeField] int detectedCount = 0;
    [SerializeField] float deadTime = 0;
    [SerializeField] float maxDeadTime = 5f;
    [SerializeField] Animator animator;
    [SerializeField] UnityEvent deadlineEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        detectedCount++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detectedCount--;
        if(detectedCount == 0)
        {
            deadTime = 0;
        }
    }

    [ContextMenu(nameof(Dead))]
    void Dead()
    {
        print("Dead");
        deadlineEvent?.Invoke();
        enabled = false;
    }
    private void Update()
    {
        if (detectedCount > 0)
        {
            deadTime += Time.deltaTime;
            animator.SetFloat("DeadTime", deadTime / maxDeadTime);
            if (deadTime >= maxDeadTime)
            {
                Dead();
            }
        }
    }

}
