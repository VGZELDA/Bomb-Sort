using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{   
    // Start is called before the first frame update
    emptyscript master = null;

    void Start()
    {
        master = GameObject.Find("MasterObject").GetComponent<emptyscript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown () 
    {   
        Debug.Log("Clicked start");
        Vector3 position = transform.position;
        position.z = 2.0f;
        transform.position = position;
        master.started = 1;
    }
}
