using UnityEngine;

[System.Serializable]
public struct Sound
{
    [SerializeField] public AudioClip sound;
    [Range(0f,1f)] public float volume;
}