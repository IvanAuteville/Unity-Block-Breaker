using UnityEngine;

public class ScreenFader : MonoBehaviour
{
    public static ScreenFader instance = null;

    private Animator animator = null;
    private int fadeTrigger = 0;
    private bool isReady = false;

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

            animator = GetComponent<Animator>();
            fadeTrigger = Animator.StringToHash("Fade");
        }
    }

    public void Fade()
    {
        animator.SetTrigger(fadeTrigger);
    }

    public void OnAnimationEventReady()
    {
        isReady = true;
    }

    public void OnAnimationEventReset()
    {
        isReady = false;
    }

    public bool IsReady()
    {
        return isReady;
    }
}