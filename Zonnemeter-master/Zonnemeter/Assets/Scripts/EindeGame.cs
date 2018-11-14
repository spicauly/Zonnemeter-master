using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EindeGame : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource _audioSource;

    // Use this for initialization
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        // make sure that we have an AudioSource - do this here once instead of every frame
        if (_audioSource == null)
        { // if AudioSource is missing
            Debug.LogWarning("AudioSource component missing from this gameobject. Adding one.");
            // let's just add the AudioSource component dynamically
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnMouseDown()
    {
        if (!_audioSource.isPlaying)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _audioSource.PlayOneShot(audioClip);
                StartCoroutine(QuitGame());
            }
        }
    }

    private IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(4);
        Debug.Log("UIT");
        Application.Quit();
    }
}
