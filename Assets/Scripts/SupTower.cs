using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupTower : MonoBehaviour
{
    public GameObject prefab;
    public GameObject[] warriors;
    public Transform origin;
    public Transform[] returnPoints;
    //public GameObject warriorPrefab;

    public float countDown;
    public float range;

    public Transform hedef;
    private bool hasTarget = false;
    public string enemyTag = "Enemy";
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FindTarget", 0f, 0.1f);
        for (int i = 0; i < 3; i++)
        {
            
            if (warriors[i] == null)
            {
                warriors[i] = (GameObject)Instantiate(prefab, origin.position, origin.rotation);
                warriors[i].transform.parent = transform; 
                warriors[i].GetComponent<Warrioryeni>().SetReturnPoint(returnPoints[i]);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if (warriors[i] != null)
            {
                if (warriors[i].GetComponent<Warrioryeni>().hedef == null)
                {
                    if (hedef == null) break;

                    warriors[i].GetComponent<Warrioryeni>().SetTarget(hedef);

                    //hasTarget = true;
                } 
            }

        }

        for (int i = 0; i < 3; i++)
        {
            if (warriors[i] == null)
            {
                countDown -= Time.deltaTime;
            }
            
            if (warriors[i] == null && countDown <= 0)
            {
                warriors[i] = (GameObject)Instantiate(prefab, origin.position, origin.rotation);
                warriors[i].transform.parent = transform;
                warriors[i].GetComponent<Warriorsupport>().SetReturnPoint(returnPoints[i]);
                countDown = 5f;
            }   
        }

    }
    
    // THIS PART SEARCHS FOR ENEMY
    void FindTarget()
    {
        /*if (hasTarget)
        {
            return;
        }*/

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestdistance = Mathf.Infinity; //Eðer düþman bulunmamýþsa düþmana olan mesafemiz sonsuzdur. nE!?!?
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)// find closest target 
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestdistance)
            {
                shortestdistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestdistance <= range)
        {
            hedef = nearestEnemy.transform; //if closest enemy is in range, its the target.   
        }
        else
        {
            hedef = null;
        }
    }

}
