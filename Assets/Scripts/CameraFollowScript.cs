using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class CameraFollowScript : MonoBehaviour {
    public Transform target;
    [Range(1,10)]
    public float smoothSpeed;
    public Vector3 offset;
    public PostProcessVolume effects;

    public void Update() {
        if (PauseMenu.gamePause) {
            effects.enabled = true;
        } else {
            effects.enabled = false;
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
}
