using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oldLady : MonoBehaviour
{
    Animator a;
    GameObject hint;
    GameObject dgSystem;
    GameObject player;
    private bool canTalk = false;
    private int e_counter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        a = gameObject.GetComponent<Animator>();
        hint = GameObject.Find("Canvas/hint");
        dgSystem = GameObject.Find("DialogueSystem");
        player = GameObject.Find("ghost");
    }

    // Update is called once per frame
    void Update()
    {
        
        if(canTalk && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return)))//really talk - press e while the player in the talking area
        {
            Debug.Log("Pressed E, e_c = " + e_counter);
            if(e_counter == 0)
            {
                Debug.Log("initialize, e_c = " + e_counter);
                talkingProcedure();
            }else if(e_counter + 1 < herScript.Length)//talking control -- the sentences control while talking
            {
                e_counter += 1;
                Debug.Log("in talk, e_c = " + e_counter);
                dgSystem.GetComponent<dialogSystem>().displayText(herScript[0] + herScript[e_counter]);
            }else//all sentences were out, so end the conversation
            {
                endTalkProcedure();
            }
        }
        if(canTalk && Input.GetKeyDown(KeyCode.Escape))// Stop Talk
        {
            endTalkProcedure();
        }


    }//Update function ended=====================

    private void talkingProcedure()//talking initailize -- dgSystem
    {
        dgSystem.GetComponent<dialogSystem>().displayText(herScript[0] + herScript[e_counter+1]);
        dgSystem.GetComponent<dialogSystem>().startTalk();

        player.GetComponent<ghostControl>().freezePlayer = true;//freeze the player while talking
        e_counter = 1;
    }


    private void endTalkProcedure()
    {
        e_counter = 0;
        player.GetComponent<ghostControl>().freezePlayer = false;//unfreeze the player
        dgSystem.GetComponent<dialogSystem>().endTalk();
        //dgSystem.GetComponent<dialogSystem>().displayText("Null");
    }



    //*Fisrt space is always the name
    private string[] herScript = {"Meat Guy: \n", "Hi! Can you hear me? How are you",
    "I have some meat soup! do you want to have some meat soup?", "What? You have NO MONEY? No way, FUCK YOU"};




//! ON Collission-------

    

    private void OnTriggerEnter2D(Collider2D other)//if the player enter the surrounding area
    {
        a.SetTrigger("smile");
        canTalk = true;
        hint.GetComponent<Hint>().show("Press Esc to close");//show the hint
        e_counter = 0;//initialize e counter

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Leave");
        a.SetTrigger("not_smile");
        canTalk = false;
        hint.GetComponent<Hint>().hide();
        e_counter = 0;
    }

    





}
