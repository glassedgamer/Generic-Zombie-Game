using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    void Start() {
        FindObjectOfType<AudioManager>().Play("Game Over");
    }

}
