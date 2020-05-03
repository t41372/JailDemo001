using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryUISystem : MonoBehaviour
{
    GameObject player;
    public Text showList;
    public Text selector;
    public Color panel_Color;//the target color of the panel
    public Color textColor;
    protected Color noColor = new Color(0,0,0,0);
    public bool inventoryShowState = false;
    private int selectorStage = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("ghost");
        hideInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(inventoryShowState)//if the Inventory panel is Opened
        {
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))//user wants to up move the selector
            {
                selectorUpMove();
            }else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                selectorDownMove();
            }else if(Input.GetKeyDown(KeyCode.Return))//Selecting Functioning Panel
            {
                showSelectFunctionalPanel();
            }
        }




    }

//*****-------------------Inventory Panel System-------------------------------------------------------------

    public void packageButtonDown()
    {
        if(inventoryShowState)
        {
            hideInventory();
        }else{
            showInventory();
        }
    }

    public void showInventory()
    {
        //!First freeze the player
        player.GetComponent<ghostControl>().freezePlayer = true;
        //show the panel
        gameObject.GetComponent<Image>().color = panel_Color;
        showList.color = textColor;
        selector.color = textColor;
        inventoryShowState = true;
        
        //first set the show text
        //set the sources of the text
        Dictionary<string, int> inv = player.GetComponent<ghostControl>().inventory;
        Dictionary<string, Item> allDict = player.GetComponent<ghostControl>().allItemDictionary;

        //start to put text on to the panel
        if(inv.Count == 0)//if nothing in the back pack
        {
            showList.text = "Back Pack is empty";//tell the user
        }else
        {
            showList.text = "";//first clear the old text
            foreach(KeyValuePair<string, int> k in inv)//show text on the panel
            {
                //*             show the name + number
                showList.text = showList.text + k.Key + " *" + k.Value + "\n";
            }
        }
        
    }

    public void hideInventory()
    {
        //Fisrt unfreeze the player
        player.GetComponent<ghostControl>().freezePlayer = false;

        Debug.Log("Hide the panel");
        gameObject.GetComponent<Image>().color = noColor;
        showList.color = noColor;
        selector.color = noColor;
        inventoryShowState = false;
    }

//*****-------------------Selector Move---------------------------------------------------------------------

    public void selectorUpMove()
    {
        if(selectorStage == 0) return;//if the selector is at the highest place, then it can not move higher, stop the function

        selectorStage -= 1;
        selector.text = "";//first initialize the text
        //use a for-loop to build the space before the >
        for(int indx = 0; indx < selectorStage; indx ++)
        {
            selector.text = selector.text + "\n";
        }
        selector.text = selector.text + ">";
        

    }

    public void selectorDownMove()
    {
        //! There is no height limit YET, So in this stage, the selector can invifitly moving down 
        selectorStage += 1;
        selector.text = "";//first initialize the text
        //use a for-loop to build the space before the >
        for(int indx = 0; indx < selectorStage; indx ++)
        {
            selector.text = selector.text + "\n";
        }
        selector.text = selector.text + ">";

    }

    //!!!!!!!!!--- ADD a select functioning panel
    public void showSelectFunctionalPanel()
    {
        //todo Can use dg System, but the dg system cannot handle decision making yet...
    }


}
