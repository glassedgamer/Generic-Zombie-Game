using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    Transform cam;

    [SerializeField] private Animator animator;

    [SerializeField] float range = 50f;
    [SerializeField] int damage = 34;

    private void Awake() {
        cam = Camera.main.transform;
    }

    public void Shoot() {
        animator.SetTrigger("Shoot");
        RaycastHit hit;
        if(Physics.Raycast(cam.position, cam.forward, out hit, range)) {
            if(hit.collider.GetComponent<EnemyHealth>() != null) {
                hit.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
        }
    }

}
