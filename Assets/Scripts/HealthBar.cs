using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform bar;
    //float healthbar = 1f;
    float healthOfObject;
    float currentHealth;
    // Start is called before the first frame update
    public bool dead = false;
    public void Start()
    {
        Transform bar = transform.Find("Bar");
        //bar.localScale = new Vector3(0.4f, 1f);
        healthOfObject = transform.parent.transform.gameObject.GetComponent<AdjustHealth>().Health;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (dead) return;
        currentHealth = transform.parent.transform.gameObject.GetComponent<AdjustHealth>().Health;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            dead = true;
            float barScaleEnd = currentHealth / healthOfObject;
            bar.localScale = new Vector3(barScaleEnd, bar.localScale.y);
            Destroy(gameObject);
            return;
        }
        float barScale = currentHealth / healthOfObject;
        bar.localScale = new Vector3(barScale, bar.localScale.y);

        

    }

    /*public void updateBar(int damage,int health)
    {
        float new_scale = (health - damage) / health;
        bar.localScale = new Vector2(new_scale, 1f);
    }*/
}
