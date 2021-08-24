using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour{
    public Transform gunHolder;
    public Transform firePoint;
    public GameObject bullet;
    private Vector2 direction;
    void Start(){
        
    }

    void Update(){
        this.movingGun();

        if (Input.GetButtonDown("ire1")) {
            this.shoot();
        }
    }

    private void shoot() {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
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
