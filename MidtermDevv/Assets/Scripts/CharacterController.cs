using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterController : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public LayerMask destroyLayers;
    public int damage;
    public GameManager gm;
    public bool canMove;
    public bool canAttack = true;
    public AudioClip attack;
   
    public bool isHorizontalMove;
    bool isVerticalMove;
    public SpriteRenderer sr;
    public Animator anim;
    Vector2 movement;
    
    
    // Start is called before the first frame update
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (movement.x < 0)
            {
                sr.flipX = true;
                attackPoint.position = transform.position - new Vector3(0.7f, 0, 0);
            }
            if (movement.x > 0)
            {
                sr.flipX = false;
                attackPoint.position = transform.position + new Vector3(0.7f, 0, 0);
            }


            if (Input.GetKeyDown(KeyCode.J))
            {
                if (canAttack == true)
                {
                    anim.SetTrigger("isAttack");
                    canAttack = false;
                    StartCoroutine("AttackDelay");

                }



            }
        }
       
    }
    void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        if(Mathf.Abs(movement.x) > 0 || Mathf.Abs(movement.y) > 0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    public void Attack()
    {
        SoundManager.Instance.PlaySound(attack);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange , enemyLayers); 

        
        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy.gameObject.tag == "BlueEnemy" || enemy.gameObject.tag == "TutorialMob")
            {
                enemy.GetComponent<EnemyScript>().TakeDamage(damage);
            }
            if(enemy.gameObject.tag == "RedEnemy")
            {
                enemy.GetComponent<BossSpawn>().TakeDamage(damage);
            }
            

        }
    }
    public void Break()
    {
        Collider2D[] hitDestroy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, destroyLayers);
        foreach (Collider2D obj in hitDestroy)
        {

            obj.GetComponent<Destroyable>().TakeDamage(damage);
          

        }
    }
    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(3);
        canAttack = true;
    }
}
