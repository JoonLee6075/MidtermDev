using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalText : MonoBehaviour
{
    public TextMesh text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "You killed" + GameManager.totalKill + " slimes in your dream";
    }
}
