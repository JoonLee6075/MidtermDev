using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public GameObject fade;
    public AudioClip buttonClick;
    
   

    public void MoveEndingScene()
    {
        fade.GetComponent<Animator>().SetBool("StartButtonPressed", true);
        Invoke("MoveEndScene", 3f);
       
    }
    public void MoveEndScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }
    public void MoveTutorialScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    public void MoveMainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void Fade()
    {
        SoundManager.Instance.PlaySound(buttonClick);
        fade.GetComponent<Animator>().SetBool("StartButtonPressed", true);
        Invoke("MoveMainScene", 3f);
    }



}
