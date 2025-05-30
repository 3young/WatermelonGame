using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    [SerializeField] FruitSword prefabFruitSword;
    [SerializeField] FruitBall prefabFruitBall;
    [SerializeField] Transform fruitContainer;
    [SerializeField] DropController dropController;
    [SerializeField] float skillProductionTime = .1f;


    void OnHitSkill(Fruit to)
    {
        to.PlayBombFX();
        Destroy(to.gameObject);
    }

    [ContextMenu(nameof(Skill1))]
    public void Skill1()
    {
        StartCoroutine(CoSkill1(skillProductionTime));
    }

    IEnumerator CoSkill1(float duration)
    {
        yield return new WaitForSeconds(duration);
        var obj = Instantiate(prefabFruitSword);
        dropController.SetFruit(obj);
        obj.HitSkillEvent.AddListener(OnHitSkill);
    }

    [ContextMenu(nameof(Skill2))]
    public void Skill2()
    {
        StartCoroutine(CoSkill2(skillProductionTime));
    }
    IEnumerator CoSkill2(float duration)
    {
        yield return new WaitForSeconds(duration);
        var obj = Instantiate(prefabFruitBall);
        dropController.SetFruit(obj);
        obj.HitSkillEvent.AddListener(OnHitSkill);
    }

    [ContextMenu(nameof(Skill3))]
    public void Skill3()
    {
        Fruit randomFruit = fruitContainer.GetChild(Random.Range(0, fruitContainer.childCount)).GetComponent<Fruit>();
        randomFruit.PlayBombFX();
        Destroy(randomFruit.gameObject);
    }
}
