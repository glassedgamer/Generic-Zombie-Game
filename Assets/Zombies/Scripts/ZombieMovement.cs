using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class ZombieMovement : MonoBehaviour {

    private GameObject player;
    // [SerializeField] Rigidbody rb;
    public NavMeshAgent agent;

    [SerializeField] float speed = 0.5f;
    [SerializeField] private int damage = 5;

    [SerializeField] private EnemyData data;

    void Start() {
        player = GameObject.FindWithTag("Player");
    }

    void Update() {
        Swarm();
    }

    void Swarm() {
        // Vector3 pos = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        // rb.MovePosition(pos);
        // transform.LookAt(player.transform.position);
        agent.enabled = true;
        agent.SetDestination(player.transform.position);
    }

    void SetEnemyValues() {
        GetComponent<EnemyHealth>().SetHealth(data.hp, data.hp);
        damage = data.damage;
    }

}
