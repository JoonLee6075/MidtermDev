using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject boss;
    public float bulletSpeed;
    public Transform target;
    public float speed;
    public GameObject bullet;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        StartCoroutine("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if(health <= 0)
        {
            GameManager.totalKill++;
            Destroy(this.gameObject);
        }
    }
    void shoot()
    {
        GameObject projectile = Instantiate(bullet, transform.position, Quaternion.identity); //create our bullet
        Vector2 direction = (target.position - transform.position).normalized; //get the direction to the target
        projectile.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed; //shoot the bullet

    }


    IEnumerator Attack()
    {

        while (true)
        {
            shoot();
            yield return new WaitForSeconds(3f);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.health--;
        }
    }
}
