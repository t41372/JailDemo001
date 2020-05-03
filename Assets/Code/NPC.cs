using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //* Load Outter Objects
    Animator a;
    GameObject hint;
    GameObject dgSystem;
    GameObject player;

    //* Attributes
    private bool canTalk = false;

    //* Script Controller
    private int language = 0;
    private int currentChapter = 0;
    private int sentenceControl = 0;

    //? Max values
    private int max_language = 1;

    //* Script--------------
    private string[] ChapterScript; //? chapter, sentence
    public TextAsset scriptAsset;
    //* Script End----------


    //* NPC'S Attribute (You need to rewrite it in your own NPC)
    public string name;

    //* Functional Keys
    KeyCode talkKey = KeyCode.R;
    KeyCode talkKey2 = KeyCode.Return;
    
    
    
    
    
    // Start is called before the first frame update
    public void Start()
    {
        a = gameObject.GetComponent<Animator>();
        hint = GameObject.Find("Canvas/hint");
        dgSystem = GameObject.Find("DialogueSystem");
        player = GameObject.Find("ghost");

        scriptInitializor();
    }

    // Update is called once per frame
    public void Update()
    {
        
        
        
        
        if(canTalk && (Input.GetKeyDown(talkKey) || Input.GetKeyDown(talkKey2) ) )
        {
            Debug.Log("talk");




        }




    }


    //* Can talk control (Enter the area)
    public void canNowTalk()
    {
        //* can add animations here
        canTalk = true;
    }

    public void canNotTalk()
    {
        canTalk = false;
    }

    //* Change Chapter
    public void changeChapter(int chapterNumber)
    {
        currentChapter = chapterNumber;
    }


    //* Scipt initialize

    private void scriptInitializor()
    {
        
        string[] lines = scriptAsset.text.Split('\n');//get all lines in Script txt
        List<string> sentencesInChapter = new List<string>();//! 或許可以拿來存不同chpater 的台詞 還沒寫
        string thisChapter = "";

        for(int indx = 0; indx < lines.Length; indx ++)
        {
            Debug.Log(lines[indx]);//* 不過現在從文件讀取信息應該沒有什麼問題...
            //! 應該要在這裡把空行刪除 並且將對應chapter的台詞存進某個地方....
            //? 經過了一番嘗試 空行實在是刪不掉

            if(lines[indx].Contains("$chapter_"))// change chapter
            {
                Debug.Log("Change Chapter---------!!!!");
                sentencesInChapter.Add(thisChapter);//add the sentences in last chapter into the list
                thisChapter = "";
            }else// Not Change Chapter
            {
                thisChapter = thisChapter + "^%" + lines[indx];
            }




        }
        sentencesInChapter.Add(thisChapter);//wrap up, to add the final piece of sentence into the last chapter
        
        Debug.Log("====================分隔線====================");
        
        
        ChapterScript = new string[sentencesInChapter.Count];

        for(int indx = 0; indx < sentencesInChapter.Count; indx ++)
        {
            Debug.Log(sentencesInChapter[indx]);
            ChapterScript[indx] = sentencesInChapter[indx];

        }



    }




}
