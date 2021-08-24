using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersSettings : MonoBehaviour{
    public int health = 100;

    void Start(){
        
    }

    void Update(){
        
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

}
