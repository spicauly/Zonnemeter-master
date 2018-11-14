using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _time;
    private float _speed = 1;

    void Update()
    {
        _time += Time.deltaTime * _speed;
        int minutes = Mathf.FloorToInt(_time % 3600 / 60);
    }
}
