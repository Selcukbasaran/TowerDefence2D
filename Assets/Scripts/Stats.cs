using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int gameHealth = 20;
    public bool gameended = false;

    public GameObject gameOverUI;

    public int gold;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameended)
        {
            Time.timeScale = 1;
        }
        if (gameHealth <= 0 && !gameended)
        {
            endGame();
        }
    }

    public void LooseGameHealth()
    {
        gameHealth -= 1;
    }

    void endGame()
    {
        gameended = true;
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
        //Debug.LogError("KAYBETTIN!");
    }

    public bool MinusGold(int value)
    {
        if (gold - value < 0) return true;

        if (gold - value >= 0)
        {
            gold -= value;
            return false;
        }
        else return true;
    }
    public void PlusGold(int value)
    {
        gold += value;
    }
}
