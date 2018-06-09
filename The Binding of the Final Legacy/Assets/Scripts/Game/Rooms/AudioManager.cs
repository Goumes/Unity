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

    public void startMusic()
    {
        audioSource.PlayOneShot(management.backgroundMusic);
        audioSource.loop = true;
        management.playingMusic = true;
    }

    public void stopMusic()
    {
        audioSource.Stop();
        management.playingMusic = false;

    }

    public void pauseMusic()
    {
        audioSource.Pause();
        management.playingMusic = false;
    }
}
