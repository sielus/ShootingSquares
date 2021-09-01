using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSootingScript : MonoBehaviour{
    public Transform firePoint;
    public GameObject bullet;
    public int gunDMG;
    public float bulletSpeed;
    BulletScript bulletSource;
    void Start() {
        bulletSource = bullet.GetComponent<BulletScript>();
    }

    void Update() {
        if (Input.GetMouseButton(0)) {
            this.shoot();
        }
    }

    private void shoot() {
        bulletSource.setBulletCustomDmg(gunDMG);
        bulletSource.setBullteCustomSpeed(bulletSpeed);
        Instantiate(bullet, firePoint.position, firePoint.rotation).name = "Player";
        FindObjectOfType<AudioManager>().play("shoot");

    }


}
