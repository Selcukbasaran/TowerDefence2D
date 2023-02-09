using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerBase : MonoBehaviour
{
    //renk verme
    [Header("Secim rengi")]
    public Color new_color;

    private SpriteRenderer spriteRenderer;
    //private Renderer rend;
    private Color startcolor;
    //renk verme bitiþ

    public GameObject towerSelect;
    private GameObject towerPick;
    public GameObject towerUpgrade;
    private GameObject towerupgrader;

    public Vector3 positionOffset_archer;
    public Vector3 positionOffset_wizard;

    public bool towerBuildable = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.material.color = Color.red;
        startcolor = spriteRenderer.material.color;
    }


    private void OnMouseDown()
    {
        if (transform.childCount != 0) //child varsa kule var.
        {
            towerupgrader = (GameObject)Instantiate(towerUpgrade, transform.position, transform.rotation);
            towerupgrader.transform.parent = transform;
            
            //Debug.Log("Zaten kule var! - TODO: Bu kýsým kullanýcý için ekrana yazýlsýn");
            //return;
        }
        else
        {
            towerPick = (GameObject)Instantiate(towerSelect, transform.position, transform.rotation);
            towerPick.transform.parent = gameObject.transform;
        }
        // Kule kurma
        //GameObject towerToBuild = TowerBuilder.instance.GetTowerToBuild();
        //tower = (GameObject)Instantiate(towerToBuild, transform.position + positionOffset_wizard, transform.rotation);
        // Kule seçici deneme

        

    }
    


    void OnMouseEnter()
    {
        spriteRenderer.material.color = new_color;
        //Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        spriteRenderer.material.color = startcolor;
        
    }


}
