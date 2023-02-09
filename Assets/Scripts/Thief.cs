using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    private Animator animator;
    public float speed = 5f;

    private int Health;
    public GameObject looseHealth;


    private Transform target; // hedef waypoint
    private int waypointindex = 0; // kaçýncý waypointe hedefli

    public bool facingR = true; // saða bakýyor

    public GameObject looseHealtForEnemy;
    public bool opponentDead = false;


    void Start()
    {
        target = Waypoints.waypoints[0];
        looseHealth = GameObject.Find("Gamemanager");
        animator = gameObject.GetComponent<Animator>();
        //InvokeRepeating("isDead", 0f, 0.2f); // saniyede iki defa öldü mü diye kontrol etsin
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //transform.Translate(Vector2.down, Space.World);
        animator.SetBool("isIdle", false);
        speed = 0;
        gameObject.layer = 30;
        InvokeRepeating("Duel", 0f, 1.2f);
        looseHealtForEnemy = collision.gameObject;
    }
    void Duel()
    {
        //Debug.Log("Yeaa we are duelling right now. WOW");
        try
        {
            looseHealtForEnemy.GetComponent<AdjustHealth>().LooseHealth(7);
            if (looseHealtForEnemy.GetComponent<AdjustHealth>().Health <= 0) opponentDead = true;
        }
        catch (System.Exception)
        {
            opponentDead = true;
            throw;
        }
        
        if (opponentDead)
        {
            CancelInvoke("Duel");
            //animator.SetBool("isIdle", true);
            //speed = 1;
            gameObject.layer = 10; // Layer 11:SupportTowerUnits
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        CancelInvoke("Duel");
        gameObject.layer = 10; // Layer 10: Enemy
        animator.SetBool("isIdle", true);
        speed = 1;

    }



    void Update()
    {
        Health = transform.gameObject.GetComponent<AdjustHealth>().Health;
        if (Health <= 0)
        {
            WaveSpawner.enemyCount--;
            transform.gameObject.tag = "Untagged";
            animator.Play("ThiefDie");
            Destroy(gameObject, 1.7f);
            return;

        }


        Vector2 directions = target.position - transform.position; //hedef ver
        transform.Translate(directions.normalized * speed * Time.deltaTime, Space.World);

        if (directions.x < 0 && facingR)
        {
            flipface();
        }
        if (directions.x > 0 && !facingR)
        {
            flipface();
        }



        if (Vector2.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextWayp();
        }

    }

    void GetNextWayp()
    {
        if (waypointindex >= Waypoints.waypoints.Length - 1) //Sonuncu waypointe gelmiþse yok olsun.
        {
            looseHealth.GetComponent<Stats>().LooseGameHealth();
            Destroy(gameObject);
            return;
        }
        waypointindex++;
        target = Waypoints.waypoints[waypointindex];
    }






    void flipface()
    {
        facingR = !facingR;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }
}
