using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{

    public static TowerBuilder instance; //kendi referansý ve buna her yerden ulaþýcaz

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Birden fazla builder olamaz");
            return;
        }
        instance = this; // tek builder bu olacak
        
    }

    public GameObject archerTower;
    public GameObject wizardTower;
    public GameObject supportTower;
    //public GameObject towerSelect;
    
    private void Start()
    {
        //towerToBuild = towerSelect;
    }

    /*public void TowerSelected(int t)
    {
        switch (t)
        {
            case 1:
                towerToBuild = archerTower;
                break;
            case 2:
                towerToBuild = wizardTower;
                break;
        }
    }*/


    private GameObject towerToBuild;

    public GameObject GetTowerToBuild()
    {

        return towerToBuild;
    }
    
    

}
