using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour{
    public float movementSpeed = 7;
    public float jumpForce = 8;
    public ParticleSystem dust;
    public ParticleSystem deathEffect;


    public Rigidbody2D rigidbody2D;
    public int health;

    private GameObject playerTarget;
    public float stoppingDistance;
    public float retratDistance;
    public int enemyHeadPoints = 15;

    void Start() {
        this.playerTarget = GameObject.Find("Player");
    }

    void Update() {
        playerMoving();
    }
    public void takeDamage(int dmg) {
        health = health - dmg;
        FindObjectOfType<AudioManager>().play("dmg");
        this.jump();
        if (health <= 0) {
            die();
        }
    }

    void die() {
        PlayerController player = this.playerTarget.GetComponent<PlayerController>();
        player.addPoints(this.enemyHeadPoints);
        FindObjectOfType<AudioManager>().play("death");
        deathEffect.startColor = Color.red;
        Instantiate(deathEffect,transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    private void playerMoving() {
        if (Vector2.Distance(this.transform.position, this.playerTarget.transform.position) > this.stoppingDistance) {
            this.transform.position = Vector2.MoveTowards(this.transform.position, this.playerTarget.transform.position, movementSpeed * Time.deltaTime);
        } else if (Vector2.Distance(this.transform.position, this.playerTarget.transform.position) < this.stoppingDistance &&
             Vector2.Distance(this.transform.position, this.playerTarget.transform.position) > this.retratDistance) {
            this.transform.position = this.transform.position;
        } else if (Vector2.Distance(this.transform.position, this.playerTarget.transform.position) < this.retratDistance) {
            this.transform.position = Vector2.MoveTowards(this.transform.position, this.playerTarget.transform.position, -movementSpeed * Time.deltaTime);
 
        }
    }

    private void jump() {
        rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        FindObjectOfType<AudioManager>().play("jump");
        this.createDust();

    }

    void createDust() {
        dust.Play();
    }

    public int getHeath() {
        return this.health;
    }

}
