using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingScript : MonoBehaviour {
    public EnemyController enemyController;
    public Transform gunHolder;
    public Transform firePoint;
    public GameObject bullet;
    private Vector2 direction;
    public double shootDelay = 1.5;
    private float timer = 0;
    void Start() {

    }

    void Update() {

        if (!PlayerController.playerIsDead) {
            this.movingGun();
            this.timer += Time.deltaTime;
            float seconds = timer % 60;
            if (seconds >= shootDelay) {
                this.timer = 0.0f;
                this.shoot();
            }
        }
        int heath = enemyController.getHeath();

        if (heath <= 45 && heath >= 31) {
            this.shootDelay = 0.68;
        }else if (heath <= 30) {
            this.shootDelay = 0.28;
        }
    }

    private void shoot() {
        Instantiate(bullet, firePoint.position, firePoint.rotation).name = "Enemy(Clone)";
        FindObjectOfType<AudioManager>().play("shoot");

    }

    private void faceMouse() {
        this.gunHolder.transform.right = direction;
    }

    private void movingGun() {
        GameObject player = GameObject.Find("Player");
        if (player != null) {
            Vector2 mousePosition = player.transform.position;
            this.direction = mousePosition - (Vector2)this.gunHolder.position;
            this.faceMouse();
        }
    }
}
