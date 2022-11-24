using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    private GameObject gameManager;

    public UnityEngine.AI.NavMeshAgent agent;

    [SerializeField]
    private int health = 100;

    private int maxHealth = 100;

    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject deathEffect;

    void Start() {
        gameManager = GameObject.FindWithTag("GameManager");
    }

    public void SetHealth(int max_health, int health) {
        this.maxHealth = max_health;
        this.health = health;
    }

    public void TakeDamage(int damage, Vector3 hitPos, Vector3 hitNormal) {
        GameObject clone = Instantiate(hitEffect, hitPos, Quaternion.LookRotation(hitNormal));

        health -= damage;
        Debug.Log("Damage dealt!");

        if(health <= 0) {
            // FindObjectOfType<AudioManager>().Play("Death");
            agent.enabled = false;

            if(this.gameObject.name == "Zombie Baby(Clone)") {
                gameManager.GetComponent<GameManager>().AddPoint(1);
            } else if(this.gameObject.name == "Zombie Normal(Clone)") {
                gameManager.GetComponent<GameManager>().AddPoint(2);
            } else if(this.gameObject.name == "Zombie Brute(Clone)") {
                gameManager.GetComponent<GameManager>().AddPoint(3);
            }
            
            GameObject deathClone = Instantiate(deathEffect, this.transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Zombie Die");
            Destroy(this.gameObject);
        }
    }

}