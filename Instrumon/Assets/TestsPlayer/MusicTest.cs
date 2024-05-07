using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class MusicTest
{
    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator MusicTestSimplePasses()
    {
        // This test references the user story #18 for testing volume 
        // Loading the first scene to be tested
        SceneManager.LoadScene(0);
        yield return null;

        // Getting the music object in the Main Menu scene
        var musicObject = GameObject.Find("Audio Manager");
        var music = musicObject.GetComponent<AudioController>();
        yield return new WaitForSeconds(1f);

        // Checks if the music object is active and not null
        Assert.IsNotNull(music);

        // Checks to see if the music volume can be adjusted relating to the options menu
        music.musicSource.volume = .5f;
        Assert.AreEqual(music.musicSource.volume, .5f);

        yield return new WaitForSeconds(1f);

        // Loading the Second scene to be tested
        SceneManager.LoadScene(1);
        yield return null;

        // Getting the music object in the World Layer Scene
        musicObject = GameObject.Find("Audio Manager");
        music = musicObject.GetComponent<AudioController>();
        yield return new WaitForSeconds(1f);

        // Checks if the music object is active and not null
        Assert.IsNotNull(music);
        music.musicSource.volume = .5f;

        // Checks to see if the music volume can be adjusted relating to the options menu
        Assert.AreEqual(music.musicSource.volume, .5f);

        yield return new WaitForSeconds(1f);

        // Loading the third scene to be tested
        SceneManager.LoadScene(2);
        yield return null;

        // This sets the MASTER volume to be tested because the amount of audio sources is too many
        AudioListener.volume = .5f;
        yield return new WaitForSeconds(1f);
        Assert.AreEqual(AudioListener.volume, .5f);

    }
}
