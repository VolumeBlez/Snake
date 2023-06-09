using UnityEngine;

public class AudioPlayer : MonoBehaviour, IAudioPlayer
{
    [SerializeField] private AudioSource _source;
    public void Play(AudioClip clip)
    {
        _source.Stop();
        _source.PlayOneShot(clip);
    }
}
