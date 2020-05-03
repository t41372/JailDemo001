using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogSystem : MonoBehaviour
{
    GameObject dialogBox;
    GameObject Dtext;
    GameObject hint;
    GameObject package_button;
    public Text DText;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogBox = GameObject.Find("DialogueSystem/dialogueBox");
        Dtext = GameObject.Find("DialogueSystem/DText");
        hint = GameObject.Find("Canvas/hint");
        package_button = GameObject.Find("Canvas/BackPackButton");
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startTalk()
    {
        //Move away the package button and show the other things
        hint.GetComponent<Hint>().hide();
        package_button.transform.position = new Vector2(-1300,-1300);
        dialogBox.GetComponent<Image>().color = new Color(255,255,255,255);
        Dtext.GetComponent<Text>().color = new Color(255,255,255,255);

    }
    public void endTalk()
    {
        package_button.transform.position = new Vector2(116,116);
        dialogBox.GetComponent<Image>().color = new Color(255,255,255,0);
        Dtext.GetComponent<Text>().color = new Color(255,255,255,0);
    }

    public void displayText(string text)
    {
        //Dtext.GetComponent<Text>().text = text;
        DText.text = text;
    }

    public void scriptDisplay()//todo----auto-play, Don't control by charactor but here
    {

    }




}
