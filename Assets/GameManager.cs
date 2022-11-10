using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Text scoreText;
    public Text highscoreText;

    public GameObject zombie;

    public int points = 0;
    public int highscore = 0;
    int enemyAmount = 3;

    public float spawnTime = 5f;

    void Start() {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = points.ToString() + " Points";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();

        StartCoroutine(spawnZombies());
    }

    public void AddPoint() {
        points += 1;
        scoreText.text = points.ToString() + " Points";
        if(highscore < points) {
            PlayerPrefs.SetInt("highscore", points);
        }
    }

    IEnumerator spawnZombies() {
        while (true) {
            yield return new WaitForSeconds(spawnTime);
            for(int i = 0; i < enemyAmount; i++) {
                InstantiateEnemy();
            }
        }
    }

    void InstantiateEnemy() {
        float randomLocationX = Random.Range(-22f, 22f);
        float randomLocationZ = Random.Range(-6f, 21f);
        Instantiate(zombie, new Vector3(randomLocationX, 0, randomLocationZ), Quaternion.identity);
    }

}