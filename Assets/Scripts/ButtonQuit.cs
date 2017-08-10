using UnityEngine;
using System.Collections;

public class ButtonQuit : MonoBehaviour
{

    void OnMouseDown() {

        Application.ExternalCall("CloseWindow", "1");
        Application.Quit();
    }
}
