using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertController : MonoBehaviour
{   
    emptyscript master = null;
    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.Find("MasterObject").GetComponent<emptyscript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(master.undefused >= 7)
        {
            Vector3 position = transform.position;
            position.z = -1.0f;
            transform.position = position;
        }
        else
        {
            Vector3 position = transform.position;
            position.z = 1.0f;
            transform.position = position;
        }
        if(master.gameover != 0)
        {
            Vector3 position = transform.position;
            position.z = 1.0f;
            transform.position = position;
        }
    }
}
