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

    string hourText;
    string minuteText;

    int hour;
    int minute;

    DateTime currentTime = DateTime.Now;
    DateTime newTime;
    TimeSpan thirtyMinutes;
    TimeSpan timeDifference;
    TimeSpan zeroTime;

    bool timeEntered;
    public static bool soundPlayedEnterTime = false;

    private void Start()
    {
        inputTextHour.text = hourText;
        inputTextMinute.text = minuteText;
        thirtyMinutes = new TimeSpan(0, 30, 0);
        zeroTime = new TimeSpan(0, 0, 0);

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
        if (timeEntered == true)
        {
            currentTime = DateTime.Now;
            timeDifference = newTime - currentTime;

            if (timeDifference <= thirtyMinutes)
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
        hourText = inputTextHour.text;
        minuteText = inputTextMinute.text;
        hour = int.Parse(hourText);
        minute = int.Parse(minuteText);

        newTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, hour, minute, 0);

        if (hour < 24 && minute < 60 && newTime.Subtract(currentTime) > zeroTime && newTime.Subtract(currentTime) > thirtyMinutes)
        {
            timeEntered = true;
            rightTime.SetActive(true);
            StartCoroutine(ActivationRoutineRight());

            Debug.Log(newTime.Subtract(currentTime));
        }

        else
        {
            wrongTime.SetActive(true);
            StartCoroutine(ActivationRoutineWrong());
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
