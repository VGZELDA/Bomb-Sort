using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePower : MonoBehaviour
{   
    // Start is called before the first frame update
    emptyscript master = null;
    public float powernumber;

    void Start()
    {
        Destroy(gameObject,5f);
        master = GameObject.Find("MasterObject").GetComponent<emptyscript>();
        powernumber = UnityEngine.Random.Range(0.0f,20.0f);
        //Debug.Log("WeaponNum = " + powernumber);
    }

    // Update is called once per frame
    void Update()
    {
        if(master.gameover == 2)
        {
            Destroy(gameObject);
        }
    }

    void OnMouseDown () 
    {
        TransmitPower();
    }
    void TransmitPower()
    {
        if(powernumber < 5.0f)
        {
            master.powertime1 = 10;
            //Debug.Log("Increased powertime");
        }
        else if(powernumber > 5.0f && powernumber < 10.0f)
        {
            master.powertime2 = 10;
        }
        else if(powernumber > 10.0f && powernumber < 15.0f)
        {
            master.powertime3 = 10;
        }
        else if(powernumber > 15.0f && powernumber < 20.0f)
        {
            master.powertime4 = 10;
        }
        else
        {
            Debug.Log("None of the powernumbers matched.");
        }
        Destroy(gameObject);
    }
}
