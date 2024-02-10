using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreFader : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro finalScoreText;
    [SerializeField]
    private TextMeshPro finalScoreShadowText;
    [SerializeField]
    private float increaseAlphaRate;
    [SerializeField]
    private float decreaseAlphaRate;
    [SerializeField]
    private float fadeInDuration;

    private float finalScoreAlpha;

    private Color finalScoreColor;
    private Color finalScoreShadowColor;

    void Start()
    {
        finalScoreAlpha = 0;

        finalScoreColor = finalScoreText.color;
        finalScoreColor.a = 0f;
        finalScoreShadowColor = finalScoreShadowText.color;
        finalScoreShadowColor.a = 0f;

        finalScoreText.color = finalScoreColor;
        finalScoreShadowText.color = finalScoreShadowColor;
    }

    public void flashFinalScore(int finalScore)
    {
        finalScoreText.text = "FINAL SCORE: " + finalScore;
        finalScoreShadowText.text = "FINAL SCORE: " + finalScore;

        StartCoroutine(fadeInFinalScore(fadeInDuration));
    }

    private IEnumerator fadeInFinalScore(float duration)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            Debug.Log("alpha is: " + finalScoreAlpha);

            finalScoreAlpha += increaseAlphaRate;

            finalScoreColor.a = finalScoreAlpha;
            finalScoreShadowColor.a = finalScoreAlpha;

            finalScoreText.color = finalScoreColor;
            finalScoreShadowText.color = finalScoreShadowColor;

            elapsed += Time.deltaTime;

            yield return null;
        }
        if (!(elapsed < duration))
        {
            StartCoroutine(fadeOutFinalScore());
        }
    }

    private IEnumerator fadeOutFinalScore()
    {
        while (finalScoreAlpha >= 0.0f)
        {
            finalScoreAlpha -= decreaseAlphaRate;

            finalScoreColor.a = finalScoreAlpha;
            finalScoreShadowColor.a = finalScoreAlpha;

            finalScoreText.color = finalScoreColor;
            finalScoreShadowText.color = finalScoreShadowColor;

            yield return null;
        }
    }
}
