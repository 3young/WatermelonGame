using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayTimeController : MonoBehaviour
{
    [field: SerializeField] public float playTime { get; private set; }
    [SerializeField] UnityEvent<float> changedPlayTimeEvent;

    [ContextMenu(nameof(StartTime))]
    public void StartTime()
    {
        StartCoroutine(nameof(CoTimer));
    }

    [ContextMenu(nameof(StopTime))]
    public void StopTime()
    {
        StopCoroutine(nameof(CoTimer));
    }

    IEnumerator CoTimer()
    {
        while(true)
        {
            playTime += Time.deltaTime;
            changedPlayTimeEvent?.Invoke(playTime);
            yield return null;
        }
    }
}
