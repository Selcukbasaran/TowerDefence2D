using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectChild_archer : MonoBehaviour
{
    public parts part;

    private void OnMouseDown()
    {
        transform.parent.GetComponent<SelectTower>().BuildTower(part); 
        Destroy(transform.parent.gameObject);
    }
}
