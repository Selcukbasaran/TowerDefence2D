using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // sýradaki scene i getir. 
    }

    public void QuitGame()
    {
        Debug.LogError("Kapatýldý");
        Application.Quit(); // unity içinde bu parça çalýþmýyor.
    }
}
