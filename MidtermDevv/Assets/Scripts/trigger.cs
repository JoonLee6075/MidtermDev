using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawnMob;
    public Transform[] spawnPoint;
    public static int killCount = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(killCount >= 6)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            for(int i = 0; i < spawnPoint.Length; i++)
            {
                Instantiate(spawnMob, spawnPoint[i].transform.position, spawnMob.transform.rotation);
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        
    }
}
