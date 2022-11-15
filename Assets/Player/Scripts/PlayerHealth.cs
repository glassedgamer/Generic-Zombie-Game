using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth;

    GameObject levelChanger;

    public HealthBar healthBar;
    
    void Start() {
        levelChanger = GameObject.FindWithTag("LevelChanger");
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update() {
        if(currentHealth <= 0) {
            FindObjectOfType<AudioManager>().Stop("GZG Division");
            levelChanger.GetComponent<LevelChanger>().LoadNextLevel();
        }
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
