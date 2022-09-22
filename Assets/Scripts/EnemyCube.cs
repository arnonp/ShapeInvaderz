using System.Collections;
using UnityEngine;

public class EnemyCube : MonoBehaviour
{
    private float health = Constants.EnemyCubeHealth;
    private bool active = false;

    public GameObject enemyWeapon;
    public GameObject enemyExplosion;
    private Renderer rendererComponent;
    void Start()
    {
        StartCoroutine(EnemyActions());
        rendererComponent = gameObject.GetComponent<Renderer>();
    }
     
    public void OnTriggerEnter(Collider other)
    {
        print("Triggered cube");
        if (other.tag == "Weapon")
        {
            health -= other.GetComponent<Weapon>().Getdamage();
            rendererComponent.material.SetColor("_Color", new Color(rendererComponent.material.color.r * 1.5f, rendererComponent.material.color.g * 1.5f, rendererComponent.material.color.b * 1.5f));
            other.SendMessage("Destroy");
            if (health <= 0)
            {
                Destroy(Instantiate(enemyExplosion, transform.position, Quaternion.identity),2.0f);
                SendMessageUpwards("ChildrenDestroyed");
                Destroy(gameObject);
            } 
        }
    }

    void SetActive()
    {
        active = true;
    }

    private IEnumerator EnemyActions()
    {
        while (true)
        {
            if (active)
            {
                float op = Random.value;
                if (op > Constants.EnemyShootThreshold)
                {
                    GameObject GameObjectInstance = Instantiate(enemyWeapon, transform.position, Quaternion.identity);
                    GameObjectInstance.GetComponent<Rigidbody>().AddForce(Vector3.down * Constants.EnemyCubeShootingPower);
                    Destroy(GameObjectInstance, Constants.EnemyBulletLifeTime);
                }
            }
            yield return new WaitForSeconds(Constants.EnemyTimeBetweenActions + Random.value * Constants.EnemyTimeBetweenActions);
        }
    }
}
