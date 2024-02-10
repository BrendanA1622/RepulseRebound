using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreChanger : MonoBehaviour
{
    [SerializeField]
    private FinalScoreFader finalScoreFader;


    [SerializeField]
    private TextMeshPro scoreText;
    [SerializeField]
    private TextMeshPro highScoreText;

    private int finalScoreAmount;
    private int scoreAmount;
    private int highScore;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("PermHighScore", 0);
        scoreAmount = 0;
        finalScoreAmount = 0;
        scoreText.text = "SCORE: " + scoreAmount;
        highScoreText.text = "HIGH SCORE: " + highScore;
    }

    public void addScoreAmount(int addedScore)
    {
        scoreAmount += addedScore;
        scoreText.text = "SCORE: " + scoreAmount;
    }

    public void resetScore()
    {
        if (scoreAmount > highScore)
        {
            highScore = scoreAmount;
        }

        finalScoreAmount = scoreAmount;
        scoreAmount = 0;

        scoreText.text = "SCORE: " + scoreAmount;
        highScoreText.text = "HIGH SCORE: " + highScore;

        PlayerPrefs.SetInt("PermHighScore", highScore);

    }

    public void showFinalScore()
    {
        finalScoreFader.flashFinalScore(finalScoreAmount);
    }
}
