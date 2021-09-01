using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunConfigScript : MonoBehaviour{
    public Transform firePoint;
    public GameObject bullet;
    public int gunDMG;
    public float bulletSpeed;
    BulletScript bulletSource;
    public float fireRate;
    private float readyForNextShoot;
    void Start() {
        bulletSource = bullet.GetComponent<BulletScript>();
    }

    void Update() {
        if (Input.GetMouseButton(0)) {
            if(Time.time > this.readyForNextShoot) {
                this.readyForNextShoot = Time.time + 1 / this.fireRate;
                this.shoot();
            }
        }
    }

    private void shoot() {
        bulletSource.setBulletCustomDmg(gunDMG);
        bulletSource.setBullteCustomSpeed(bulletSpeed);
        Instantiate(bullet, firePoint.position, firePoint.rotation).name = "Player";
        FindObjectOfType<AudioManager>().play("shoot");
    }


}
