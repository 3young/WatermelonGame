using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI txtScore;

    public void OnChangedScore(int score)
    {
        txtScore.text = score.ToString("00000");
    }
}
