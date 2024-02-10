using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_collision : MonoBehaviour
{
    [SerializeField]
    private AudioSource hitObSound;

    [SerializeField]
    private ParticleSystem obsHitParticles;

    [SerializeField]
    private float collideMagnitude;
    [SerializeField]
    private float volDampener;

    [SerializeField]
    private float collideRechargeRate;

    private bool canCollideAgain;

    void Start()
    {
        canCollideAgain = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Player just hit something!");

        if (col.relativeVelocity.magnitude > collideMagnitude && canCollideAgain)
        {
            hitObSound.volume = (col.relativeVelocity.magnitude - collideMagnitude + 1) / volDampener;
            hitObSound.pitch = Random.Range(0.5f, 2f);

            obsHitParticles.Play(true);
            hitObSound.Play();

            canCollideAgain = false;

            Invoke("rechargeCollide", collideRechargeRate);
        }

    }

    private void rechargeCollide()
    {
        canCollideAgain = true;
    }
}
