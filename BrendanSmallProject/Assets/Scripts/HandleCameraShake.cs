using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCameraShake : MonoBehaviour
{
    [SerializeField]
    private AudioSource playerDiedSound;

    [SerializeField]
    private CameraShake cameraShaker;

    [SerializeField]
    private float deathShakeDur;
    [SerializeField]
    private float deathShakeMag;

    public void handleCamShake()
    {
        StartCoroutine(cameraShaker.Shake(deathShakeDur, deathShakeMag));

        playerDiedSound.Play();
    }
}
