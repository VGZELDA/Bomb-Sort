using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class redbomb : MonoBehaviour
{   
    private float startPosX;
    private float startPosy;
    private bool isbeingheld = false; 
    private float theta = (float) Math.PI;
    private int frame_count = 0;
    public int inbox = 0;
    public float speed = .02f;
    public Animator anim;

    emptyscript master = null;
    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.Find("MasterObject").GetComponent<emptyscript>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   frame_count = frame_count + 1;
        if(inbox == 0 && master.gameover == 2)
        {
            anim.SetFloat("GameOver",1f);
            Destroy(gameObject,3f);
        }
        //Integrating Powers
        if(inbox == 0 && master.gameover != 2)
        {
        //Debug.Log("Here in the inbox.");
        speed = .02f * master.speedmultiplier;
        transform.localScale = new Vector3( master.sizemultiplier*1f, master.sizemultiplier*1f, master.sizemultiplier*1f);
        GetComponent<Rigidbody2D>().gravityScale = master.gravitymultiplier*5f;
        }
        if(inbox == 1)
        {
        speed = .02f;
        transform.localScale = new Vector3(.3f,.3f,.3f);
        GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        }

         //prevents dragging if inbox is true and checks if something exploded in the same box.
        if(inbox == 1)
        {
            isbeingheld = false;
            if(master.gameover != 0)
            {
                speed = 0f;
                if(master.gameover == -1)
                {
                    anim.SetFloat("GameOver",1f);
                    Destroy(gameObject,3f);
                    master.redcount = 0;
                }
            }
        }

        if(master.gameover != 0)
        {
            speed = 0;
            isbeingheld = false;
        }

        //If the bomb is in correct box.
        if(transform.position.x<-6 && transform.position.y<2 && transform.position.y>-2 && inbox==0 && isbeingheld==false)
        {
            transform.localScale = new Vector3( 0.3f, 0.3f, 0.3f);
            master.undefused--;
            inbox=1;

            //Increases count of reds defused
            master.redcount++;
        }
        //If the bomb is in incorrect box.
        if(transform.position.x>6 && transform.position.y<2 && transform.position.y>-2 && inbox==0 && isbeingheld==false)
        {
            master.gameover = 1;
            speed = 0f;
            master.undefused--;
            anim.SetFloat("GameOver",1f);
            transform.localScale = new Vector3( 1.5f, 1.5f, 1.5f);
            Destroy(gameObject,2f);
        }


        // Changes direction every 1.5 secs.
        if(frame_count>=10)
        {
            frame_count = 0;
            theta=UnityEngine.Random.Range(0.0f,360.0f);
        }
        
        Vector2 position = transform.position;
        position.x = position.x + speed*((float)Math.Sin(theta));
        position.y = position.y + speed*((float)Math.Cos(theta));
        transform.position = position;

        if(isbeingheld==true)
        {   
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x,mousePos.y,0);
        }
    }

    private void OnMouseDown()
    {   
        if(Input.GetMouseButtonDown(0)){
        
        isbeingheld=true;
        }
    }
    private void OnMouseUp()
    {
        isbeingheld=false;
    }
}
