using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    void Start() {
        FindObjectOfType<AudioManager>().Play("Zumbis de março");
    }
  
}
