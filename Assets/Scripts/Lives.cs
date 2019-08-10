using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField] private Sprite[] livesSprite = null;
    private SpriteRenderer spriteRenderer = null;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = livesSprite[2];
    }

    public void LoadSprites(int index)
    {
        spriteRenderer.sprite = livesSprite[index - 1];
    }
}