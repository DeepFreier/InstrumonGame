using UnityEngine;

public class BattleAudioManager : MonoBehaviour {

    [Header("--------Audio Source---------")]
    [SerializeField] AudioSource battleMusic;
    [SerializeField] AudioSource instrumonSongs;


    [Header("--------Audio Clip------------")]
    public AudioClip drumLoop;
    public AudioClip violinIntro;
    public AudioClip violinSong;
    public AudioClip tubaIntro;
    public AudioClip tubaSong;
    public AudioClip trumpetIntro;
    public AudioClip trumpetSong;
    public AudioClip tromboneIntro;
    public AudioClip tromboneSong;
    public AudioClip timpaniIntro;
    public AudioClip timpaniSong;
    public AudioClip pianoIntro;
    public AudioClip pianoSong;
    public AudioClip guitarIntro;
    public AudioClip guitarSong;
    public AudioClip fluteIntro;
    public AudioClip fluteSong;
    public AudioClip clarinetIntro;
    public AudioClip clarinetSong;
    public AudioClip celloIntro;
    public AudioClip celloSong;

    public void PlayInstrumonSongs(AudioClip clip)
    {
        instrumonSongs.PlayOneShot(clip);
    }
}
