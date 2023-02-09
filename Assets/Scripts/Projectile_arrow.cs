using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_arrow : MonoBehaviour
{
    private Transform hedef;
    public bool face = true;

    public float speed = 10f;
    private int Damage;

    public void Chase(Transform _target , int n)
    {
        hedef = _target;
        Damage = n;
    }

    // Update is called once per frame
    void Update()
    {
        if (hedef == null)
        {
            Destroy(gameObject);
            return; // bazen yoketme zaman alabilir yok etmesini beklememiz lazým
        }
        if (face)
        {
            Vector3 tempLocalScale = gameObject.transform.localScale;
            tempLocalScale.z *= -1;
            gameObject.transform.localScale = tempLocalScale;
        }
        else if(!face)
        {
            Vector3 tempLocalScale = gameObject.transform.localScale;
            tempLocalScale.z *= -1;
            gameObject.transform.localScale = tempLocalScale;
        }

        Vector2 dir = hedef.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        //Debug.Log("Vurdum!!");
        hedef.gameObject.GetComponent<AdjustHealth>().LooseHealth(Damage);
        Destroy(gameObject);
        
        //Destroy(hedef.gameObject); //þimdilik vurulan çýksýn
    }
}
