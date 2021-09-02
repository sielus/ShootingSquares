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
    private float readyForNextReload;

    public int currentAmmoMagazine;
    public int ammoMagazineMax;
    public float reloadTime;

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
                StartCoroutine(this.reload());
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            StartCoroutine(this.reload());
        }
    }

    private void shoot() {
        bulletSource.setBulletCustomDmg(gunDMG);
        bulletSource.setBullteCustomSpeed(bulletSpeed);
        Instantiate(bullet, firePoint.position, firePoint.rotation).name = "Player";
        FindObjectOfType<AudioManager>().play("shoot");
        this.currentAmmoMagazine -= 1;
    }

    IEnumerator reload() {
        yield return new WaitForSeconds(reloadTime);
        this.currentAmmoMagazine = this.ammoMagazineMax;
    }

    public string getCurrentWeapon() {
        return this.gameObject.name;
    }

    public int getCurrentAmmo() {
        return this.currentAmmoMagazine;
    }

    public int getCurrentAmmoMax() {
        return this.ammoMagazineMax;
    }

}
