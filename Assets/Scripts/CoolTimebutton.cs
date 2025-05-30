using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CoolTimebutton : MonoBehaviour
{
    [SerializeField] float maxCoolTime = 1f;
    [SerializeField] float coolTime = 1f;
    [SerializeField] Image imgCoolTime;

    public bool isFinishedCoolTime { get => coolTime >= maxCoolTime; }

    public void OnClick()
    {
        StopCoroutine(nameof(CoCoolTime));
        StartCoroutine(nameof(CoCoolTime));
    }

    IEnumerator CoCoolTime()
    {
        coolTime = 0f;
        while (coolTime < maxCoolTime)
        {
            coolTime += Time.deltaTime;
            imgCoolTime.fillAmount = coolTime / maxCoolTime;
            yield return null;
        }
        coolTime = maxCoolTime;
    }
}
