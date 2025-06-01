using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverController : MonoBehaviour
{
    [SerializeField] Transform fruitContainer;
    [SerializeField] ScoreController scoreController;
    [SerializeField] PlayTimeController playTimeController;
    [SerializeField] UnityEvent<GameOverInfo> gameOverInfoEvent;
    public struct GameOverInfo
    {
        public int score;
        public float playTime;
    }

    [ContextMenu(nameof(GameOver))]
    public void GameOver()
    {
        StartCoroutine(nameof(CoGameOver));
    }

    IEnumerator CoGameOver()
    {
        yield return new WaitForSeconds(0.5f);

        var fruits = fruitContainer.GetComponentsInChildren<Fruit>();
        foreach (var f in fruits)
        {
            f.StopPhysics();
        }

        foreach (var f in fruits)
        {
            scoreController.AddScore(1);
            f.PlayBombFX();
            Destroy(f.gameObject);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.5f);

        Time.timeScale = 0f;

        GameOverInfo gameOverInfo;
        gameOverInfo.playTime = playTimeController.playTime;
        gameOverInfo.score = scoreController.score;

        gameOverInfoEvent.Invoke(gameOverInfo);
    }
}
