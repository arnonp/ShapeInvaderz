using UnityEngine;

public class Player : MonoBehaviour
{
    private float health = Constants.PlayerHealth;
    public bool active = false;
    public GameObject gameManager;
    public GameObject playerExplosion;

    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void SetActive()
    {
        active = true;
    }

    void Update()
    { }

    private void FixedUpdate()
    {
        if (active)
        {
            rb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * Constants.PlayerHorizontalForce);
            rb.AddForce(Vector3.up * Input.GetAxis("Vertical") * Constants.PlayerVerticalForce);
            if(transform.position.x > Constants.maxPlayerX)
            {
                rb.AddForce(Vector3.left * Constants.PlayerHorizontalForce * Constants.PlayerSnapBackMultiplier);
            }
            if (transform.position.x < Constants.minPlayerX)
            {
                rb.AddForce(Vector3.right * Constants.PlayerHorizontalForce * Constants.PlayerSnapBackMultiplier);
            }
            if (transform.position.y > Constants.maxPlayerY)
            {
                rb.AddForce(Vector3.down * Constants.PlayerVerticalForce * Constants.PlayerSnapBackMultiplier);
            }
            if (transform.position.y < Constants.minPlayerY)
            {
                rb.AddForce(Vector3.up * Constants.PlayerVerticalForce * Constants.PlayerSnapBackMultiplier);
            }
        }
    }
    public void setGameManager(GameObject gameManager)
    {
        this.gameManager = gameManager;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (active)
            {
                health -= other.GetComponent<EnemyBullet>().Getdamage();
            }
            other.SendMessage("Destroy");
            if (health <= 0)
            {
                Destroy(Instantiate(playerExplosion, transform.position, Quaternion.identity), 2.0f);
                SendMessageUpwards("EndGame");
                Destroy(gameObject);
            }
            GetComponent<AudioSource>().Play();
        }
    }

    public void Ending()
    {
        active = false;
        GetComponent<Rigidbody>().AddForce(Vector3.up * 25, ForceMode.Impulse);
    }
}
