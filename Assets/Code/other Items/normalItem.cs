using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//!! This class is the super class of all item, so inherit this class if you want to create an item
public class normalItem : MonoBehaviour
{
    //item's basic attributes
    protected GameObject player;
    public Item nItem;
    public string item_name = "uninitailized item";
    
    // Start is called before the first frame update
    public void Start()
    {
        player = GameObject.Find("ghost");
        nItem = new Item(item_name);
        //Debug.Log("Parent class" + item_name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)//! Get an item
    {
        this.getItem();
    }

    ///<Summary> Tim's Worl -- <c>Normal item class</c> \n
    ///Be called when player get this item. This function first put this item into package and then destroy the item itself
    ///<Param name = "no name">     No parameter </Param>
    ///</Summary>
    public void getItem()
    {
        bool destroy = nItem.getItem();
        if(destroy)
        {
            Destroy(gameObject);
            
        }
    }





}
