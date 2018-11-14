using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnterTime : MonoBehaviour
{
    public InputField inputTextHour;
    public InputField inputTextMinute;
    public GameObject wrongTime;
    public GameObject rightTime;
    public AudioClip audioClip;
    public static AudioSource audioSourceEnterTime;
    public static bool soundPlayedEnterTime = false;

    private string _hourText;
    private string _minuteText;
    private int _hour;
    private int _minute;
    private DateTime _currentTime = DateTime.Now;
    private DateTime _newTime;
    private TimeSpan _thirtyMinutes;
    private TimeSpan _timeDifference;
    private TimeSpan _zeroTime;
    private bool _timeEntered;
    
    private void Start()
    {
        inputTextHour.text = _hourText;
        inputTextMinute.text = _minuteText;
        _thirtyMinutes = new TimeSpan(0, 30, 0);
        _zeroTime = new TimeSpan(0, 0, 0);

        audioSourceEnterTime = GetComponent<AudioSource>();
        // make sure that we have an AudioSource - do this here once instead of every frame
        if (audioSourceEnterTime == null)
        { // if AudioSource is missing
            Debug.LogWarning("AudioSource component missing from this gameobject. Adding one.");
            // let's just add the AudioSource component dynamically
            audioSourceEnterTime = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (_timeEntered == true)
        {
            _currentTime = DateTime.Now;
            _timeDifference = _newTime - _currentTime;

            if (_timeDifference <= _thirtyMinutes)
            {
                if (soundPlayedEnterTime == false)
                {
                    audioSourceEnterTime.PlayOneShot(audioClip);
                    soundPlayedEnterTime = true;
                    StartCoroutine(SoundActivation());
                }

                if (Input.GetKey("escape"))
                {
                    Debug.Log("afgelopen");
                    Application.Quit();
                }
            }
        }
    }

    public void SaveTime()
    {
        _hourText = inputTextHour.text;
        _minuteText = inputTextMinute.text;
        _hour = int.Parse(_hourText);
        _minute = int.Parse(_minuteText);

        _newTime = new DateTime(_currentTime.Year, _currentTime.Month, _currentTime.Day, _hour, _minute, 0);

        if (_hour >= 24 || _minute >= 60 || _newTime.Subtract(_currentTime) <= _zeroTime || _newTime.Subtract(_currentTime) <= _thirtyMinutes)
        {
            wrongTime.SetActive(true);
            StartCoroutine(ActivationRoutineWrong());
        }

        else
        {
            _timeEntered = true;
            rightTime.SetActive(true);
            StartCoroutine(ActivationRoutineRight());

            Debug.Log(_newTime.Subtract(_currentTime));
        }
    }

    private IEnumerator ActivationRoutineWrong()
    {
        yield return new WaitForSeconds(2);

        wrongTime.SetActive(false);
    }

    private IEnumerator ActivationRoutineRight()
    {
        yield return new WaitForSeconds(2);

        rightTime.SetActive(false);
    }

    private IEnumerator SoundActivation()
    {
        yield return new WaitForSeconds(15);

        soundPlayedEnterTime = false;
    }
}
