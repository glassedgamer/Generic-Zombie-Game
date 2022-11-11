using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class ZombieMovement : MonoBehaviour {

    private GameObject player;
    // [SerializeField] Rigidbody rb;
    public NavMeshAgent agent;

    [SerializeField] private int damage = 5;

    [SerializeField] private EnemyData data;

    void Start() {
        player = GameObject.FindWithTag("Player");
    }

    void Update() {
        Swarm();
    }

    void Swarm() {
        agent.enabled = true;
        agent.SetDestination(player.transform.position);
    }

    void SetEnemyValues() {
        GetComponent<EnemyHealth>().SetHealth(data.hp, data.hp);
        damage = data.damage;
    }

    void OnTriggerEnter(Collider col) {
        agent.enabled = false;
        if(col.gameObject.name == "Player") {
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }

}
