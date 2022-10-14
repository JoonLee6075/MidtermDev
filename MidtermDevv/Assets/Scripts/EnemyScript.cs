using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float health;
    public GameObject reward;
    public int damage;
    public bool check;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x - target.position.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Vector2.Distance(this.transform.position , target.transform.position) < 10)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (transform.position.x - target.position.x > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }

        }


        if(health <= 0)
        {
            if(this.gameObject.tag == "TutorialMob")
            {
                trigger.killCount++;
                Debug.Log("dead");
            }
            Destroy(gameObject);
            Instantiate(reward, gameObject.transform.position , reward.transform.rotation);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.health--;
        }
    }
}
