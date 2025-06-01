using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverUI : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI txtScore;
    [SerializeField] TMPro.TextMeshProUGUI txtPlayTime;
    [SerializeField] GameObject rootPanel;

    public void OnGameOver(GameOverController.GameOverInfo v)
    {
        txtScore.text = v.score.ToString();
        txtPlayTime.text = $"{(int)(v.playTime / 60):00}:{(int)(v.playTime % 60):00}";

        if(rootPanel != null && !rootPanel.activeSelf)
        {
            rootPanel.SetActive(true);
        }
    }
}
