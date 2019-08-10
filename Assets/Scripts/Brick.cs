using UnityEngine;

public class Brick : MonoBehaviour
{
    public static int breakableCount = 0;

    private LevelManager level = null;
    private SpriteRenderer spriteRenderer = null;

    [SerializeField] private Sprite[] hitsprite = null;

    private int numberOfHits = 0;

    void Awake()
    {
        level = FindObjectOfType<LevelManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        breakableCount++;
    }

    /*
    void OnCollisionEnter2D()
    {
        AudioManager.instance.PlayHit();
        ProcessHit();
    }
    */

    public void OnCollision()
    {
        AudioManager.instance.PlayHit();
        ProcessHit();
    }

    private void ProcessHit()
    {
        numberOfHits++;

        int maxHits = hitsprite.Length + 1;

        if (numberOfHits >= maxHits)
        {
            breakableCount--;
            gameObject.SetActive(false);

            level.BrickDestroyed(breakableCount);
        }
        else
        {
            SwapSprites();
        }
    }

    private void SwapSprites()
    {
        int spriteIndex = numberOfHits - 1;

        if (hitsprite[spriteIndex])
        {
            spriteRenderer.sprite = hitsprite[spriteIndex];
        }
    }

    public static void ResetCount()
    {
        breakableCount = 0;
    }
}