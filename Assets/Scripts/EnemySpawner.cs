using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy;
    public double spawnDelay = 2;
    private float timer = 0;
    public int enemyMax = 5;
    public int enemyCount;
    void Start(){
    }

    void Update(){


    }

    public void spawnEnemy() {
        enemy.name = "Enemy";
        this.enemyCount += 1;
        Instantiate(enemy, new Vector2(Random.Range(-20.0f, 20.0f), 0), Quaternion.identity);
    }
    
    public int getEnemiesCount() {
        return this.enemyCount;
    }

    public void killEnemy() {
        this.enemyCount -= 1;
    }
}
