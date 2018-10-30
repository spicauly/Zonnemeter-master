using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroClick : MonoBehaviour {

	void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        SceneManager.LoadScene("Scene 3");
    }
}
