using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour{
    public GameObject spawner;
    private EnemySpawner enemySpawner;
    private GameObject player;
    private PlayerController playerController;
    private PlayerShootingScript playerShooting;

    public double spawnDelay = 1;
    private float timer = 0;



    private int enemyCountMax = 1;
    private int enemyIndex = 0;


    void Start(){
        this.enemySpawner = spawner.GetComponent<EnemySpawner>();
        this.player = GameObject.Find("Player");
        this.playerController = this.player.gameObject.GetComponent<PlayerController>();
        this.playerShooting = playerController.gameObject.GetComponentInChildren<PlayerShootingScript>();




    }

    void Update() {
        Debug.LogError(playerController.getPoints());
        playerShooting.addPurchasedGun("MachineGun");

        playerShooting.addPurchasedGun("SniperGun");
        if (enemyIndex != enemyCountMax) {
            this.spawnEnemy();
        } else if(getEnemiesCount() == 0) {
            enemyIndex = 0;
            enemyCountMax += 1;
        }
    }
    
    

    private void spawnEnemy() {
        if (this.getEnemiesCount() != enemyCountMax) {
            this.timer += Time.deltaTime;
            float seconds = timer % 60;
            if (seconds >= spawnDelay) {
                this.timer = 0.0f;
                this.enemySpawner.spawnEnemy();
                this.enemyIndex += 1;
            }
        }
    }

    public int getEnemiesCount() {
        return this.enemySpawner.getEnemiesCount();
    }

    public void killEenemy() {
        this.enemySpawner.killEnemy();
    }
}
