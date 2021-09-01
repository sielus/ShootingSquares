using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingScript : MonoBehaviour {
    public Transform gunHolder;
    private Vector2 direction;
    private int totalAllWeapons;
    
    
    public GameObject[] allGuns;
    public GameObject currentGun;

    private int currentWeaponIndex;
    public ArrayList purchasedWeapons;

    void Start() {
        totalAllWeapons = gunHolder.transform.childCount;
        allGuns = new GameObject[totalAllWeapons];
        for (int index = 0; index < totalAllWeapons; index++) {
            allGuns[index] = gunHolder.transform.GetChild(index).gameObject;
            allGuns[index].SetActive(false);
        }

        allGuns[0].SetActive(true);
        currentGun = allGuns[0];
        currentWeaponIndex = 0;

    }

    void Update() {
        if (!PauseMenu.gamePause) {
            this.movingGun();
            if(Input.mouseScrollDelta.y < 0) {
                this.changeWeapon(false);
            } else if(Input.mouseScrollDelta.y > 0) {
                this.changeWeapon(true);
            }
        }

    }

    private void changeWeapon(bool up) {
        if (up) {
            if(currentWeaponIndex < totalAllWeapons - 1) {
                allGuns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                allGuns[currentWeaponIndex].SetActive(true);
                currentGun = allGuns[currentWeaponIndex];

            }
        } else {
            if (currentWeaponIndex > 0) {
                allGuns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex -= 1;
                allGuns[currentWeaponIndex].SetActive(true);
                currentGun = allGuns[currentWeaponIndex];
            }
        }
        GunConfigScript gunConfig = currentGun.GetComponent<GunConfigScript>();
        Debug.LogError(currentGun.name + " " + gunConfig.getPurchased());
    }



    private void faceMouse() {
        this.gunHolder.transform.right = direction;
    }

    private void movingGun() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.direction = mousePosition - (Vector2)this.gunHolder.position;
        this.faceMouse();
    }
}

