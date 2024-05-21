using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public bool gameStarted = false;
    public bool gamePaused = false;

    public AudioClip pauseAudio;
    
    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }

        StartCoroutine("StartGame");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            gamePaused = !gamePaused;
            if (gamePaused)
            {
                PlayPauseMusic();
            } else
            {
                StopPauseMusic();
            }
        }
    }

    void PlayPauseMusic()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.clip = pauseAudio;
        source.loop = true;
        source.Play();
    }

    void StopPauseMusic()
    {
        GetComponent<AudioSource>().Stop();
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSecondsRealtime(4.0f);
        gameStarted = true;
    }
}
