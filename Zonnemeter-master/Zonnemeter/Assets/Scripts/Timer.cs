using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float time;
    float speed = 1;

    void Update()
    {
        time += Time.deltaTime * speed;
        int minutes = Mathf.FloorToInt(time % 3600 / 60);
    }
}
