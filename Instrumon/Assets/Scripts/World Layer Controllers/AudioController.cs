using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip background;


    private void Awake()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}
