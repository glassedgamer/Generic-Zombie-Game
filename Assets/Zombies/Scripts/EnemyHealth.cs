using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    private GameObject gameManager;

    public UnityEngine.AI.NavMeshAgent agent;

    [SerializeField]
    private int health = 100;

    private int maxHealth = 100;

    void Start() {
        gameManager = GameObject.FindWithTag("GameManager");
    }

    public void SetHealth(int max_health, int health) {
        this.maxHealth = max_health;
        this.health = health;
    }

    public void TakeDamage(int damage) {
        // GetComponent<Enemy>().Dazed();
        // Instantiate(blood, transform.position, Quaternion.identity);

        health -= damage;
        Debug.Log("Damage dealt!");

        if(health <= 0) {
            // FindObjectOfType<AudioManager>().Play("Death");
            agent.enabled = false;
            gameManager.GetComponent<GameManager>().AddPoint();
            Destroy(this.gameObject);
        }
    }

}