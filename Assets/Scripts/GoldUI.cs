using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    public Text gold;
    public GameObject gameManager;

    // Update is called once per frame
    void Update()
    {
        gold.text = "Gold: " + gameManager.GetComponent<Stats>().gold.ToString();    
    }
}
