using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextChanger : MonoBehaviour
{
    public TextMesh textMesh;
    // Start is called before the first frame update
    public string[] text;
    public GameObject player;


    void Start()
    {
        StartCoroutine("TextChange");
    }

    IEnumerator TextChange()
    {
        int i = 0;
        while(i < 4)
        {
            textMesh.text = text[i];
            yield return new WaitForSeconds(3);
            i++;
        }
        if(i == 4)
        {
            player.GetComponent<CharacterController>().canMove = true;
        }

        yield return null;
    }

   
}
