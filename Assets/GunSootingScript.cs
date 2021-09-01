using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSootingScript : MonoBehaviour{
    public Transform firePoint;
    public GameObject bullet;
    void Start() {
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            this.shoot();
        }
    }

    private void shoot() {
        Instantiate(bullet, firePoint.position, firePoint.rotation).name = "Player";
        FindObjectOfType<AudioManager>().play("shoot");

    }


}
