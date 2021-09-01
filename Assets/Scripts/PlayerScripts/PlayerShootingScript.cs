using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingScript : MonoBehaviour {
    public Transform gunHolder;
    private Vector2 direction;

    void Start() {

    }

    void Update() {
        if (!PauseMenu.gamePause) {
            this.movingGun();
        }

    }



    private void faceMouse() {
        this.gunHolder.transform.right = direction;
    }

    private void movingGun() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.direction = mousePosition - (Vector2)this.gunHolder.position;
        this.faceMouse();
    }
}

