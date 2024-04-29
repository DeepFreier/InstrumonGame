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

    public void StartInstrumonSongs()
    {
        AudioClip.FindObjectOfType<AudioSource>(clarinetSong).PlayScheduled(AudioSettings.dspTime + .05f);
        AudioClip.FindObjectOfType<AudioSource>(fluteSong).PlayScheduled(AudioSettings.dspTime + .05f);
        AudioClip.FindObjectOfType<AudioSource>(guitarSong).PlayScheduled(AudioSettings.dspTime + .05f);
        AudioClip.FindObjectOfType<AudioSource>(violinSong).PlayScheduled(AudioSettings.dspTime + .05f);
        AudioClip.FindObjectOfType<AudioSource>(tubaSong).PlayScheduled(AudioSettings.dspTime + .05f);
        AudioClip.FindObjectOfType<AudioSource>(trumpetSong).PlayScheduled(AudioSettings.dspTime + .05f);
        AudioClip.FindObjectOfType<AudioSource>(tromboneSong).PlayScheduled(AudioSettings.dspTime + .05f);
        AudioClip.FindObjectOfType<AudioSource>(pianoSong).PlayScheduled(AudioSettings.dspTime + .05f);
        AudioClip.FindObjectOfType<AudioSource>(saxophoneSong).PlayScheduled(AudioSettings.dspTime + .05f);
        AudioClip.FindObjectOfType<AudioSource>(xylophoneSong).PlayScheduled(AudioSettings.dspTime + .05f);
        AudioClip.FindObjectOfType<AudioSource>(timpaniSong).PlayScheduled(AudioSettings.dspTime + .05f);
        AudioClip.FindObjectOfType<AudioSource>(drumLoop).PlayScheduled(AudioSettings.dspTime + .05f);

        //looping the audio clips
        AudioClip.FindObjectOfType<AudioSource>(clarinetSong).loop = true;
        AudioClip.FindObjectOfType<AudioSource>(trumpetSong).loop = true;
        AudioClip.FindObjectOfType<AudioSource>(saxophoneSong).loop = true;
        AudioClip.FindObjectOfType<AudioSource>(fluteSong).loop = true;
        AudioClip.FindObjectOfType<AudioSource>(guitarSong).loop = true;
        AudioClip.FindObjectOfType<AudioSource>(celloSong).loop = true;
        AudioClip.FindObjectOfType<AudioSource>(timpaniSong).loop = true;
        AudioClip.FindObjectOfType<AudioSource>(tubaSong).loop = true;
        AudioClip.FindObjectOfType<AudioSource>(tromboneSong).loop = true;
        AudioClip.FindObjectOfType<AudioSource>(violinSong).loop = true;
        AudioClip.FindObjectOfType<AudioSource>(xylophoneSong).loop = true;
        AudioClip.FindObjectOfType<AudioSource>(drumLoop).loop = true;

    }

    public void MuteSongs()
    {
        //Muting audio clips
        AudioClip.FindObjectOfType<AudioSource>(clarinetSong).mute = true;
        AudioClip.FindObjectOfType<AudioSource>(trumpetSong).mute = true;
        AudioClip.FindObjectOfType<AudioSource>(saxophoneSong).mute = true;
        AudioClip.FindObjectOfType<AudioSource>(fluteSong).mute = true;
        AudioClip.FindObjectOfType<AudioSource>(guitarSong).mute = true;
        AudioClip.FindObjectOfType<AudioSource>(celloSong).mute = true;
        AudioClip.FindObjectOfType<AudioSource>(timpaniSong).mute = true;
        AudioClip.FindObjectOfType<AudioSource>(tubaSong).mute = true;
        AudioClip.FindObjectOfType<AudioSource>(tromboneSong).mute = true;
        AudioClip.FindObjectOfType<AudioSource>(violinSong).mute = true;
        AudioClip.FindObjectOfType<AudioSource>(xylophoneSong).mute = true;


        if(BattleController.playerCurrentMon.Base.instrumonName == "Corvinet") {
            AudioClip.FindObjectOfType<AudioSource>(clarinetSong).mute = false;
        }
        if(BattleController.playerCurrentMon.Base.instrumonName == "Guitowl") {
            AudioClip.FindObjectOfType<AudioSource>(guitarSong).mute = false;
        }
        if (BattleController.playerCurrentMon.Base.instrumonName == "Trumpig") {
            AudioClip.FindObjectOfType<AudioSource>(trumpetSong).mute = false;
        }
        if (BattleController.playerCurrentMon.Base.instrumonName == "Elephone") {
            AudioClip.FindObjectOfType<AudioSource>(saxophoneSong).mute = false;
        }
        if (BattleController.playerCurrentMon.Base.instrumonName == "Flumingo") {
            AudioClip.FindObjectOfType<AudioSource>(fluteSong).mute = false;
        }
        if (BattleController.playerCurrentMon.Base.instrumonName == "Locello") {
            AudioClip.FindObjectOfType<AudioSource>(celloSong).mute = false;
        }
        if (BattleController.playerCurrentMon.Base.instrumonName == "Tarampini") {
            AudioClip.FindObjectOfType<AudioSource>(timpaniSong).mute = false;
        }
        if (BattleController.playerCurrentMon.Base.instrumonName == "Tortuba") {
            AudioClip.FindObjectOfType<AudioSource>(tubaSong).mute = false;
        }
        if (BattleController.playerCurrentMon.Base.instrumonName == "Trombeaver") {
            AudioClip.FindObjectOfType<AudioSource>(tromboneSong).mute = false;
        }
        if (BattleController.playerCurrentMon.Base.instrumonName == "Viperlin") {
            AudioClip.FindObjectOfType<AudioSource>(violinSong).mute = false;
        }
        if (BattleController.playerCurrentMon.Base.instrumonName == "Xylynx") {
            AudioClip.FindObjectOfType<AudioSource>(xylophoneSong).mute = false;
        }

    }
}
