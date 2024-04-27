using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    public AudioClip background;

    private void Awake()
    {
        LoadVolume();
        musicSource.clip = background;
        musicSource.Play();
    }

    private void LoadVolume()
    {
        if (PlayerPrefs.HasKey("Music"))
        {
            float volume = PlayerPrefs.GetFloat("Music");
            AudioListener.volume = volume;
        }
    }
}
