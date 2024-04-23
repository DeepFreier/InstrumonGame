using UnityEngine;


public class BattleAudioManager : MonoBehaviour {

    [Header("--------Audio Source---------")]
    [SerializeField] AudioSource battleMusic;
    [SerializeField] AudioSource instrumonSongs;
    [SerializeField] AudioSource oppInstrumonSongs;


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
    public AudioClip saxophoneIntro;
    public AudioClip saxophoneSong;
    public AudioClip xylophoneIntro;
    public AudioClip xylophoneSong;

    public void PlayInstrumonSongs(AudioClip clip1, AudioClip clip2)
    {

        battleMusic.clip = clip2;
        instrumonSongs.clip = clip1;
        battleMusic.PlayScheduled(AudioSettings.dspTime + .05f);
        instrumonSongs.PlayScheduled(AudioSettings.dspTime + .05f);

    }

    public void OppInstrumonSongs(AudioClip clip1)
    {
        oppInstrumonSongs.clip = clip1;
        oppInstrumonSongs.PlayScheduled(AudioSettings.dspTime + .05f);

    }
}
