using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    public float movementSpeed = 7;
    public int jumpCount = 2;
    public Rigidbody2D rigidbody2D;
    public float jumpForce;
    public int health = 100;
    public ParticleSystem dust;
    private SpriteRenderer spriteRender;
    public ParticleSystem deathEffect;
    private int playerPoints = 0;
    public static bool playerIsDead = false;

    private bool runTimer = false; // for dmg effect
    private float timer = 0f; // for dmg effect

    void Start(){
        this.spriteRender = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update(){
        playerMoving();
        if (runTimer) {
            this.timer += Time.deltaTime;
            float seconds = timer % 60;
            if (seconds >= 0.1) { // dmg effect
                this.timer = 0.0f;
                this.runTimer = false;
                this.spriteRender.color = Color.white;
            }
        }
    }
    public async void takeDamage(int dmg) {
        this.health = health - dmg;
        FindObjectOfType<AudioManager>().play("dmg");
        this.runTimer = true;
        rigidbody2D.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);

        if (runTimer) {
            this.spriteRender.color = Color.red;
        }

        if (health <= 0) {
            playerIsDead = true;
            this.die();
        }
    }

    void die() {
        FindObjectOfType<AudioManager>().play("death");
        deathEffect.startColor = Color.white;
        Instantiate(deathEffect, transform.position, Quaternion.identity);
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
        FindObjectOfType<AudioManager>().play("jump");
        this.createDust();
    }

    public int getPlayerHealth() {
        return this.health;
    }
    void createDust() {
        dust.Play();
    }

    public int getPoints() {
        return this.playerPoints;
    }

    public void addPoints(int points) {
        this.playerPoints += points;
    }

    public void takePoints(int points) {
        this.playerPoints -= points;
    }
}
