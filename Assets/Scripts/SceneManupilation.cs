using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManupilation : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            FreezeEnemies();
        }
    }
    public void FreezeEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            //enemy
        }
    }
}
