using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

    [SerializeField]
    float levelLoadDelay = 2f;

    [SerializeField]
    float slowMotionFactor = 0.2f;

    [SerializeField]
    int scoreRequirement = 0;

    [SerializeField]
    Sprite unlockedSprite;

    private bool isUnlocked = false;

    private void Update()
    {
        int currScore = FindObjectOfType<GameSession>().GetPlayerScore();
        if (scoreRequirement <= currScore)
        {
            GetComponent<SpriteRenderer>().sprite = unlockedSprite;
            isUnlocked = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isUnlocked)
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        Time.timeScale = slowMotionFactor;
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        Time.timeScale = 1f;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
