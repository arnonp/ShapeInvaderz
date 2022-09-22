using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemyRows;
    public int enemyCols;
    private float enemyLeft = Constants.minEnemyX+1, enemyRight = Constants.maxEnemyX-1, enemyTop = Constants.maxEnemyY, enemyBottom = Constants.minEnemyY;
    
    public GameObject enemies;
    public GameObject enemiesBatch;
    public GameObject enemy;
    public GameObject player;

    public GameObject playerInstance;

    Vector3[] ShanaTova = { 
        //SHIN
        new Vector3(20, 9, Constants.Depth),
        new Vector3(20, 8, Constants.Depth),
        new Vector3(20, 7, Constants.Depth),
        new Vector3(20, 6, Constants.Depth),
        new Vector3(19, 6, Constants.Depth),
        new Vector3(18, 8, Constants.Depth),
        new Vector3(18, 7, Constants.Depth),
        new Vector3(18, 6, Constants.Depth),
        new Vector3(17, 6, Constants.Depth),
        new Vector3(16, 9, Constants.Depth),
        new Vector3(16, 8, Constants.Depth),
        new Vector3(16, 7, Constants.Depth),
        new Vector3(16, 6, Constants.Depth),

        //NOON
        new Vector3(14, 9, Constants.Depth),
        new Vector3(13, 9, Constants.Depth),
        new Vector3(14, 8, Constants.Depth),
        new Vector3(14, 7, Constants.Depth),
        new Vector3(14, 6, Constants.Depth),
        new Vector3(13, 6, Constants.Depth),
        new Vector3(12, 6, Constants.Depth),

        //HEH
        new Vector3(10, 9, Constants.Depth),
        new Vector3(9, 9, Constants.Depth),
        new Vector3(8, 9, Constants.Depth),
        new Vector3(10, 8, Constants.Depth),
        new Vector3(10, 7, Constants.Depth),
        new Vector3(10, 6, Constants.Depth),
        new Vector3(8, 7, Constants.Depth),
        new Vector3(8, 6, Constants.Depth),

        //TET
        new Vector3(12, 4, Constants.Depth),
        new Vector3(12, 3, Constants.Depth),
        new Vector3(12, 2, Constants.Depth),
        new Vector3(12, 1, Constants.Depth),
        new Vector3(11, 4, Constants.Depth),
        new Vector3(10, 4, Constants.Depth),
        new Vector3(10, 3, Constants.Depth),
        new Vector3(11, 1, Constants.Depth),
        new Vector3(10, 1, Constants.Depth),
        new Vector3(9, 1, Constants.Depth),
        new Vector3(8, 1, Constants.Depth),
        new Vector3(8, 2, Constants.Depth),
        new Vector3(8, 3, Constants.Depth),
        new Vector3(8, 4, Constants.Depth),

        //VAV
        new Vector3(6, 4, Constants.Depth),
        new Vector3(5, 4, Constants.Depth),
        new Vector3(6, 3, Constants.Depth),
        new Vector3(6, 2, Constants.Depth),
        new Vector3(6, 1, Constants.Depth),

        //BET
        new Vector3(4, 1, Constants.Depth),
        new Vector3(3, 1, Constants.Depth),
        new Vector3(3, 2, Constants.Depth),
        new Vector3(3, 3, Constants.Depth),
        new Vector3(3, 4, Constants.Depth),
        new Vector3(2, 4, Constants.Depth),
        new Vector3(1, 4, Constants.Depth),
        new Vector3(2, 1, Constants.Depth),
        new Vector3(1, 1, Constants.Depth),

        
        //HEH
        new Vector3(-1, 4, Constants.Depth), //10 -> -1, 9->4
        new Vector3(-2, 4, Constants.Depth),
        new Vector3(-3, 4, Constants.Depth),
        new Vector3(-1, 3, Constants.Depth),
        new Vector3(-1, 2, Constants.Depth),
        new Vector3(-1, 1, Constants.Depth),
        new Vector3(-3, 2, Constants.Depth),
        new Vector3(-3, 1, Constants.Depth),
    };

    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        InstatntiateEnemies();
        InstantiatePlayer();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene(Constants.MainMenuScene);
        }
    }

    private void InstantiatePlayer()
    {
        Vector3 playerStartingPoint = new Vector3(0.0f, -10.0f, Constants.Depth);
        Vector3 playerOriginPoint = new Vector3(0.0f, -20.0f, Constants.Depth);
        float timeToPlace = Constants.MinPlayerTimeToPlace;
        StartCoroutine(
                InstantiateAndFlyToPlace(playerOriginPoint, playerStartingPoint, timeToPlace, player, false, transform, true));
    }

    private void InstatntiateEnemies()
    {
        if(enemyRows == 0)
        {
            GameObject enemiesGameObject = Instantiate(enemies, transform);
            GameObject enemiesRowGameObject = Instantiate(enemiesBatch, enemiesGameObject.transform);
            enemiesRowGameObject.GetComponent<Batch>().SetChildrenCount(ShanaTova.Length);
            foreach (Vector3 point in ShanaTova)
            {
                Vector3 originPosition = new Vector3(Random.value * Constants.EnemyOriginPositionRandomMax + enemyLeft, Random.value * Constants.EnemyOriginPositionRandomMax + enemyBottom, Random.value * Constants.Depth);
                Vector3 startingPosition = point;
                float enemyTimeToPlace = Constants.MinPlayerTimeToPlace;
                StartCoroutine(
                InstantiateAndFlyToPlace(originPosition, startingPosition, enemyTimeToPlace, enemy, false, enemiesRowGameObject.transform, false));
            }
        }
        else
        {
            float enemySize = 1;
            float rowLength = enemyRight - enemyLeft;
            float rowSpacing = (rowLength - enemyCols * enemySize) / (enemyCols + 1);
            float colLength = enemyTop - enemyBottom;
            float colSpacing = (colLength - enemyRows * enemySize) / (enemyRows + 1);
            GameObject enemiesGameObject = Instantiate(enemies, transform);
            for (int i = 0; i < enemyRows; i++)
            {
                GameObject enemiesRowGameObject = Instantiate(enemiesBatch, enemiesGameObject.transform);
                enemiesRowGameObject.GetComponent<Batch>().SetChildrenCount(enemyCols);
                for (int j = 0; j < enemyCols; j++)
                {
                    Vector3 originPosition = new Vector3(Random.value * rowLength + enemyLeft, Random.value * colLength + enemyBottom, Random.value * Constants.Depth);
                    Vector3 startingPosition = new Vector3(enemyLeft + (1.0f + j) * (rowSpacing + enemySize), enemyBottom + (1.0f + i) * (colSpacing + enemySize), Constants.Depth);
                    float enemyTimeToPlace = Constants.MinPlayerTimeToPlace;
                    StartCoroutine(
                    InstantiateAndFlyToPlace(originPosition, startingPosition, enemyTimeToPlace, enemy, true, enemiesRowGameObject.transform, false));
                }
            }
        }
    }

    private IEnumerator InstantiateAndFlyToPlace(Vector3 originPosition, Vector3 destinationPosition, float timeToPlace, GameObject gameObject, bool spin, Transform parent, bool setGameManager)
    {
        GameObject GameObjectInstance = Instantiate(gameObject, originPosition, Quaternion.identity, parent);
        if (spin)
        {
            GameObjectInstance.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.value, Random.value, Random.value)* Constants.EnemySpinPower);
        }
        float distance = Mathf.Abs((GameObjectInstance.transform.position - destinationPosition).magnitude);
        while (Mathf.Abs((GameObjectInstance.transform.position - destinationPosition).magnitude) > 0.3f)
        {
            Vector3 direction = destinationPosition - GameObjectInstance.transform.position;
            GameObjectInstance.transform.position = GameObjectInstance.transform.position + direction.normalized * distance * Time.deltaTime / timeToPlace;
            yield return null;
        }
        GameObjectInstance.transform.position = destinationPosition;
        GameObjectInstance.SendMessage("SetActive");
        if (GameObjectInstance.tag != "Player")
        {
            GameObjectInstance.SendMessageUpwards("SetChildrenActive");
        }
        if (setGameManager)
        {
            GameObjectInstance.GetComponent<Player>().setGameManager(this.gameObject);
            playerInstance = GameObjectInstance;
        }
    }

    public void EndGame()
    {
        StartCoroutine(EndGameCoroutine());
    }
    private IEnumerator EndGameCoroutine()
    {
        yield return new WaitForSeconds(Constants.SceneLoadDelay);
        SceneManager.LoadScene(Constants.MainMenuScene);
    }

    private void ChildrenDestroyed()
    {
        StartCoroutine(ChildrenDestroyedCoroutine()); 
    }

    private IEnumerator ChildrenDestroyedCoroutine()
    {
        yield return new WaitForSeconds(Constants.ChildDestroyCoroutineDelay);
        Transform[] childrenTransforms = gameObject.GetComponentsInChildren<Transform>();
        childrenTransforms = childrenTransforms.Where(transform => transform.gameObject.tag == "Enemy").ToArray();
        if (childrenTransforms.Length == 0)
        {
            playerInstance.GetComponent<Player>().Ending();
            StartCoroutine(NextSceneCoroutine());
        }
    }

    private IEnumerator NextSceneCoroutine()
    {
        yield return new WaitForSeconds(Constants.SceneLoadDelay);
        SceneManager.LoadScene(nextScene);
    }
}
