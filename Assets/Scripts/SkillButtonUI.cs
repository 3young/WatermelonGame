using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillButtonUI : MonoBehaviour
{
    [SerializeField] UnityEvent confirmSkillEvent;
    [SerializeField] CoolTimebutton coolTimeButton;

    public void OnClickSkillButton()
    {
        if (coolTimeButton.isFinishedCoolTime)
        {
            confirmSkillEvent.Invoke();
        }
    }
}
