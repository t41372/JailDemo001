using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialItemEG : normalItem
{
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("ghost");
        nItem = new Item(item_name);
        Debug.Log("Special Item Created");
        item_name = "strangeKnowledge";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
