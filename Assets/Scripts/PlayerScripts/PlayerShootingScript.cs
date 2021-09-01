using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingScript : MonoBehaviour {
    public Transform gunHolder;
    private Vector2 direction;
    private int totalWeapons;
    private int currentWeaponIndex;
    public GameObject[] guns;
    public GameObject currentGun;

    void Start() {
        totalWeapons = gunHolder.transform.childCount;
        guns = new GameObject[totalWeapons];
        for (int index = 0; index < totalWeapons; index++) {
            guns[index] = gunHolder.transform.GetChild(index).gameObject;
            guns[index].SetActive(false);
        }

        guns[0].SetActive(true);
        currentGun = guns[0];
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
            if(currentWeaponIndex < totalWeapons - 1) {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
            }
        } else {
            if (currentWeaponIndex > 0) {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex -= 1;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
            }
        }

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

