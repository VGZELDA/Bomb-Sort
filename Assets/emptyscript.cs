using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 using UnityEngine.SceneManagement;


public class emptyscript : MonoBehaviour
{
    public GameObject myPrefabred;
    public GameObject myPrefabblue;
    public GameObject powerup;
    public int framecount;
    private float bombcolor;
    private float bombpos;
    public int ScoreCount;
    public TextMeshProUGUI scoretext;
    public int bluecount;
    public int redcount;
    public int undefused;
    public int gameover;

    public int powertime1 = 0;
    public int powertime2 = 0;
    public int powertime3 = 0;
    public int powertime4 = 0;

    public float speedmultiplier;
    public float gravitymultiplier;
    public float sizemultiplier;

    private float timer = 0.0f;

    public int started = 0;
    // Start is called before the first frame update
    void Start()
    {
        framecount = 0;
        ScoreCount = 0;
        bluecount = 0;
        redcount = 0;
        undefused = 0;
        gameover = 0;

        InvokeRepeating("decreasePowerTime", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    { if(started == 1) {   
        if(undefused >= 10)
        {
            gameover = 2;
        }
        if(gameover != 0)
        {
            timer += Time.deltaTime;
            if(timer >= 3.0f)
            {
                Vector3 position = transform.position;
                position.z = -2.0f;
                transform.position = position;

                scoretext.fontSize = 50.0f;

            }
        }
        powerEffect();        
        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        framecount=framecount+1;
        if(framecount%450==0 && gameover == 0) // Every 450 frames, a new bomb appears.
        {
            framecount=redcount+bluecount; //Increase frequency of bombs as score increases. 
            framecount = (framecount-framecount%3)/3;
            // Random Color
            bombcolor=UnityEngine.Random.Range(0.0f,1.0f);
            // Random Location
            bombpos=UnityEngine.Random.Range(0.0f,1.0f);
            //Increment undefused count
            undefused++;
            if(bombcolor<=0.5)
            {
            if(bombpos<=0.5){
            Instantiate(myPrefabred, new Vector3(0, 4.16f, 0), Quaternion.identity);}
            else{
            Instantiate(myPrefabred, new Vector3(0, -4.16f, 0), Quaternion.identity);}
            }
            else
            {
            if(bombpos<=0.5){
            Instantiate(myPrefabblue, new Vector3(0, 4.16f, 0), Quaternion.identity);}
            else{
            Instantiate(myPrefabblue, new Vector3(0, -4.16f, 0), Quaternion.identity);}        
            }
        }
        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

        // Display the score on the TextMesh
        ScoreCount = redcount + bluecount;
        SetScore();

        float chance = UnityEngine.Random.Range(0f,1f);
        if(chance < .00046815 && gameover == 0)
        {
            generatePower();
        }

    }}
    void SetScore()
    {
        scoretext.text = "Score: " + ScoreCount.ToString();
    }
    void generatePower()
    {
        float x;
        float y;

        x = UnityEngine.Random.Range(-4.3f,4.3f);
        y = UnityEngine.Random.Range(-4f,4f);

        Instantiate(powerup, new Vector3(x, y, -1), Quaternion.identity);
    }

    void decreasePowerTime()
    {
        if(powertime1 > 0) 
        {
            powertime1 -= 1;
        }
        if(powertime2 > 0) 
        {
            powertime2 -= 1;
        }
        if(powertime3 > 0) 
        {
            powertime3 -= 1;
        }
        if(powertime4 > 0) 
        {
            powertime4 -= 1;
        }
    }
    void powerEffect()
    {
        if(powertime1 == 0)
        {
            speedmultiplier = 1.0f;
        }
        else
        {   
            //Debug.Log("Here to multiply.");
            speedmultiplier = 2.0f;
        }
        if(powertime2 == 0)
        {
            speedmultiplier = 1.0f;
        }
        else
        {
            speedmultiplier = 0.5f;
        }
        if(powertime3 == 0)
        {
            sizemultiplier = 1f;
        }
        else
        {
            sizemultiplier = .5f;
        }
        if(powertime4 == 0)
        {
            gravitymultiplier = 0f;
        }
        else
        {
            gravitymultiplier = 1f;
        }
    }
    void OnMouseDown()
    {
         SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }
}
