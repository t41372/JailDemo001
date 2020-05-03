using System.Collections.Generic;
using System.Collections;
using UnityEngine;



public class ghostControl : MonoBehaviour
{
    //*                                                                 name, the Item 
    public Dictionary<string, Item> allItemDictionary = new Dictionary<string, Item>();//!the Dictionary that contains all kinds of item IN THE GAME
    
    public bool freezePlayer = false;
    private float walkSpeed = 100f;
    public Dictionary<string, int> inventory = new Dictionary<string, int>();
    
    Rigidbody2D r;
    GameObject inventoryPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        r = gameObject.GetComponent<Rigidbody2D>();
        inventoryPanel = GameObject.Find("Canvas/Inventory");
        initializeAllItemDict();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))//open the inventory panel
        {
            inventoryPanel.GetComponent<inventoryUISystem>().packageButtonDown();
        }

        //transform.Translate(key * walkSpeed);
        if(freezePlayer == false)
            r.AddForce(moveKey() * walkSpeed);

        r.velocity = new Vector2(0,0);
        

    }

    private Vector2 moveKey()
    {
        Vector2 key = new Vector2();
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            key.y = 1;
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            key.x = -1;
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            key.y = -1;
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            key.x = 1;

        return key;
    }


    public bool getItem(string name, int number)//? If got the item successfully, return true. If there is no such item in allItemDict, return false
    {
        //inventory<>
        bool ifInDict = allItemDictionary.ContainsKey(name);
        Debug.Log("All item dict has key item" + ifInDict);

        if(ifInDict)//if the item exists in allItemDictionary, then the player can get the item
        {
            if(inventory.ContainsKey(name))
            {
                Debug.Log("Back pack has item, number add 1");
                inventory[name] += number;
            }else{
                inventory.Add(name, number);
                Debug.Log("Back pack don't have, add item");
            }

        }else{
            Debug.Log("Get item failed -- no such element in all dictionary");
            return false;
        }


        return true;
    }








    private void initializeAllItemDict()
    {
        allItemDictionary.Add("bit_key", new Item("bit_Key"));
        allItemDictionary.Add("strangeCat", new Item("strangeCat"));
        allItemDictionary.Add("strangeKnowledge", new Item("strangeKnowledge"));
        allItemDictionary.Add("apple", new Item("apple"));
    
    }
    





}
