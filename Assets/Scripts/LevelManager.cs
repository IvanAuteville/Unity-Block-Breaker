using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void StartGame()
    {
        StartCoroutine(LoadLevelWithFade(1));
    }

    private IEnumerator LoadLevelWithFade(int index)
    {
        Cursor.visible = false;
        ScreenFader.instance.Fade();

        while (!ScreenFader.instance.IsReady())
        {
            yield return null;
        }

        SceneManager.LoadScene(index);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        AudioManager.instance.PlayMainMenu();
        Cursor.visible = true;
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(5);
        AudioManager.instance.PlayGameOver();
        Cursor.visible = true;
    }

    public void LoadNextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        
        // Game Won Scene
        if (index == (SceneManager.sceneCountInBuildSettings - 2))
        {
            SceneManager.LoadScene(index);
            AudioManager.instance.PlayGameWon();
            Cursor.visible = true;
        }
        else // Next level
        {
            AudioManager.instance.PlayLevelUp();
            StartCoroutine(LoadLevelWithFade(index));
        }
    }

    public void BrickDestroyed(int breakableCount)
    {
        if (breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}