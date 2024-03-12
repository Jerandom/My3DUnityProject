using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody bulletRigidBody;

    private void Awake()
    {
        bulletRigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 30f;
        bulletRigidBody.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Virus") && collision.gameObject.GetComponents<HealthBarUI>() != null)
        {
            GameObject hit = collision.gameObject;
            HealthBarUI healthBarUI = hit.GetComponentInChildren<HealthBarUI>();

            if (healthBarUI != null)
            {
                healthBarUI.minusHealth(10);
            }
        }
        Destroy(gameObject);
    }
}
