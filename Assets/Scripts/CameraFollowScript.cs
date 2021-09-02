using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using TMPro;

public class CameraFollowScript : MonoBehaviour {
    public Transform target;
    [Range(1,10)]
    public float smoothSpeed;
    public Vector3 offset;
    public PostProcessVolume effects;
    public AudioSource audioSource;
    public GameObject pointsText;
    public GameObject currentAmmoText;
    public GameObject enemyCountText;
    public GameObject gameHandler;
    private GameHandler handler;
    PlayerController player;


    private void Start() {
        this.handler = this.gameHandler.GetComponentInChildren<GameHandler>();
        this.player = target.gameObject.GetComponent<PlayerController>();
    }
    public void Update() {
        if (PlayerController.playerIsDead) {
            effects.enabled = true;
            this.audioSource.Pause();
            manageTexts(false);
        }
        if (PauseMenu.gamePause) {
            effects.enabled = true;
            this.audioSource.Pause();
            manageTexts(false);
        } else {
            if(player != null) {
                effects.enabled = false;
                manageTexts(true);
                this.audioSource.UnPause();
                this.printPoints();
                this.printAmmo();
                this.printEnemyCount();

            }
        }
    }

    private void FixedUpdate() {
        if(target != null) {
            follow();
        }
    }

    private void follow() {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);
        transform.position = smoothedPosition;
    }
    
    private void printPoints() {
        PlayerController player = target.gameObject.GetComponent<PlayerController>();
        pointsText.GetComponent<TMPro.TextMeshProUGUI>().text = "POINTS : " + player.getPoints();
    }

    private void manageTexts(bool active) {
        currentAmmoText.SetActive(active);
        pointsText.SetActive(active);
        enemyCountText.SetActive(active);
    }

    private void printAmmo() {
        GunConfigScript gunConfig = target.gameObject.GetComponentInChildren<GunConfigScript>();
        currentAmmoText.GetComponent<TMPro.TextMeshProUGUI>().text = gunConfig.getCurrentWeapon() + " | " 
            + gunConfig.getCurrentAmmo() + " / "
            + gunConfig.getCurrentAmmoMax();
    }

    private void printEnemyCount() {
    //    GameHandler gameHandler = this.gameHandler.GetComponentInChildren<GameHandler>();
        enemyCountText.GetComponent<TMPro.TextMeshProUGUI>().text = ("ENEMIES : " 
            +  handler.getEnemiesCount().ToString());
    }
}
