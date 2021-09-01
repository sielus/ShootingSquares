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
    private float timer = 0;

    public int currentAmmoMagazine;
    public int ammoMagazineMax;
    public float reloadTime;

    public bool purchased;

    void Start() {
        bulletSource = bullet.GetComponent<BulletScript>();
        this.currentAmmoMagazine = ammoMagazineMax;
    }

    void Update() {
        if (Input.GetMouseButton(0)) {
            if(currentAmmoMagazine > 0) {
                if (Time.time > this.readyForNextShoot) {
                    this.readyForNextShoot = Time.time + 1 / this.fireRate;
                    this.shoot();
                }
            } else {
                this.reload();
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            this.reload();
        }
    }

    private void shoot() {
        Debug.LogError(gameObject.name);
        bulletSource.setBulletCustomDmg(gunDMG);
        bulletSource.setBullteCustomSpeed(bulletSpeed);
        Instantiate(bullet, firePoint.position, firePoint.rotation).name = "Player";
        FindObjectOfType<AudioManager>().play("shoot");
        this.currentAmmoMagazine -= 1;
    }
    
    private void reload() {
        this.currentAmmoMagazine = this.ammoMagazineMax;
    }

    public bool getPurchased() {
        return this.purchased;
    }


}
