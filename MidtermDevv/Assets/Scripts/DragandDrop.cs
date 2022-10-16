using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragandDrop : MonoBehaviour
{

    private bool selected;
    public Collider2D col;
    CircleCollider2D circ;


    private void OnMouseOver()
    {
        Debug.Log("over");
        if (Input.GetMouseButtonDown(0))
        {
            
            selected = true;
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(selected == true)
        {
            col = gameObject.GetComponent<CircleCollider2D>();
            col.enabled = false;
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
            col = gameObject.GetComponent<CircleCollider2D>();
            col.enabled = true;


            col = null;


        }
        
    }
}
