using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public AudioClip destroy;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(health <= 0)
        {
            SoundManager.Instance.PlaySound(destroy);
            Destroy(gameObject);
            SceneManager.brokenBox++;
            Debug.Log(SceneManager.brokenBox);
        }
          
        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("eh");
    }
}
