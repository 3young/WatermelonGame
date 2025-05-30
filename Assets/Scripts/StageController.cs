using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] int stage = 0;
    [SerializeField] GameObject[] bgList;

    [ContextMenu(nameof(RandomBackground))]
    public void RandomBackground()
    {
        for(int i = 0; i < bgList.Length; i++)
        {
            bgList[i].SetActive(false);
        }
        stage = Random.Range(0, bgList.Length);
        bgList[stage].SetActive(true);
    }
}
