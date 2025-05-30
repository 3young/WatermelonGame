using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTimeUI : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI txtPlayTime;

    public void OnChangedPlayTime(float time)
    {
        txtPlayTime.text = $"{(int)(time / 60): 00}:{(int)(time % 60):00}";
    }
}
