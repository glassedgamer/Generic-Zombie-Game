using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth;

    GameObject levelChanger;

    public HealthBar healthBar;

    public Animator damageAnim;
    
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
        FindObjectOfType<AudioManager>().Play("Player Hit");
        damageAnim.SetTrigger("Hit");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
