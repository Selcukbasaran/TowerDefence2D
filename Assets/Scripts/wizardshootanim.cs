using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardshootanim : MonoBehaviour
{
    public GameObject fireAnim;

    public void Shoot()
    {
        GameObject fire = (GameObject)Instantiate(fireAnim, transform.position, transform.rotation);
        Destroy(fire, (float)0.5);
    }

}
