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
    public ArrayList purchasedWeapons = new ArrayList();


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
        purchasedWeapons.Add(currentGun);
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
            if(currentWeaponIndex < purchasedWeapons.Count - 1) {
                GameObject oldWeapon = (GameObject)purchasedWeapons[currentWeaponIndex];
                oldWeapon.SetActive(false);
                purchasedWeapons[currentWeaponIndex] = oldWeapon;
                
                currentWeaponIndex += 1;

                GameObject newWeapon = (GameObject)purchasedWeapons[currentWeaponIndex];
                newWeapon.SetActive(true);
                purchasedWeapons[currentWeaponIndex] = newWeapon;

                currentGun = newWeapon;
            }
        } else {
            if (currentWeaponIndex > 0) {
                GameObject oldWeapon = (GameObject)purchasedWeapons[currentWeaponIndex];
                oldWeapon.SetActive(false);
                purchasedWeapons[currentWeaponIndex] = oldWeapon;

                currentWeaponIndex -= 1;

                GameObject newWeapon = (GameObject)purchasedWeapons[currentWeaponIndex];
                newWeapon.SetActive(true);
                purchasedWeapons[currentWeaponIndex] = newWeapon;

                currentGun = newWeapon;
            }
        }
      //  GunConfigScript gunConfig = currentGun.GetComponent<GunConfigScript>();
    }



    private void faceMouse() {
        this.gunHolder.transform.right = direction;
    }

    private void movingGun() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.direction = mousePosition - (Vector2)this.gunHolder.position;
        this.faceMouse();
    }

    public void addPurchasedGun(string name) {
        foreach (GameObject gun in allGuns) {
            if (gun.name.Equals(name)) {
                this.purchasedWeapons.Add(gun);
            }
        }
       // GameObject newWeapon = allGuns[1];
        //purchasedWeapons.Add(newWeapon);
    }
}

