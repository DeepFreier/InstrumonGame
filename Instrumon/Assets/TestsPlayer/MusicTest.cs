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
        // Use the Assert class to test conditions
        SceneManager.LoadScene(0);
        yield return null;
        var musicObject = GameObject.Find("Audio Manager");
        var music = musicObject.GetComponent<AudioController>();
        yield return new WaitForSeconds(1f);
        Assert.IsNotNull(music);
        music.musicSource.volume = .5f;
        Assert.AreEqual(music.musicSource.volume, .5f);

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(1);
        yield return null;
        musicObject = GameObject.Find("Audio Manager");
        music = musicObject.GetComponent<AudioController>();
        yield return new WaitForSeconds(1f);
        Assert.IsNotNull(music);
        music.musicSource.volume = .5f;
        Assert.AreEqual(music.musicSource.volume, .5f);

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(2);
        yield return null;
        AudioListener.volume = .5f;
        yield return new WaitForSeconds(1f);
        Assert.AreEqual(AudioListener.volume, .5f);

    }
}
