using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gold;
    public static int killCount = 0;
    public static int food = 0;
    public static int goal = 10;
    public GameObject[] enemy;
    public Transform spawnPoint;
    public float spawnTimer = 10;
    public static int health = 1;
    public GameObject interactionPoint;
    public GameObject fade;
    public static int totalKill = 0;

    public Image healthSprite;
    public GameObject player;
    public GameObject gameEndText;
    public GameObject finalStage;
    public int sceneNum;
 
    // Start is called before the first frame update
    void Start()
    {
       
        if(sceneNum == 1)
        {


            StartCoroutine("Spawn");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);
        if (sceneNum == 2 && killCount == 6)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }

        if (food >= 5)
        {
            interactionPoint.SetActive(true);
            food = 0;
        }
       

        if(goal <= 0)
        {
            player.transform.position = finalStage.transform.position;
            goal = 3;
        }

        if(health <= 0 && sceneNum == 1)
        {
            fade.SetActive(true);
            Invoke("MoveToEnd", 2f);
            Destroy(player);
            
            
            
            

        }

    }


    public void MoveToEnd()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            var offset = new Vector3(Random.RandomRange(-15, 15), Random.RandomRange(-15, 15), spawnPoint.transform.position.z);
            var enemyRandom = Random.Range(0, 2);
            Instantiate(enemy[enemyRandom], spawnPoint.transform.position + offset, spawnPoint.rotation);
            Debug.Log("spawning");
            yield return new WaitForSeconds(10f);
        }
    }
}
