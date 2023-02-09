using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustHealth : MonoBehaviour
{
    public int Health;
    //public Transform bar;
    

    private void Start()
    {
        //bar = transform.Find("Bar");
    }

    public void LooseHealth(int n)
    {
        Health -= n;
        //bar.gameObject.GetComponent<HealthBar>().updateBar(n,Health);
    }
}
