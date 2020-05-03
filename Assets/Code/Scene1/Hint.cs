using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    private bool showText = false;
    private bool hideText = true;
    private string doc = "dffuck";
    private Color process = new Color(1, 1, 1, 0);

    private float timePast = 0;
    private float timeSpan = 0.025f;
    private float transp = 0;
    private float changeAmount = 0.025f;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Text>().color = new Color(1, 1, 1, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        timePast += Time.deltaTime;// Delta time control system

        if(showText && timePast >= timeSpan && transp <= 1)//show up the text
        {
            timePast -= timeSpan;
            transp += changeAmount;
            gameObject.GetComponent<Text>().color = new Color(1, 1, 1, transp);
        }else if(transp >= 1)//finish show
        {
            showText = false;
        }
        
        if(hideText && timePast >= timeSpan && transp >= 0)//hide the text gradually
        {
            timePast -= timeSpan;
            transp -= changeAmount;
            gameObject.GetComponent<Text>().color = new Color(1, 1, 1, transp);
        }else if(transp <= 0)
        {
            hideText = false;
        }
        

    }



    public void show(string text)
    {
        doc = text;
        showText = true;
        //gameObject.GetComponent<Text>().color = new Color(1, 1, 1, 1);
    }

    public void hide()
    {
        hideText = true;
        showText = false;
        //gameObject.GetComponent<Text>().color = new Color(1, 1, 1, 0);
    }

}
