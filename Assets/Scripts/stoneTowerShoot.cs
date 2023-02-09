using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneTowerShoot : MonoBehaviour
{
    [Header("Kule Yetenekleri")]

    public Transform hedef;
    public float range = 5f;

    public float fireRate = 4f;
    private float fireCooldown = 0f;
    public int Damage;
    public Transform projSpawn;
    public GameObject stoneProj;

    [Header("Düþman Tag'i")]
    public string enemyTag = "Enemy";


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); 
    }

    // Update is called once per frame
    void Update()
    {
        if (hedef == null) return;

        if (fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }

        fireCooldown -= Time.deltaTime;
    }



    //Shoot
    void Shoot()
    {
        GameObject projectile = (GameObject)Instantiate(stoneProj, projSpawn.position, projSpawn.rotation);
        projectile.transform.parent = transform;
        projectile.gameObject.GetComponent<ArcShot>().StartCoro(hedef);

    }


    //Find target 
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity; // Hala bunu anlamadým BUNU ÝNCELE!!!!!!
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            hedef = nearestEnemy.transform; //Düþmaný al
        }
        else
        {
            hedef = null;
        }
        
    }

}
