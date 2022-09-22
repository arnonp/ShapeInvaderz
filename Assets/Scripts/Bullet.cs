using UnityEngine;

public class Bullet : MonoBehaviour, Weapon
{
    private float damage = Constants.BulletDamage;

    public float Getdamage()
    {
        return damage;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
