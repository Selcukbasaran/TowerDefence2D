using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    private Animator animator;
    public float speed = 5f;

    private int Health;
    public GameObject looseHealth;


    private Transform target; // hedef waypoint
    private int waypointindex = 0; // kaçýncý waypointe hedefli

    public bool facingR = true; // saða bakýyor


    void Start()
    {
        target = Waypoints.waypoints[0];
        looseHealth = GameObject.Find("Gamemanager");
        animator = gameObject.GetComponent<Animator>();
        //InvokeRepeating("isDead", 0f, 0.2f); // saniyede iki defa öldü mü diye kontrol etsin
    }


    void Update()
    {
        Health = transform.gameObject.GetComponent<AdjustHealth>().Health;
        if (Health <= 0)
        {

            transform.gameObject.tag = "Untagged";
            animator.Play("WarriorDie");
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
