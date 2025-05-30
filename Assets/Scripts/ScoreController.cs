using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    [field: SerializeField] public int score { get; private set; }
    [SerializeField] UnityEvent<int> changedScoreEvent;

    private void Start()
    {
        changedScoreEvent?.Invoke(score);
    }

    [ContextMenu(nameof(AddScore))]
    void AddScore()
    {
        AddScore(Random.Range(1, 5));
    }

    public void AddScore(int v)
    {
        score += v;
        changedScoreEvent?.Invoke(score);
    }
}
