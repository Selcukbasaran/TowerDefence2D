using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    private bool Paused = false;
    public GameObject pausedPanel;
    public void PauseScene()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1f;
            pausedPanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            pausedPanel.SetActive(true);
        }
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);

    }
}
