using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgraderChild : MonoBehaviour
{
    public Transform currentTower;
    public parts part;


    void OnMouseDown()
    {
        currentTower = transform.parent.parent.GetChild(0);
        part = currentTower.GetComponent<Types>().getPart();
        
        
        Destroy(transform.parent.gameObject); 
        transform.parent.GetComponent<UpgradeTower>().UpgradeT(part);
        
        
        //transform.parent.GetComponent<SelectTower>().BuildTower(part);

        //(currentTower, transform.position, transform.rotation);
    }

}
