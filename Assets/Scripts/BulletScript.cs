using System.Collections;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    public Rigidbody2D rigidbody2D;
    public float bulletSpeed = 20f;
    public int dmg = 10;
    public Material playerBulletTrail;
    public Material enemyBulletTrail;



    void Start() {
        this.rigidbody2D.velocity = transform.right * this.bulletSpeed;
    }

    void Update() {
        if (this.gameObject.name == "Player") {
            this.gameObject.transform.GetComponentInParent<TrailRenderer>().material = this.playerBulletTrail;
        } else {
            this.gameObject.transform.GetComponentInParent<TrailRenderer>().material = this.enemyBulletTrail;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        EnemyController player = collision.GetComponent<EnemyController>();
        if (player != null) {
            player.takeDamage(dmg);
        }


        string collisionName = collision.name;
        switch (collisionName) {
            case "Floor":
                Destroy(gameObject);
                break;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision) {
        if (gameObject.name != collision.gameObject.name) {
            if (collision.gameObject.name == "Enemy(Clone)") {
                EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
                if (enemy != null) {
                    enemy.takeDamage(dmg);
                    Destroy(gameObject);
                }
            } else if (collision.gameObject.name == "Player") {
                PlayerController player = collision.gameObject.GetComponent<PlayerController>();
                if (player != null) {
                    player.takeDamage(dmg);
                    Destroy(gameObject);

                }
            }
        }




        string collisionName = collision.gameObject.name;
        switch (collisionName) {
            case "Floor":
                Destroy(gameObject);
                break;
        }
    }


}
