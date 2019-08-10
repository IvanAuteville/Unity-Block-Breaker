using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Ball ball = null;
    private float mousePosInBlocksUnits;
    private Vector3 paddlePos;

    [SerializeField] private bool autoPlay = false;
    [SerializeField] private float minPos = 1.84f;
    [SerializeField] private float maxPos = 14.14f;
    [SerializeField] private float screenWidthInBlocksUnits = 16f;

    void Awake()
    {
        Cursor.visible = false;

        paddlePos = new Vector3(transform.localPosition.x, transform.localPosition.y, 0f);

        ball = FindObjectOfType<Ball>();
    }

    void Update()
    {
        if (autoPlay)
        {
            AutoPlay();
        }
        else
        {
            Play();
        }
    }

    private void Play()
    {
        mousePosInBlocksUnits = ((Input.mousePosition.x / Screen.width) * screenWidthInBlocksUnits);
        paddlePos.x = Mathf.Clamp(mousePosInBlocksUnits, minPos, maxPos);
        transform.localPosition = paddlePos;
    }

    private void AutoPlay()
    {
        paddlePos.x = Mathf.Clamp(ball.transform.localPosition.x, minPos, maxPos);
        transform.localPosition = paddlePos;
    }
}