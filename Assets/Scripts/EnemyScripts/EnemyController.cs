using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour{
    public float movementSpeed = 7;
    public int jumpCount = 2;
    public Rigidbody2D rigidbody2D;
    public float jumpForce;
    public int health = 100;

    void Start() {

    }

    void Update() {
        playerMoving();
    }
    public void takeDamage(int dmg) {
        health = health - dmg;
        Debug.Log(gameObject.name);
        if (health <= 0) {
            die();
        }
    }

    void die() {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag.Equals("Floor")) {
            this.jumpCount = 2;
        }
    }


    private void playerMoving() {
        var horizontalInput = Input.GetAxis("Horizontal");
        transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0, 0);
        if (Input.GetButtonDown("Jump") && jumpCount > 0) {
            this.jump();
        }
    }

    private void jump() {
        this.jumpCount = this.jumpCount - 1;
        rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
