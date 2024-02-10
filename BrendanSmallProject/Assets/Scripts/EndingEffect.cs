using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingEffect : MonoBehaviour
{
    [SerializeField]
    private AudioSource scorePointsSound;

    [SerializeField]
    private SpriteRenderer greenBackTile;
    [SerializeField]
    private ParticleSystem endParticles;
    [SerializeField]
    private int scoreAmount;

    [SerializeField]
    private ScoreChanger scoreObject;

    private bool decreaseAlpha;

    private Color squareColor;

    void Start()
    {
        decreaseAlpha = false;
        squareColor = Color.green;
        squareColor.a = 0f;
    }

    void Update()
    {
        if (decreaseAlpha)
        {
            squareColor.a -= 0.01f;
        }

        greenBackTile.color = squareColor;
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        squareColor.a = 0.5f;
        Invoke("decreaseTileAlpha", 0.5f);

        endParticles.Play(true);

        scorePointsSound.Play();

        scoreObject.addScoreAmount(scoreAmount);
    }

    private void decreaseTileAlpha()
    {
        decreaseAlpha = true;
    }
}