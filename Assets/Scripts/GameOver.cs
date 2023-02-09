using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject manager;
    public void Retry()
    {
        manager.GetComponent<Stats>().gameended = false;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
