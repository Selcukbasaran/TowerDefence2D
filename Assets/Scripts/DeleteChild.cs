using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteChild : MonoBehaviour
{
    void OnMouseDown()
    {
        Destroy(transform.parent.parent.GetChild(0).gameObject);
        Destroy(transform.parent.gameObject);
    }
}
