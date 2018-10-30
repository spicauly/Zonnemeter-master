using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAudio : MonoBehaviour
{
    public void StopSound()
    {
        if (EnterTime.soundPlayedEnterTime == true)
            EnterTime.audioSourceEnterTime.Stop();

        if (UkkieSound.soundPlayedUkkieSound == true)
            UkkieSound.audioSourceUkkieSound.Stop();
    }
}
