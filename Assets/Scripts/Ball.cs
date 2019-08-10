using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody = null;
    private Paddle paddle = null;
    private Vector3 paddleToBall;
    private static bool hasStarted = false;
    private bool collisionsEnabled = true;

    [SerializeField] private float xLaunchVelocity = 3f;
    [SerializeField] private float yLaunchVelocity = 11f;

    [SerializeField] private float xTweak = 0.3f;
    [SerializeField] private float yTweak = 0.3f;

    void Awake()
    {
        paddle = FindObjectOfType<Paddle>();
        rigidbody = GetComponent<Rigidbody2D>();

        paddleToBall = transform.localPosition - paddle.transform.localPosition;
        hasStarted = false;
    }

    void Update()
    {
        if (!hasStarted)
        {
            Init();
        }
    }

    /*
    private void OnCollisionEnter2D()
    {
        Vector2 tweak = new Vector2(Random.Range(-xTweak, xTweak), Random.Range(-yTweak, yTweak));

        if (hasStarted)
        {
            AudioManager.instance.PlayBounce();
            rigidbody.velocity += tweak;
        }
    }
    */

    private void OnCollisionEnter2D(Collision2D other)
    {
        Brick brick = other.gameObject.GetComponent<Brick>();

        if (brick != null && collisionsEnabled)
        {
            brick.OnCollision();

            collisionsEnabled = false;
            StartCoroutine(StopCollisions());
        }

        Vector2 tweak = new Vector2(Random.Range(-xTweak, xTweak), Random.Range(-yTweak, yTweak));

        if (hasStarted)
        {
            AudioManager.instance.PlayBounce();
            rigidbody.velocity += tweak;
        }
    }

    IEnumerator StopCollisions()
    {
        yield return new WaitForSeconds(0.01f);
        collisionsEnabled = true;
    }

    private void Init()
    {
        // Position the Ball above the Paddle
        transform.localPosition = paddle.transform.localPosition + paddleToBall;

        // Launch the Ball
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody.velocity = new Vector2(xLaunchVelocity, yLaunchVelocity);

            hasStarted = true;
        }
    }

    public static void ResetPosition()
    {
        hasStarted = false;
    }
}