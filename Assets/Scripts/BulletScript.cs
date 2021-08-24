using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    public Rigidbody2D rigidbody2D;
    public float bulletSpeed = 20f;
    public int dmg = 10;
    void Start(){
        this.rigidbody2D.velocity = transform.right * this.bulletSpeed;
    }

    void Update(){
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        PlayersSettings player = collision.GetComponent<PlayersSettings>();
        if(player != null) {
            player.takeDamage(dmg);
        }


        string collisionName = collision.name;
        switch (collisionName) {
            case "Floor":
                Destroy(gameObject);
                break;
        }
    }
}
