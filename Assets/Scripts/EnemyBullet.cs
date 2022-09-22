using UnityEngine;

public class EnemyBullet : MonoBehaviour, Weapon
{   
    public float Getdamage()
    {
        return Constants.EnemyBulletDamage;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
