using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private Management management;
    private AudioSource audioSource;
	// Use this for initialization
	void Start ()
    {
        management = transform.GetComponent<Management>();
        audioSource = transform.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    /// <summary>
    /// Plays the music
    /// </summary>
    public void startMusic()
    {
        audioSource.PlayOneShot(management.backgroundMusic);
        audioSource.loop = true;
        management.playingMusic = true;
    }

    /// <summary>
    /// stops the music
    /// </summary>
    public void stopMusic()
    {
        audioSource.Stop();
        management.playingMusic = false;

    }

    /// <summary>
    /// Pauses the music
    /// </summary>
    public void pauseMusic()
    {
        audioSource.Pause();
        management.playingMusic = false;
    }
}
