﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dontShow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().color = new Color(0,0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
