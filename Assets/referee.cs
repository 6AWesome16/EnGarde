using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class referee : MonoBehaviour {
    public movement fencer1;
    public movement fencer2;
    public bool p1row;
    public bool p2row;
    public Sprite newpos;
    public Sprite newposflip;
    public Sprite startpos;
	// Use this for initialization
	void Start () {
	
	}
    IEnumerator waitThree()
    {
        Debug.Log(Time.time);
        float timeinit = Time.time;
        yield return new WaitForSecondsRealtime(3);
        float timeend = Time.time + 3;
        //uhhhhh i dont know how to tackle these numbers here
        Debug.Log(Time.time);
    }
    // Update is called once per frame
    void Update () {

	// if the player moved forward first, they get right of way.check!
    //if point scored, point in the direction of the player who scored.check!
    //if playernumber==1 && row == true && attacking == true--->pointscored.check!
    //if playernumber==2 && row == true && attacking == true--->pointscored.check!
    //if playernumber==1 &&row ==false && attacking == true--->pointscored.check!
    //if playernumber==2 && row == false && attacking == true---> pointscored.check!
    //blocking would just switch right of way****
    //if row == true && attacking == true, but hitboxes don't overlap, row switches****
    //when d or j is first pressed, row becomes true for that specific player. check!
    //when a or l are pressed right of way is ceded.check. if row == true, a or l pressed--->row switches.check!
    if(p1row)
        {
            GetComponent<SpriteRenderer>().sprite = newposflip;        
        }
    else if(p2row)
        {
            GetComponent<SpriteRenderer>().sprite = newpos;
        }
    else
        {
            GetComponent<SpriteRenderer>().sprite = startpos;
        }
    if(Input.GetKeyDown("d") && !p1row && !p2row)
        {
            p1row = true;
            p2row = false;
        }
    else if(Input.GetKeyDown("d") && p2row)
        {
            p1row = false;
            p2row = true;
        }
    //ensures right of way stays with the one who moved first for p2
    if(Input.GetKeyDown("j") && !p1row && !p2row)
        {
            p1row = false;
            p2row = true;
        }
    //"!" is meant to make it so that this only works at the first step
    else if(Input.GetKeyDown("j") && p1row)
        {
            p1row = true;
            p2row = false;
        }
    //ensures right of way stays with the one who moved first for p1
     if (Input.GetKeyDown("a"))
        {
            p1row = false;
            p2row = true;
        }
     if (Input.GetKeyDown("l"))
        {
            p1row = true;
            p2row = false;
        }
     //attacks, basic   
     if(p1row && fencer1.attacking && fencer2.touch)
        {
            fencer2.otherplayer.score++;
            p1row = false;
            p2row = false;
        }
        //counterattacks.check!
        else if (!p1row && fencer1.attacking && fencer2.touch)
        {
            fencer2.otherplayer.score++;
        }

        if (p2row && fencer2.attacking && fencer1.touch)
        {
            fencer1.otherplayer.score++;
            p2row = false;
            p1row = false;
        }
        //counterattacks.check!
        else if (!p2row && fencer2.attacking && fencer1.touch)
        {
            fencer1.otherplayer.score++;
        }

        //throwing away an attack 
        //also accounts for blocking
        if (p1row && fencer1.attacking && fencer2.touch == false)
        {
            p1row = false;
            p2row = true;
        }
        if(p2row && fencer2.attacking && fencer1.touch == false)
        {
            p1row = true;
            p2row = false;
        }
        //detect distance between fencers and slow down time when attacking
        //striking distance is 2.0 on the X axis
        if (fencer1.transform.position.x - fencer2.transform.position.x <= 0.5f)
        {
            if (fencer2.attacking || fencer1.attacking)
            {//wait three seconds in realtime

                Debug.Log("fairy");
                Time.timeScale = 0.1f;
                //StartCoroutine(waitThree());
                Time.fixedDeltaTime = 0.5f;

            }

            else
            {
                Time.timeScale = 1.0f;
            }
        }


            //resets.check!
            if (fencer1.attacking || fencer2.attacking)
        {
          if(fencer1.touch || fencer2.touch)
            {
                p1row = false;
                p2row = false;
                fencer1.touch = false;
                fencer2.touch = false;                
            }
        }
        //all these numbers are confusing. fix that
    }
}

