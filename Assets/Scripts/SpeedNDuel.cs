using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedNDuel : MonoBehaviour
{
    private float setSpeed;
    public float speed = 1f;
    public int damage;

    private GameObject Unit;
    private bool duelling = false;

    public Transform hedef;
    // Start is called before the first frame update
    void Start()
    {
        Unit = transform.gameObject;
    }
    public void StartDuel(Transform target)
    {
        if (!duelling)
        {
            hedef = target;
            speed = 0;
            InvokeRepeating("Duel", 0f, 1.5f);
            duelling = true; 
        }
    }
    void Duel()
    {
        //Debug.Log("Ya nolur çalýþ hadi ya");
        if (hedef == null)
        {
            duelling = false;
            speed = 1;
        }
        hedef.gameObject.GetComponent<AdjustHealth>().LooseHealth(damage);
    }
    // Update is called once per frame
    void Update()
    {
        if (Unit.GetComponent<AdjustHealth>().Health <= 0)
        {
            CancelInvoke("Duel");
        }
        if (hedef == null)
        {
            speed = 1;
        }

    }


    public void SetSpeed(float value)
    {
        speed = value;
    }
    public float GetSpeed()
    {
        return speed;
    }
}
