using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPush : MonoBehaviour
{
    public GameObject Camera;
    public float ForceMultiplier;
    public float PlayerDamage = 10f;

    void Update()
    {
        GPush();
    }

    void GPush()
    {
        if (Input.GetButton("Fire1"))
        {
            Vector3 direction = Camera.transform.TransformDirection(Vector3.forward);
            Vector3 forceDirection;
            RaycastHit RayObj;
            Debug.Log("Raycast Hit");

            if (Physics.Raycast(transform.position, direction, out RayObj, 30))
            {
                forceDirection = RayObj.transform.position - transform.position;
                RayObj.rigidbody.AddForceAtPosition(forceDirection * ForceMultiplier, transform.position);
                Debug.Log("Push Successful");
                RayObj.collider.SendMessageUpwards("ReceiveDamageEnemy", PlayerDamage, SendMessageOptions.DontRequireReceiver);
                Debug.Log("HIT " + RayObj.collider.name);
            }
        }
    }
}
