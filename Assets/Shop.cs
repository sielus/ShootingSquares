using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour{
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

    private void Update() {
        if (!handler.getRoundPlaying()) {  //Open Shop
            manageShop(true);
        } else {
            manageShop(false);
        }
    }

    public void buyWeapon(Button button) {
        if(handler.getPlayerPoints() > 10) {
            handler.buyWeapon(button.gameObject.name);
            handler.startNextRound();
            handler.takePlayerPoints(10);
            button.enabled = false;
        }
    }

    private void manageShop(bool active) {
        foreach (GameObject button in buttons) {
            button.gameObject.SetActive(active);
        }
    }

    public void continueGame() {
        handler.startNextRound();
    }

}
