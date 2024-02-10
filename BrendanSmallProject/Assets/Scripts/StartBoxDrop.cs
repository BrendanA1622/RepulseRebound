using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoxDrop : MonoBehaviour
{
    [SerializeField]
    private GameObject leftStartWall;
    [SerializeField]
    private GameObject rightStartWall;
    [SerializeField]
    private GameObject bottomStartWall;

    [SerializeField]
    private SpriteRenderer leftStartWallSprite;
    [SerializeField]
    private SpriteRenderer rightStartWallSprite;
    [SerializeField]
    private SpriteRenderer bottomStartWallSprite;

    [SerializeField]
    private float resumeGameTime;

    void Start()
    {
        leftStartWallSprite.color = Color.red;
        rightStartWallSprite.color = Color.red;
        bottomStartWallSprite.color = Color.red;
        Invoke("changeToYellow", 2.0f);
    }

    private void changeToYellow()
    {
        leftStartWallSprite.color = Color.yellow;
        rightStartWallSprite.color = Color.yellow;
        bottomStartWallSprite.color = Color.yellow;

        Invoke("changeToGreen", 1.0f);
    }

    private void changeToGreen()
    {
        leftStartWallSprite.color = Color.green;
        rightStartWallSprite.color = Color.green;
        bottomStartWallSprite.color = Color.green;

        Invoke("dropThePlayer", 1.0f);
    }

    private void dropThePlayer()
    {
        leftStartWall.SetActive(false);
        rightStartWall.SetActive(false);
        bottomStartWall.SetActive(false);
    }

    public void resetStartBox()
    {
        leftStartWall.SetActive(true);
        rightStartWall.SetActive(true);
        bottomStartWall.SetActive(true);
        leftStartWallSprite.color = Color.red;
        rightStartWallSprite.color = Color.red;
        bottomStartWallSprite.color = Color.red;
        Invoke("changeToYellow", resumeGameTime);
    }
}
