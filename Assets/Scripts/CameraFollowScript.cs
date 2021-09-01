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


    public void Update() {
        if (PauseMenu.gamePause) {
            effects.enabled = true;
            this.audioSource.Pause();
        } else {
            effects.enabled = false;
            this.audioSource.UnPause();
            this.printPoints();
            this.printAmmo();
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
        PlayerShootingScript gunConfig = target.gameObject.GetComponentInChildren<PlayerShootingScript>();
        gunConfig.addPurchasedGun("ShotGun");

    }

    private void printAmmo() {
        GunConfigScript gunConfig = target.gameObject.GetComponentInChildren<GunConfigScript>();
        currentAmmoText.GetComponent<TMPro.TextMeshProUGUI>().text = gunConfig.getCurrentWeapon() + " | " + gunConfig.getCurrentAmmo() + " / " + gunConfig.getCurrentAmmoMax();
    }
}
