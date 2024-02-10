using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject deathParticles;

    [SerializeField]
    private HandleCameraShake shakeHandler;

    [SerializeField]
    private ScoreChanger scoreKeeper;

    [SerializeField]
    private StartBoxDrop boxDropper;

    [SerializeField]
    private ResetPlayer playerMover;



    void OnTriggerEnter2D(Collider2D player)
    {
        scoreKeeper.resetScore();
        playerMover.resetPlayerPosition();
        boxDropper.resetStartBox();
        shakeHandler.handleCamShake();

        deathParticles.SetActive(true);
        Invoke("deactivateParticles", 5.0f);

        scoreKeeper.showFinalScore();

    }

    private void deactivateParticles()
    {
        deathParticles.SetActive(false);
    }
}
