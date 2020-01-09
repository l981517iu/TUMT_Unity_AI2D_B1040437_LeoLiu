using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
   public void Replay()
    {
        SceneManager.LoadScene("Level1");
    }

    public void SingleReplay()
    {
        SceneManager.LoadScene("SinglePlay");
    }

    public void ChangeCharacter()
    {
        SceneManager.LoadScene("ChangeCharacter");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayP1()
    {
        SceneManager.LoadScene("SinglePlay");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
