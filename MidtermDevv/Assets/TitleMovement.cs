using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMovement : MonoBehaviour
{

    public float speed;
    public Animator anim;

    private void Awake()
    {
        anim = this.gameObject.GetComponent<Animator>();
        anim.SetBool("isMoving", true);
    }
    // Update is called once per frame
    void Update()
    {

        transform.Translate(-0.005f,0, 0);

    }
}
