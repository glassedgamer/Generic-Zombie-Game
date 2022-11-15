using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {

    public bool mouseOn;
    
    void Start() {
        ActivateMouse();
    }

    void ActivateMouse() {
        if(mouseOn == false) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        } else if(mouseOn) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
