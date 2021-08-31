using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy;
    public ArrayList enemies = new ArrayList();
    public double spawnDelay = 2;
    private float timer = 0;
    public int enemyMax = 5;
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        this.timer += Time.deltaTime;
        float seconds = timer % 60;
        if (seconds >= spawnDelay) {
            this.timer = 0.0f;
            this.spawnEnemy();
        }

    }


    private void spawnEnemy() {
        if(this.enemies.Count != this.enemyMax) {
            this.enemy.name = "Enemy";
            enemies.Add(this.enemy);
            Instantiate(enemy, new Vector2(Random.Range(-20.0f, 20.0f), 0), Quaternion.identity);
        }
    }

    public ArrayList getEnemiesList() {
        return this.enemies;
    }
}
