using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrioryeni : MonoBehaviour
{
    public float speed = 1f;
    public int damage;

    private int health;
    public Transform returnPoint;

    public bool hasTarget = false;
    public string enemyTag = "Enemy";
    public Transform hedef;
    public float towerRange;
    public bool alreadyDuelling = false;
    public bool enemyduelling = false;
    private bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        towerRange = transform.parent.GetComponent<SupTower>().range;
        //InvokeRepeating("FindTarget", 0f, 0.1f);// 53ü unutma
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.gameObject.GetComponent<AdjustHealth>().Health <= 0)
        {
            
            dead = true;
            Destroy(gameObject);
            return;
        }
        if (dead)
        {
            return;
        }
        if (hedef != null && Vector2.Distance(transform.parent.position,hedef.position) >= towerRange )
        {
            hedef = null;
            speed = 1;
            alreadyDuelling = false;
            enemyduelling = false;
        }
        if (hedef == null)
        {
            CancelInvoke("Duel");
            Vector2 returnBack = returnPoint.transform.position - transform.position; //hedef ver
            transform.Translate(returnBack.normalized * speed * Time.deltaTime, Space.World);
            alreadyDuelling = false;
            enemyduelling = false;
            return;
        }
        if (alreadyDuelling)
        {
            return;
        }
        
        Vector2 directions = hedef.transform.position - transform.position; //hedef ver
        transform.Translate(directions.normalized * speed * Time.deltaTime, Space.World);


        if (Vector3.Distance(hedef.position, transform.position) <= 0.08f)
        {
            if (!enemyduelling)
            {
                hedef.gameObject.GetComponent<SpeedNDuel>().StartDuel(transform);
                enemyduelling = true;
            }
            alreadyDuelling = true;
            //speed = 0;
            hedef.gameObject.GetComponent<SpeedNDuel>().SetSpeed(0f);
            InvokeRepeating("Duel", 0f, 1.5f);

        }


    }

    void Duel()
    {
        
        
        //Debug.Log("haber et");
        try
        {
            hedef.gameObject.GetComponent<AdjustHealth>().LooseHealth(damage);
        }
        catch (System.Exception)
        {
            hedef = null;
            alreadyDuelling = false;
            CancelInvoke("Duel");
        }
        
        
    }
    

    public void SetTarget(Transform value)
    {
        hedef = value;
    }
    public void SetReturnPoint(Transform value)
    {
        returnPoint = value;
    }
}
