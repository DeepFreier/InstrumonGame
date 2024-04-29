using UnityEngine;


public class BattleAudioManager : MonoBehaviour {

    [Header("-------Drum Track---------")]
    public AudioSource battleMusic;

    [Header("-----Back Up Tracks---------")]
    public AudioSource instrumonSongs;
    public AudioSource oppInstrumonSongs;

    [Header("--------Player Audio Source---------")]
    public AudioSource clarinetInstrumon;
    public AudioSource fluteInstrumon;
    public AudioSource saxophoneInstrumon;
    public AudioSource violinInstrumon;
    public AudioSource celloInstrumon;
    public AudioSource guitarInstrumon;
    public AudioSource pianoInstrumon;
    public AudioSource timpaniInstrumon;
    public AudioSource xylophoneInstrumon;
    public AudioSource tubaInstrumon;
    public AudioSource tromboneInstrumon;
    public AudioSource trumpetInstrumon;

    [Header("-------Opponent Audio Source--------")]
    public AudioSource oppClarinetInstrumon;
    public AudioSource oppFluteInstrumon;
    public AudioSource oppSaxophoneInstrumon;
    public AudioSource oppViolinInstrumon;
    public AudioSource oppCelloInstrumon;
    public AudioSource oppGuitarInstrumon;
    public AudioSource oppPianoInstrumon;
    public AudioSource oppTimpaniInstrumon;
    public AudioSource oppXylophoneInstrumon;
    public AudioSource oppTubaInstrumon;
    public AudioSource oppTromboneInstrumon;
    public AudioSource oppTrumpetInstrumon;


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


    private void Start()
    {
        battleMusic = GetComponent<AudioSource>();
    }
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
        //starting player songs
        battleMusic.PlayScheduled(AudioSettings.dspTime + .05f);
        clarinetInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        fluteInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        saxophoneInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        timpaniInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        pianoInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        xylophoneInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        tubaInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        trumpetInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        tromboneInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        violinInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        celloInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        guitarInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);

        //Starting opponents song
        oppClarinetInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        oppCelloInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        oppSaxophoneInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        oppTimpaniInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        oppPianoInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        oppXylophoneInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        oppTubaInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        oppTrumpetInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        oppTromboneInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        oppViolinInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        oppCelloInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);
        oppGuitarInstrumon.PlayScheduled(AudioSettings.dspTime + .05f);

    }

    public void MutePlayerSongs()
    {
        //Muting Player audio clips
        clarinetInstrumon.mute = true;
        fluteInstrumon.mute = true;
        saxophoneInstrumon.mute = true;
        trumpetInstrumon.mute = true;
        tromboneInstrumon.mute = true;
        tubaInstrumon.mute = true;
        violinInstrumon.mute = true;
        celloInstrumon.mute = true;
        guitarInstrumon.mute = true;
        pianoInstrumon.mute = true;
        timpaniInstrumon.mute = true;
        xylophoneInstrumon.mute = true;

        


        if (BattleController.playerCurrentMon.Base.instrumonName == "Corvinet") {
            clarinetInstrumon.mute = false;
        }
        if(BattleController.playerCurrentMon.Base.instrumonName == "Guitowl") {
            guitarInstrumon.mute = false;
        }
        if (BattleController.playerCurrentMon.Base.instrumonName == "Trumpig") {
            trumpetInstrumon.mute = false;
        }
        if (BattleController.playerCurrentMon.Base.instrumonName == "Elephone") {
            saxophoneInstrumon.mute = false;
        }
        if (BattleController.playerCurrentMon.Base.instrumonName == "Flumingo") {
            fluteInstrumon.mute = false;
        }
        if (BattleController.playerCurrentMon.Base.instrumonName == "Locello") {
            celloInstrumon.mute = false;
        }
        if (BattleController.playerCurrentMon.Base.instrumonName == "Tarampini") {
            timpaniInstrumon.mute = false;
        }
        if (BattleController.playerCurrentMon.Base.instrumonName == "Tortuba") {
            tubaInstrumon.mute = false;
        }
        if (BattleController.playerCurrentMon.Base.instrumonName == "Trombeaver") {
            tromboneInstrumon.mute = false;
        }
        if (BattleController.playerCurrentMon.Base.instrumonName == "Viperlin") {
            violinInstrumon.mute = false;
        }
        if (BattleController.playerCurrentMon.Base.instrumonName == "Xylynx") {
            xylophoneInstrumon.mute = false;
        }
    }


    public void MuteOppSongs()
    {
        //Muting opponent audio clips
        oppClarinetInstrumon.mute = true;
        oppFluteInstrumon.mute = true;
        oppSaxophoneInstrumon.mute = true;
        oppTrumpetInstrumon.mute = true;
        oppTromboneInstrumon.mute = true;
        oppTubaInstrumon.mute = true;
        oppViolinInstrumon.mute = true;
        oppCelloInstrumon.mute = true;
        oppGuitarInstrumon.mute = true;
        oppPianoInstrumon.mute = true;
        oppTimpaniInstrumon.mute = true;
        oppXylophoneInstrumon.mute = true;




        if (BattleController.oppCurrentMon.Base.instrumonName == "Corvinet")
        {
            oppClarinetInstrumon.mute = false;
        }
        if (BattleController.oppCurrentMon.Base.instrumonName == "Guitowl")
        {
            oppGuitarInstrumon.mute = false;
        }
        if (BattleController.oppCurrentMon.Base.instrumonName == "Trumpig")
        {
            oppTrumpetInstrumon.mute = false;
        }
        if (BattleController.oppCurrentMon.Base.instrumonName == "Elephone")
        {
            oppSaxophoneInstrumon.mute = false;
        }
        if (BattleController.oppCurrentMon.Base.instrumonName == "Flumingo")
        {
            oppFluteInstrumon.mute = false;
        }
        if (BattleController.oppCurrentMon.Base.instrumonName == "Locello")
        {
            oppCelloInstrumon.mute = false;
        }
        if (BattleController.oppCurrentMon.Base.instrumonName == "Tarampini")
        {
            oppTimpaniInstrumon.mute = false;
        }
        if (BattleController.oppCurrentMon.Base.instrumonName == "Tortuba")
        {
            oppTubaInstrumon.mute = false;
        }
        if (BattleController.oppCurrentMon.Base.instrumonName == "Trombeaver")
        {
            oppTromboneInstrumon.mute = false;
        }
        if (BattleController.oppCurrentMon.Base.instrumonName == "Viperlin")
        {
            oppViolinInstrumon.mute = false;
        }
        if (BattleController.oppCurrentMon.Base.instrumonName == "Xylynx")
        {
            oppXylophoneInstrumon.mute = false;
        }
    }
}
