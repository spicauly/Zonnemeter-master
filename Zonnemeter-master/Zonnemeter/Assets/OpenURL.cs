using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour {

    private void OnMouseDown()
    {
        Application.OpenURL("https://www.knmi.nl/nederland-nu/weer/waarschuwingen-en-verwachtingen/zonkracht");
    }
}
