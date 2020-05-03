using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//!! This class is a Data structure, so DO NOT Inherit this class, but inherit normalItem
public class Item //item class -- a blueprint of an item
{
    public string name;//name or the type of the item

    GameObject player;

    public Item(string name)//*Constructor -- initialize name
    {
        this.name = name;
        player = GameObject.Find("ghost");
    }

    //* function that helps you easily let the item be got by player, and stored in the package
    public bool getItem()//if return true, please destroy the object, if false, means get fail
    {
        //get 1 this.name type item, if return false, means get item fail
        bool hitted = player.GetComponent<ghostControl>().getItem(this.name, 1);
        if(hitted)//if successfully get the item
        {
            return true;//because item class blueprint does not have the right to destroy the object
        }else{
            Debug.Log("!!!!!!!!!! ERROR !!!!!! ----- Object not in all Dict");
            return false;
        }
    }



}
