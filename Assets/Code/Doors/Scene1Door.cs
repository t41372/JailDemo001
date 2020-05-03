using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Door : MonoBehaviour
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
        Debug.Log("Hit door ok");
        if(other.transform.position.y < transform.position.y)
        {
            cam.GetComponent<camCon>().moveCamVertical(8, 1);
        }else if(other.transform.position.y > transform.position.y)
        {
            cam.GetComponent<camCon>().moveCamVertical(0, 1);
        }
    }


}
