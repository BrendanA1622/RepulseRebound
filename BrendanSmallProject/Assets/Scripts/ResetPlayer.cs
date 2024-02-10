using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResetPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject deathBar1;
    [SerializeField]
    private GameObject deathBar2;
    [SerializeField]
    private GameObject deathBar3;
    [SerializeField]
    private GameObject deathBar4;
    [SerializeField]
    private GameObject deathBar5;
    [SerializeField]
    private GameObject deathBar6;
    [SerializeField]
    private GameObject deathBar7;
    [SerializeField]
    private GameObject deathBar8;


    [SerializeField]
    private float difficultyIncreaseRate;


    [SerializeField]
    private GameObject playerShape;
    [SerializeField]
    private Rigidbody2D playerRB;

    [SerializeField]
    private Vector3 startingPosition;

    private float difficultyRating;

    private int slot1Index;
    private int slot2Index;
    private int slot3Index;
    private int slot4Index;
    private int slot5Index;
    private int slot6Index;
    private int slot7Index;

    [SerializeField]
    private bool[] availableSlots;

    void Start()
    {
        difficultyRating = 0f;

        slot1Index = -1;
        slot2Index = -1;
        slot3Index = -1;
        slot4Index = -1;
        slot5Index = -1;
        slot6Index = -1;
        slot7Index = -1;
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        playerShape.transform.position = startingPosition;
        playerRB.velocity = new Vector2(0.0f, 0.0f);
        determineDeathSlots();
        difficultyRating += difficultyIncreaseRate;
    }

    public void resetPlayerPosition()
    {
        playerShape.transform.position = startingPosition;
        playerRB.velocity = new Vector2(0.0f, 0.0f);
        difficultyRating = 0f;

        availableSlots[0] = true;
        availableSlots[1] = true;
        availableSlots[2] = true;
        availableSlots[3] = true;
        availableSlots[4] = true;
        availableSlots[5] = true;
        availableSlots[6] = true;
        availableSlots[7] = true;

        deathBar1.SetActive(!availableSlots[0]);
        deathBar2.SetActive(!availableSlots[1]);
        deathBar3.SetActive(!availableSlots[2]);
        deathBar4.SetActive(!availableSlots[3]);
        deathBar5.SetActive(!availableSlots[4]);
        deathBar6.SetActive(!availableSlots[5]);
        deathBar7.SetActive(!availableSlots[6]);
        deathBar8.SetActive(!availableSlots[7]);
    }

    private void determineDeathSlots()
    {
        if (Mathf.Round(difficultyRating) < 1)
        {
            randomizeDeathSlots(1);
        } else if (Mathf.Round(difficultyRating) < 2)
        {
            randomizeDeathSlots(2);
        } else if (Mathf.Round(difficultyRating) < 3)
        {
            randomizeDeathSlots(3);
        } else if (Mathf.Round(difficultyRating) < 4)
        {
            randomizeDeathSlots(4);
        } else if (Mathf.Round(difficultyRating) < 5)
        {
            randomizeDeathSlots(5);
        } else if (Mathf.Round(difficultyRating) < 6)
        {
            randomizeDeathSlots(6);
        } else
        {
            randomizeDeathSlots(7);
        }
    }

    private void randomizeDeathSlots(int numSlots)
    {
        availableSlots[0] = true;
        availableSlots[1] = true;
        availableSlots[2] = true;
        availableSlots[3] = true;
        availableSlots[4] = true;
        availableSlots[5] = true;
        availableSlots[6] = true;
        availableSlots[7] = true;




        if (numSlots >= 1)
        {
            slot1Index = Random.Range(0, 8);
            availableSlots[slot1Index] = false;
        }
        if (numSlots >= 2)
        {
            int tempRand2 = Random.Range(0, 7);
            int availIndex2 = 0;
            int actualIndex2 = 0;
            foreach (bool isAvailable in availableSlots)
            {
                if (isAvailable)
                {
                    if (tempRand2 == availIndex2)
                    {
                        slot2Index = actualIndex2;
                        availableSlots[slot2Index] = false;
                    }
                    availIndex2 += 1;
                }
                actualIndex2 += 1;
            }
        }
        if (numSlots >= 3)
        {
            int tempRand3 = Random.Range(0, 6);
            int availIndex3 = 0;
            int actualIndex3 = 0;
            foreach (bool isAvailable in availableSlots)
            {
                if (isAvailable)
                {
                    if (tempRand3 == availIndex3)
                    {
                        slot3Index = actualIndex3;
                        availableSlots[slot3Index] = false;
                    }
                    availIndex3 += 1;
                }
                actualIndex3 += 1;
            }
        }
        if (numSlots >= 4)
        {
            int tempRand4 = Random.Range(0, 5);
            int availIndex4 = 0;
            int actualIndex4 = 0;
            foreach (bool isAvailable in availableSlots)
            {
                if (isAvailable)
                {
                    if (tempRand4 == availIndex4)
                    {
                        slot4Index = actualIndex4;
                        availableSlots[slot4Index] = false;
                    }
                    availIndex4 += 1;
                }
                actualIndex4 += 1;
            }
        }
        if (numSlots >= 5)
        {
            int tempRand5 = Random.Range(0, 4);
            int availIndex5 = 0;
            int actualIndex5 = 0;
            foreach (bool isAvailable in availableSlots)
            {
                if (isAvailable)
                {
                    if (tempRand5 == availIndex5)
                    {
                        slot5Index = actualIndex5;
                        availableSlots[slot5Index] = false;
                    }
                    availIndex5 += 1;
                }
                actualIndex5 += 1;
            }
        }
        if (numSlots >= 6)
        {
            int tempRand6 = Random.Range(0, 3);
            int availIndex6 = 0;
            int actualIndex6 = 0;
            foreach (bool isAvailable in availableSlots)
            {
                if (isAvailable)
                {
                    if (tempRand6 == availIndex6)
                    {
                        slot6Index = actualIndex6;
                        availableSlots[slot6Index] = false;
                    }
                    availIndex6 += 1;
                }
                actualIndex6 += 1;
            }
        }
        if (numSlots >= 7)
        {
            int tempRand7 = Random.Range(0, 2);
            int availIndex7 = 0;
            int actualIndex7 = 0;
            foreach (bool isAvailable in availableSlots)
            {
                if (isAvailable)
                {
                    if (tempRand7 == availIndex7)
                    {
                        slot7Index = actualIndex7;
                        availableSlots[slot7Index] = false;
                    }
                    availIndex7 += 1;
                }
                actualIndex7 += 1;
            }
        }




        deathBar1.SetActive(!availableSlots[0]);
        deathBar2.SetActive(!availableSlots[1]);
        deathBar3.SetActive(!availableSlots[2]);
        deathBar4.SetActive(!availableSlots[3]);
        deathBar5.SetActive(!availableSlots[4]);
        deathBar6.SetActive(!availableSlots[5]);
        deathBar7.SetActive(!availableSlots[6]);
        deathBar8.SetActive(!availableSlots[7]);



        /*
        Debug.Log("Death Slot 4: " + slot4Index);
        Debug.Log("Death Slot 5: " + slot5Index);
        Debug.Log("Death Slot 6: " + slot6Index);
        Debug.Log("Death Slot 7: " + slot7Index);*/
    }

}
