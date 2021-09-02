using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenScript : MonoBehaviour {
    public GameObject gameHandler;
    private GameHandler handler;


    public GameObject[] buttons;
    private int totalAllButtons;


    void Start(){
        this.handler = this.gameHandler.gameObject.GetComponent<GameHandler>();
        totalAllButtons = this.transform.childCount;
        buttons = new GameObject[totalAllButtons];
        for (int index = 0; index < totalAllButtons; index++) {
            buttons[index] = this.transform.GetChild(index).gameObject;
        }
    }

    void Update(){
        if (handler.getPlayerHealth() <= 0) {
            manageDeathScreen(true);
        } else {
            manageDeathScreen(false);
        }
    }


    private void manageDeathScreen(bool active) {
        foreach (GameObject button in buttons) {
            button.gameObject.SetActive(active);
        }
    }
}
