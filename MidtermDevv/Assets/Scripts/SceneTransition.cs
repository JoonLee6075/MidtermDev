using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public GameObject fade;
    
   

    public void MoveTutorialScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void MoveMainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    public void Fade()
    {
        fade.GetComponent<Animator>().SetBool("StartButtonPressed", true);
        Invoke("MoveMainScene", 3f);
    }



}
