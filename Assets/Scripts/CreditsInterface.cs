using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsInterface : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject firework;
    void Start()
    {
        StartCoroutine(
                    Fireworks());
    }
    private IEnumerator Fireworks() 
    {
        while (true)
        {
            Destroy(Instantiate(firework, new Vector3(Random.Range(-30, 30), Random.Range(-10, 10), Random.Range(10, 40)), Random.rotation), 4.0f);
            yield return new WaitForSeconds(1f);
        }
    }


    public void ClickExit()
    {
        Application.Quit();
    }

    public void ClickPlay()
    {
        SceneManager.LoadScene(Constants.ShapeInvaders1Scene);
    }
}
