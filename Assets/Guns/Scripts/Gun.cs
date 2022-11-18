using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Gun : MonoBehaviour {

    Transform cam;

    public Text ammoText;

    public Canvas damageText;

    [SerializeField] private Animator animator;

    [SerializeField] float range = 50f;
    [SerializeField] float reloadTime = 3f;

    [SerializeField] int damage = 34;
    [SerializeField] int maxAmmo = 17;
    [SerializeField] int currentAmmo = 17;

    private bool isReloading;

    private void Awake() {
        cam = Camera.main.transform;
    }

    void Start() {
        currentAmmo = maxAmmo;
        ammoText.text = "Ammo: " + currentAmmo.ToString() + "/" + maxAmmo;
    }

    void Update() {
        if(isReloading)
            return;
        
        if(currentAmmo <= 0) {
            StartCoroutine(Reload());
            return;
        }
    }

    public void Shoot() {
        if(currentAmmo > 0) {
            FindObjectOfType<AudioManager>().Play("Pistol Shoot");
            animator.SetTrigger("Shoot");

            currentAmmo--;
            ammoText.text = "Ammo: " + currentAmmo.ToString() + "/" + maxAmmo;

            RaycastHit hit;
            if(Physics.Raycast(cam.position, cam.forward, out hit, range)) {
                if(hit.collider.GetComponent<EnemyHealth>() != null) {
                    Instantiate(damageText, hit.point, Quaternion.identity);
                    hit.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
                }
            }
        } 
    }

    IEnumerator Reload() {
        FindObjectOfType<AudioManager>().Play("Pistol Reload");
        animator.SetTrigger("Reload");
        
        isReloading = true;

        yield return new WaitForSeconds(reloadTime);
        
        currentAmmo = maxAmmo;
        ammoText.text = "Ammo: " + currentAmmo.ToString() + "/" + maxAmmo;
        isReloading = false;
    }
}
