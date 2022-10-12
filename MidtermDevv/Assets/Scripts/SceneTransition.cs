using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
   

    public void MoveTutorialScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void MoveMainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

}
