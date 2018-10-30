using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Afsluiten : MonoBehaviour {

	void Update ()
    {
        if (Input.GetKey("escape"))
        {
            Debug.Log("afgelopen");
            Application.Quit();
        }
    }
}
