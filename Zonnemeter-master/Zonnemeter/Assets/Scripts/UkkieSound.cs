using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UkkieSound : MonoBehaviour
{

    public AudioClip audioClip;
    public static AudioSource audioSourceUkkieSound;
    public static bool soundPlayedUkkieSound = false;

    void Start()
    {
        audioSourceUkkieSound = GetComponent<AudioSource>();
        // make sure that we have an AudioSource - do this here once instead of every frame
        if (audioSourceUkkieSound == null)
        { // if AudioSource is missing
            Debug.LogWarning("AudioSource component missing from this gameobject. Adding one.");
            // let's just add the AudioSource component dynamically
            audioSourceUkkieSound = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnMouseDown()
    {
        if (!audioSourceUkkieSound.isPlaying)
        {
            if (Input.GetMouseButtonDown(0))
            {
                audioSourceUkkieSound.PlayOneShot(audioClip);
                soundPlayedUkkieSound = true;
            }
        }
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
