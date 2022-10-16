using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    public GameObject[] destroyObjects;
    public GameObject dialogue;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && gameObject.tag == "Box")
        {
            GameManager.goal--;
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Player" && gameObject.tag == "Food")
        {
            GameManager.food++;
            Destroy(gameObject);
            
        }

        if(collision.gameObject.tag == "Player" && gameObject.tag == "Area")
        {
            dialogue.SetActive(true);
            for(int i = 0; i < destroyObjects.Length; i++)
            {
                Destroy(destroyObjects[i]);
            }
        }
        
    }
}
