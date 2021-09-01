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
    public GameObject points;

    public void Update() {
        if (PauseMenu.gamePause) {
            effects.enabled = true;
            this.audioSource.Pause();
        } else {
            effects.enabled = false;
            this.audioSource.UnPause();
            this.printPoints();
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
        points.GetComponent<TMPro.TextMeshProUGUI>().text = "POINTS : " + player.getPoints();

    }
}
