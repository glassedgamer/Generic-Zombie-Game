using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour {

    [SerializeField] private EnemyData data;

    public int zombieDamage;

    void Start() {
        zombieDamage = data.damage;
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Player") {
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(zombieDamage);
            Destroy(this.gameObject);
        }
    }

}
