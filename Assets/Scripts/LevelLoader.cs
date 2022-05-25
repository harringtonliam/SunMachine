using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float loadDelalySeconds = 0.5f;
    [SerializeField] Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        if (levelText != null)
        {
            levelText.text = SceneManager.GetActiveScene().buildIndex.ToString(); ;
        }
        GameSession gameSession = FindObjectOfType<GameSession>();
        if (gameSession != null)
        {
            gameSession.DisplayScore();
        }

    }

    public void LoadNextLevel()
    {
        int sceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(LoadSceneWithDelay(sceneToLoad));
    }

    public void LoadCurrentScene()
    {
        int sceneToLoad = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadSceneWithDelay(sceneToLoad));
    }

    public void LoadStartScene()
    {
        GameSession gameSession = FindObjectOfType<GameSession>();
        if (gameSession != null)
        {
            gameSession.ResetGame();
        }
        SceneManager.LoadScene(1);
    }

    public void LoadGameOverScene()
    {
        int gameOverSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        int sceneToLoad = gameOverSceneIndex;
        StartCoroutine(LoadSceneWithDelay(sceneToLoad));
    }

    public IEnumerator LoadSceneWithDelay(int sceneToLoad)
    {
        yield return new WaitForSeconds(loadDelalySeconds);
        SceneManager.LoadScene(sceneToLoad);
    }

    public bool IsFinalLevel()
    {
        int gameOverSceneIndex = SceneManager.sceneCountInBuildSettings - 1;

        if (SceneManager.GetActiveScene().buildIndex == gameOverSceneIndex - 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
