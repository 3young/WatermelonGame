using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] MergeController mergeController;
    [SerializeField] ScoreController scoreController;
    [SerializeField] PlayTimeController playTimeController;
    [SerializeField] FruitProducer fruitProducer;
    [SerializeField] DropController dropController;
    [SerializeField] GameOverController gameOverController;
    [SerializeField] StageController stageController;
    


    int levelScore;

    private void Start()
    {
        fruitProducer.ProduceFruit();
        playTimeController.StartTime();
        stageController.RandomBackground();
        SoundManager.Instance.PlayBGM();
    }

    public void OnProducedFruit(Fruit fruit)
    {
        dropController.SetFruit(fruit);

    }

    public void OnDropFruit()
    {

        fruitProducer.ProduceFruit();
        SoundManager.Instance.PlaySFX(0);
    }

    public void OnSpawnFruit(Fruit v)
    {
        v.ContactedEvent.AddListener(OnContactedFruits);
    }

    void OnContactedFruits(Fruit from, Fruit to)
    {
        mergeController.MergeFruits(from, to);
    }

    public void OnMergedFruits(Fruit from, Fruit to, Fruit newFruit)
    {
        levelScore = (to.level + 1) * 2;
        scoreController.AddScore(levelScore);
        SoundManager.Instance.PlaySFX(1);
    }

    public void OnDeadLine()
    {
        SoundManager.Instance.PlaySFX(2);
        gameOverController.GameOver();
        SoundManager.Instance.StopBGM();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundManager.Instance.PlayBGM();
    }
}
