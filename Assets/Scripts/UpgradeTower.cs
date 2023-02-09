using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTower : MonoBehaviour
{
    public GameObject archer2;
    public GameObject archer3;

    public GameObject wizard2;
    public GameObject wizard3;

    public GameObject support2;
    public GameObject support3;

    public GameObject stone2;
    public GameObject stone3;

    public Vector3 positionOffset_archer;
    public Vector3 positionOffset_wizard;

    private GameObject swap;
    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
    void OnMouseExit()
    {
        Destroy(gameObject);
    }
    public bool AdjustGold(int value)
    {
        return gameManager.GetComponent<Stats>().MinusGold(value);
    }

    public void UpgradeT(parts part)
    {
        switch (part)
        {
            case parts.archer:
                if (AdjustGold(100))
                {
                    Debug.Log("Altýn yok");
                }
                else
                {
                    Destroy(transform.parent.GetChild(0).gameObject);
                    swap = (GameObject)Instantiate(archer2, transform.position + positionOffset_archer, transform.rotation);
                    swap.transform.parent = transform.parent; 
                }
                break;

            case parts.archer2:
                if (AdjustGold(100))
                {
                    Debug.Log("Altýn yok");
                }
                else
                {
                    Destroy(transform.parent.GetChild(0).gameObject);
                    swap = (GameObject)Instantiate(archer3, transform.position + positionOffset_archer, transform.rotation);
                    swap.transform.parent = transform.parent; 
                }
                break;

            case parts.archer3:
                Debug.Log("Kule zaten son seviyede! Yükseltme yapýlamaz.");
                break;

            //Wizard
            case parts.wizard:
                if (AdjustGold(100))
                {
                    Debug.Log("Altýn yok");
                }
                else
                {
                    Destroy(transform.parent.GetChild(0).gameObject);
                    swap = (GameObject)Instantiate(wizard2, transform.position + positionOffset_archer, transform.rotation);
                    swap.transform.parent = transform.parent; 
                }
                break;

            case parts.wizard2:
                if (AdjustGold(100))
                {
                    Debug.Log("Altýn yok");
                }
                else
                {
                    Destroy(transform.parent.GetChild(0).gameObject);
                    swap = (GameObject)Instantiate(wizard3, transform.position + positionOffset_archer, transform.rotation);
                    swap.transform.parent = transform.parent; 
                }
                break;

            case parts.wizard3:
                Debug.Log("Kule zaten son seviyede! Yükseltme yapýlamaz.");
                break;

            //Support Tower
            case parts.support:
                if (AdjustGold(100))
                {
                    Debug.Log("Altýn yok");
                }
                else
                {
                    Destroy(transform.parent.GetChild(0).gameObject);
                    swap = (GameObject)Instantiate(support2, transform.position + positionOffset_archer, transform.rotation);
                    swap.transform.parent = transform.parent; 
                }
                break;

            case parts.support2:
                if (AdjustGold(100))
                {
                    Debug.Log("Altýn yok");
                }
                else
                {
                    Destroy(transform.parent.GetChild(0).gameObject);
                    swap = (GameObject)Instantiate(support3, transform.position + positionOffset_archer, transform.rotation);
                    swap.transform.parent = transform.parent; 
                }
                break;

            case parts.support3:
                Debug.Log("Kule zaten son seviyede! Yükseltme yapýlamaz.");
                break;
            
            //Stone Tower
            case parts.stone:
                if (AdjustGold(100))
                {
                    Debug.Log("Altýn yok");
                }
                else
                {
                    Destroy(transform.parent.GetChild(0).gameObject);
                    swap = (GameObject)Instantiate(stone2, transform.position + positionOffset_archer, transform.rotation);
                    swap.transform.parent = transform.parent; 
                }
                break;

            case parts.stone2:
                if (AdjustGold(100))
                {
                    Debug.Log("Altýn yok");
                }
                else
                {
                    Destroy(transform.parent.GetChild(0).gameObject);
                    swap = (GameObject)Instantiate(stone3, transform.position + positionOffset_archer, transform.rotation);
                    swap.transform.parent = transform.parent; 
                }
                break;

            case parts.stone3:
                Debug.Log("Kule zaten son seviyede! Yükseltme yapýlamaz.");
                break;
        }
    }
}
