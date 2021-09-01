using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
    Transform bar;
    public PlayerController player;
    void Start() {
        bar = transform.Find("Bar");
    }

    void Update() {
        if(player.getPlayerHealth() >= 0) {
            setSize((float)player.getPlayerHealth() / 100);
        }
    }

    public void setSize(float sizeNormalized) {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
}
