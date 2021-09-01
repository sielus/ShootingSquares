using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour{
    public static bool gamePause = false;
    public GameObject pauseMenuUI;  
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gamePause) {
                this.resumeGame();
            } else {
                this.pauseGame();
            }
        }
    }

    private void resumeGame() {
        this.pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePause = false;
    }

    private void pauseGame() {
        this.pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePause = true;
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        this.resumeGame();
    }
    public void exitGame() {
        Application.Quit();
    }
}
