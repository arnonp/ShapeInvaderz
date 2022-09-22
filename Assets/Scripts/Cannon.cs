using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bulletObject;
    private float nextFire = Constants.FireRate;
    void Update()
    {
        if (Input.GetKey("space"))
        {
            nextFire -= Time.deltaTime;
            if (nextFire < 0)
            {

                GameObject bullet = Instantiate(bulletObject, transform.position, Quaternion.identity, transform);
                bullet.GetComponent<Rigidbody>().AddForce(Vector3.up * Constants.CannonShootingPower, ForceMode.Impulse);
                Destroy(bullet, Constants.BulletLifeTime);
                nextFire = Constants.FireRate;
            }
        }
    }
}
