using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingScript : MonoBehaviour {
    public Transform gunHolder;
    public Transform firePoint;
    public GameObject bullet;
    private Vector2 direction;
    private float timer = 0;
    void Start() {

    }

    void Update() {
        this.movingGun();

        this.timer += Time.deltaTime;
        float seconds = timer % 60;
        if (seconds >= 1.5) {
            this.timer = 0.0f;
            this.shoot();
        }

    }

    private void shoot() {
        Instantiate(bullet, firePoint.position, firePoint.rotation).name = "Enemy";
        FindObjectOfType<AudioManager>().play("shoot");

    }

    private void faceMouse() {
        this.gunHolder.transform.right = direction;
    }

    private void movingGun() {
        GameObject player = GameObject.Find("Player");
        Debug.Log(player.transform.position);
        if (player != null) {
            Vector2 mousePosition = player.transform.position;
            this.direction = mousePosition - (Vector2)this.gunHolder.position;
            this.faceMouse();
        }
    }
}
