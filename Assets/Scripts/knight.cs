using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight : MonoBehaviour
{
    private Animator animator;
    

    private int Health;
    public GameObject looseHealth;
    public bool isIdle;
    public Rigidbody2D rb;
    Collider2D m_collider;
    private bool alreadyDead = false;

    private Transform target; // hedef waypoint
    private int waypointindex = 0; // kaçýncý waypointe hedefli

    public bool facingR = true; // saða bakýyor

    public GameObject looseHealtForEnemy;
    public bool opponentDead = false;
    public float speed;

    //public string tag2 = "EnemyFight";

    private GameObject Gold; //for obtaining gold when killed. This is the game manager
    void Start()
    {
        isIdle = true;
        target = Waypoints.waypoints[0];
        looseHealth = GameObject.Find("GameManager");
        animator = gameObject.GetComponent<Animator>();
        //InvokeRepeating("isDead", 0f, 0.2f); // saniyede iki defa öldü mü diye kontrol etsin
        transform.GetComponent<Rigidbody2D>();
        animator.SetBool("isIdle", true);
        m_collider = gameObject.GetComponent<Collider2D>();
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Yusuuuuuuuuuf");
        //transform.gameObject.tag = "EnemyFight";
        //transform.Translate(Vector2.down, Space.World);
        animator.SetBool("isIdle", false);
        
        gameObject.layer = 30;
        InvokeRepeating("Duel", 0f, 1.2f);
        looseHealtForEnemy = collision.gameObject;
        
        
    }
    void Duel()
    {
        Debug.Log("Yeaa we are duelling right now. WOW");

        looseHealtForEnemy.GetComponent<AdjustHealth>().LooseHealth(7);
        if (looseHealtForEnemy.GetComponent<AdjustHealth>().Health <= 0) opponentDead = true;
        if (opponentDead)
        {
            CancelInvoke("Duel");
            //animator.SetBool("isIdle", true);
            
            gameObject.layer = 30;
            transform.gameObject.tag = "Enemy";// Layer 11:SupportTowerUnits
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        CancelInvoke("Duel");
        Debug.Log("BUNU TAKIP ET");
        gameObject.layer = 10; // Layer 10: Enemy
        animator.SetBool("isIdle", true);
        
        transform.gameObject.tag = "Enemy";
    }*/


    void Update()
    {
        speed = gameObject.GetComponent<SpeedNDuel>().GetSpeed();
        if (alreadyDead) return;
        

        
        Health = transform.gameObject.GetComponent<AdjustHealth>().Health;
        if (Health <= 0)
        {
            Gold = GameObject.Find("GameManager");
            Gold.GetComponent<Stats>().PlusGold(25);
            alreadyDead = true;
            transform.gameObject.tag = "Untagged";
            gameObject.layer = 14; //99. layer ölen düþman birliklerin layerý
            m_collider.enabled = !(m_collider.enabled);
            //Debug.Log("Collider is " + m_collider.enabled);
            animator.Play("KnightDie");
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
