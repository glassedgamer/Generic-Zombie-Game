using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    [Header("Score Text")]
    public Text scoreText;
    public Text highscoreText;

    [Header("Zombies")]
    public GameObject[] zombies;
    public int randomInt;
    public int enemyAmount = 3;
    public float spawnTime = 5f;

    [Header("Points")]
    public int bruteValue = 3;
    public int normalValue = 2;
    public int babyValue = 1;

    public int points = 0;
    public int highscore = 0;
    
    void Start() {
        FindObjectOfType<AudioManager>().Play("GZG Division");

        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = points.ToString() + " Points";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();

        StartCoroutine(spawnZombies());
    }

    public void AddPoint(int value) {
        points += value;
        scoreText.text = points.ToString() + " Points";
        if(highscore < points) {
            PlayerPrefs.SetInt("highscore", points);
        }
    }

    // public void BruteAddPoint() {
    //     points += bruteValue;
    //     scoreText.text = points.ToString() + " Points";
    //     if(highscore < points) {
    //         PlayerPrefs.SetInt("highscore", points);
    //     }
    // }

    // public void NormalAddPoint() {
    //     points += normalValue;
    //     scoreText.text = points.ToString() + " Points";
    //     if(highscore < points) {
    //         PlayerPrefs.SetInt("highscore", points);
    //     }
    // }

    // public void BabyAddPoint() {
    //     points += babyValue;
    //     scoreText.text = points.ToString() + " Points";
    //     if(highscore < points) {
    //         PlayerPrefs.SetInt("highscore", points);
    //     }
    // }

    IEnumerator spawnZombies() {
        while (true) {
            yield return new WaitForSeconds(spawnTime);
            for(int i = 0; i < enemyAmount; i++) {
                InstantiateEnemy();
            }
        }
    }

    void InstantiateEnemy() {
        randomInt = Random.Range(0, 3);

        float randomLocationX = Random.Range(-22f, 22f);
        float randomLocationZ = Random.Range(-6f, 21f);

        GameObject clone = Instantiate(zombies[randomInt], new Vector3(randomLocationX, 0, randomLocationZ), Quaternion.identity);
    }

}