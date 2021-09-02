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


    public void Update() {
        if (PauseMenu.gamePause) {
            effects.enabled = true;
            this.audioSource.Pause();
        } else {
            effects.enabled = false;
            this.audioSource.UnPause();
            this.printPoints();
            this.printAmmo();
            this.printEnemyCount();
        }
    }

    private void FixedUpdate() {
        follow();
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

    private void printAmmo() {
        GunConfigScript gunConfig = target.gameObject.GetComponentInChildren<GunConfigScript>();
        currentAmmoText.GetComponent<TMPro.TextMeshProUGUI>().text = gunConfig.getCurrentWeapon() + " | " 
            + gunConfig.getCurrentAmmo() + " / "
            + gunConfig.getCurrentAmmoMax();
    }

    private void printEnemyCount() {
        GameHandler gameHandler = this.gameHandler.GetComponentInChildren<GameHandler>();
        enemyCountText.GetComponent<TMPro.TextMeshProUGUI>().text = ("ENEMIES : " 
            +  gameHandler.getEnemiesCount().ToString());
    }
}
