using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    [SerializeField] private Sound[] clips = null;

    private AudioSource [] audioSources = null;
    [SerializeField] private Vector3 cameraCenter = new Vector3(8f, 6f, -10f);

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

            audioSources = GetComponents<AudioSource>();
            PlayMainMenu();

            //cameraCenter = Camera.main.transform.position;
        }
    }

    public void PlayMainMenu()
    {
        audioSources[0].Stop();
        audioSources[0].clip = clips[0].sound;
        audioSources[0].volume = clips[0].volume;
        audioSources[0].loop = true;
        audioSources[0].Play();
    }

    public void PlayBounce()
    {
        AudioSource.PlayClipAtPoint(clips[1].sound, cameraCenter, clips[1].volume);
    }

    public void PlayHit()
    {
        AudioSource.PlayClipAtPoint(clips[2].sound, cameraCenter, clips[2].volume);
    }

    public void PlayLifeLost()
    {
        AudioSource.PlayClipAtPoint(clips[3].sound, cameraCenter, clips[3].volume);
    }

    public void PlayLevelUp()
    {
        audioSources[1].Stop();
        audioSources[1].clip = clips[4].sound;
        audioSources[1].volume = clips[4].volume;
        audioSources[1].loop = false;
        audioSources[1].Play();
    }

    public void PlayGameOver()
    {
        audioSources[0].Stop();
        audioSources[0].clip = clips[5].sound;
        audioSources[0].volume = clips[5].volume;
        audioSources[0].loop = false;
        audioSources[0].Play();
    }

    public void PlayGameWon()
    {
        audioSources[0].Stop();
        audioSources[0].clip = clips[6].sound;
        audioSources[0].volume = clips[6].volume;
        audioSources[0].loop = false;
        audioSources[0].Play();
    }
}
