using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosion : MonoBehaviour
{
    void Start()
    {
        Rigidbody[] rigidBodies = gameObject.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in rigidBodies)
        {
            rb.AddForce(new Vector3(Random.value, Random.value, Random.value) * Constants.ExplosionForce, ForceMode.Impulse);
            rb.AddTorque(new Vector3(Random.value, Random.value, Random.value) * Constants.ExplosionForce, ForceMode.Impulse);
        }

        Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer rendererComponent in renderers)
        {
            rendererComponent.material.SetColor("_Color", new Color(Random.value, Random.value, Random.value));
        }
    }
}
