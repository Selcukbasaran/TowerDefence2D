using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcShot : MonoBehaviour
{
    public AnimationCurve curve;
    public Transform target;
    public Animator anim;

    private Vector3 start;
    private Coroutine coroutine;

    public string enemyTag = "Enemy";
    public float blastRange;
    private int damage; //comes from tower

    private void Awake()
    {
        start = transform.position;
        //anim = transform.gameObject.GetComponent<Animator>();
        //damage = transform.parent.gameObject.GetComponent<stoneTowerShoot>().Damage;
    }
    private void Start()
    {
        anim = transform.gameObject.GetComponent<Animator>();
        damage = transform.parent.gameObject.GetComponent<stoneTowerShoot>().Damage;
    }

    private void Update()
    {
        /*if (coroutine == null)
        {
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                coroutine = StartCoroutine(Curve());
            }
        }*/
    }
    public void StartCoro(Transform t)
    {
        target = t;
        coroutine = StartCoroutine(Curve());
    }

    IEnumerator Curve()
    {
        float duration = 1.50f; //projectile flight duration
        float time = 0f;

        Vector3 end = target.position - (target.forward * 0.55f); // lead the target a bit to account for travel time, your math will vary

        while (time < duration)
        {
            time += Time.deltaTime;

            float linearT = time / duration;
            float heightT = curve.Evaluate(linearT);

            float height = Mathf.Lerp(0f, 3.0f, heightT); // change 3 to however tall you want the arc to be

            transform.position = Vector2.Lerp(start, end, linearT) + new Vector2(0f, height);

            yield return null;
        }

        // impact 
        //Debug.Log("Vurdum");
        anim.SetBool("impact", true);  
        //Find target who got hit
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < blastRange)
            {
                enemy.GetComponent<AdjustHealth>().LooseHealth(damage);
            }
        }
        Destroy(gameObject, 0.6f);
        coroutine = null;
    }
}
