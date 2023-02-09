using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // s�radaki scene i getir. 
    }

    public void QuitGame()
    {
        Debug.LogError("Kapat�ld�");
        Application.Quit(); // unity i�inde bu par�a �al��m�yor.
    }
}
