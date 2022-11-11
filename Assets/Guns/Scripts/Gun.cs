using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Gun : MonoBehaviour {

    Transform cam;

    public Text ammoText;

    [SerializeField] private Animator animator;

    [SerializeField] float range = 50f;
    [SerializeField] float reloadTime = 3f;

    [SerializeField] int damage = 34;
    [SerializeField] int ammo = 17;

    private void Awake() {
        cam = Camera.main.transform;
    }

    void Start() {
        ammoText.text = "Ammo: " + ammo.ToString() + "/17";
    }

    public void Shoot() {
        if(ammo > 0) {
            animator.SetTrigger("Shoot");

            ammo--;
            ammoText.text = "Ammo: " + ammo.ToString() + "/17";

            RaycastHit hit;
            if(Physics.Raycast(cam.position, cam.forward, out hit, range)) {
                if(hit.collider.GetComponent<EnemyHealth>() != null) {
                    hit.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
                }
            }
        } else if(ammo == 0 || ammo < 0) {
            StartCoroutine(ReloadTime());
        }
    }

    IEnumerator ReloadTime() {
        yield return new WaitForSeconds(reloadTime);
        ammo = 17;
        ammoText.text = "Ammo: " + ammo.ToString() + "/17";
    }
}
