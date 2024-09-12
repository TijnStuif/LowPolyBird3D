using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    public AudioClip backgroundMusic;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip scoreSound;

    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
