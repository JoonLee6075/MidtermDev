using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int brokenBox = 0;
    public GameObject[] showObject;
    public GameObject[] hideObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(brokenBox == 5)
        {
            for(int i = 0; i < hideObject.Length; i++)
            {
                hideObject[i].SetActive(false);
                
                
            }
            for(int i = 0; i < showObject.Length; i++)
            {
                showObject[i].SetActive(true);
            }
            
        }

        
    }
}
