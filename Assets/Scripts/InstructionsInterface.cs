using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsInterface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
