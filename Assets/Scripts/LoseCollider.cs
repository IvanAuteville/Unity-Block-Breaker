using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private Lives livesSprite = null;
    private LevelManager levelManager = null;

    private int currentLives = 3;
    private const int maxLives = 3;

    void Awake()
    {
        Brick.ResetCount();

        livesSprite = FindObjectOfType<Lives>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D()
    {
        currentLives--;
        Ball.ResetPosition();

        if (currentLives <= 0)
        {
            levelManager.LoadGameOver();
        }
        else
        {
            livesSprite.LoadSprites(currentLives);
            AudioManager.instance.PlayLifeLost();
        }
    }
}
