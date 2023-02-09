using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchUp1 : MonoBehaviour
{
    [Header("Kule Yetenekleri")]

    public Transform hedef;
    public float range = 5f;

    public float fireRate = 1f;
    private float fireCooldown = 0f;

    public int Damage;

    [Header("Unity ayarlar�")]
    public string enemyTag = "Enemy";

    public GameObject arrowPrefab; //ok i�in referans
    public Transform firePoint;     //okun spawn olaca�� nokta

    public Transform archerOnTower;
    Animator archerShoot;
    private bool facingRight = true;
    float yonHesabi;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); //update target fonksiyonu saniyede iki defa d�necek.
        archerOnTower = this.gameObject.transform.GetChild(0);
        archerShoot = archerOnTower.gameObject.GetComponent<Animator>();

    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestdistance = Mathf.Infinity; //E�er d��man bulunmam��sa d��mana olan mesafemiz sonsuzdur !?!?
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
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
            hedef = nearestEnemy.transform;   //d��man bulduk menzilimizde o zaman hedefimiz o d��man

            yonHesabi = transform.position.x - hedef.position.x;

            if (yonHesabi > 0 && facingRight)
            {
                flipFace();
            }
            if (yonHesabi <= 0 && !facingRight)
            {
                flipFace();
            }
        }
        else
        {
            hedef = null;
        }
    }

    void Update()
    {
        if (hedef == null) return; //hedefimiz yoksa yapacak bir �ey yok devam-->

        if (fireCooldown <= 0f)
        {

            Shoot();
            fireCooldown = 1f / fireRate;

        }

        fireCooldown -= Time.deltaTime;

    }

    void Shoot()
    {
        archerShoot.Play("ArcherShoot1");
        GameObject projectile = (GameObject)Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);

        Projectile_arrow arrow = projectile.GetComponent<Projectile_arrow>();

        if (arrow != null)
        {
            arrow.Chase(hedef,Damage);
        }

        return;
    }


    private void OnDrawGizmos() // tower etraf�nda menzilin g�r�nmesi i�in
    {                           // sadece se�ince �izdirmek i�in OnDrawGizmosSelected()
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void flipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = archerOnTower.localScale;
        tempLocalScale.x *= -1;
        archerOnTower.localScale = tempLocalScale;
    }

}
