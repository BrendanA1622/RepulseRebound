using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush : MonoBehaviour
{
    PointEffector2D explosionComponent;
    [SerializeField]
    CircleCollider2D circleCollider;

    [SerializeField]
    private float addTorqueAmountInDegrees;

    private float explosionRadius;

    [SerializeField]
    private Rigidbody2D playerBody;

    // Start is called before the first frame update
    void Start()
    {
        explosionComponent = GetComponent<PointEffector2D>();

        explosionComponent.enabled = false;
        explosionRadius = circleCollider.radius;
        detonatePushForce();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void detonatePushForce()
    {
        explosionComponent.enabled = true;

        playerBody.AddTorque(addTorqueAmountInDegrees * Mathf.Deg2Rad * playerBody.inertia);
    }

}
