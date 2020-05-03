using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondGround : MonoBehaviour
{
    GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        cam.GetComponent<camCon>().follow("ghost");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        cam.GetComponent<camCon>().followSomeone = false;
    }

}
