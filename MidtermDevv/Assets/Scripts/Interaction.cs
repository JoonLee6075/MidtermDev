using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{

    public GameObject[] destroyObjects;
    public GameObject dialogue;
    public AudioClip pickup;
    public GameObject fade;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && gameObject.tag == "Box")
        {
            GameManager.goal--;
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Player" && gameObject.tag == "Food")
        {
            SoundManager.Instance.PlaySound(pickup);
            GameManager.food++;
            Destroy(gameObject);
            
        }

        if(collision.gameObject.tag == "Player" && gameObject.tag == "Area")
        {
            fade.SetActive(true);
            dialogue.SetActive(true);
            for(int i = 0; i < destroyObjects.Length; i++)
            {
                
                Destroy(destroyObjects[i]);
            }

            fade.GetComponent<Animator>().SetBool("StartButtonPressed", true);
            Invoke("ChangeScene", 3f);
        }
        
       
    }

    void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
