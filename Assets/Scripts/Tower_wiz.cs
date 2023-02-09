using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Tower_wiz : MonoBehaviour
{
    [Header("Kule Yetenekleri")]

    public Transform hedef;
    public float range = 5f;

    public float fireRate = 1f;
    private float fireCooldown = 0f;
    public int Damage;

    [Header("Unity ayarlarý")]
    public string enemyTag = "Enemy";

    public GameObject wizProjectile; //ok için referans
    public Transform wiz_firePoint;
    public GameObject shootanim;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // saniyede iki defa update döndür.

    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
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
            hedef = nearestEnemy.transform;
        }
        else
        {
            hedef = null;
        }

    }

    private void Update()
    {
        if (hedef == null) return; // hedef yoksa devam et

        if (fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }

        fireCooldown -= Time.deltaTime;
    }

     void Shoot()
    {
        GameObject projectile = (GameObject)Instantiate(wizProjectile, hedef.position,hedef.rotation);
        GameObject shootAnimation = (GameObject)Instantiate(shootanim, wiz_firePoint.position, hedef.rotation);
        hedef.gameObject.GetComponent<AdjustHealth>().LooseHealth(Damage);
        Destroy(projectile, (float)0.5);
        Destroy(shootAnimation, (float)0.5);
    }


    private void OnDrawGizmos() // tower etrafýnda menzilin görünmesi için
    {                           // sadece seçince çizdirmek için OnDrawGizmosSelected()
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
