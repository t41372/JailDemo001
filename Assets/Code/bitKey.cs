using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bitKey : MonoBehaviour
{
    GameObject player;
    Item bit_key;
    public string item_name = "bit_key";

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("ghost");
        bit_key = new Item(item_name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)//! Get an item
    {
        bool destroy = bit_key.getItem();
        if(destroy)
        {
            Destroy(gameObject);
        }
    }
}
