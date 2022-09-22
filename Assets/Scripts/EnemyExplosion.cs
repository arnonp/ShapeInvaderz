using System.Linq;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    void Start()
    {
         Rigidbody[] rigidBodies = gameObject.GetComponentsInChildren<Rigidbody>();
        
           foreach (Rigidbody rb in rigidBodies)
        {
            rb.AddForce(new Vector3(Random.value, Random.value, Random.value) * Constants.ExplosionForce, ForceMode.Impulse);
            rb.AddTorque(new Vector3(Random.value, Random.value, Random.value) * Constants.ExplosionForce, ForceMode.Impulse);
        }
    }
}
