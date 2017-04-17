using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class referee : MonoBehaviour
{
    public movement fencer1;
    public movement fencer2;
    public bool p1row;
    public bool p2row;
    public bool slowdown = false;
    bool rowchange = false;
    public Animator crowd1;
    public Animator crowd2;
    // Use this for initialization
    void Start()
    {

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
    void Update()
    {
        AudioSource crowd = GameObject.Find("crowdsounds").GetComponent<AudioSource>();
        if(rowchange)
        {
            crowd.Play();
            rowchange = false;
        }
        if (p1row)
        {
            crowd1.SetBool("cheer", true);
            crowd2.SetBool("cheer1", false);
        }
        else if (p2row)
        {
            crowd2.SetBool("cheer1", true);
            crowd1.SetBool("cheer", false);
        }
        else
        {
            //Debug.Log("hiii");
            crowd2.SetBool("cheer1", false);
            crowd1.SetBool("cheer", false);

        }

        //switch right of way with direction of motion
        if (Input.GetKeyDown("d") && !p1row && !p2row)
        {
            p1row = true;
            p2row = false;
        }
        else if (Input.GetKeyDown("d") && p2row)
        {
            p1row = false;
            p2row = true;
        }
        //ensures right of way stays with the one who moved first for p2
        //"!" is meant to make it so that this only works at the first step
        if (Input.GetKeyDown("j") && !p1row && !p2row)
        {
            p1row = false;
            p2row = true;
        }
        else if (Input.GetKeyDown("j") && p1row)
        {
            p1row = true;
            p2row = false;
        }
        //ensures right of way stays with the one who moved first for p1
        if (Input.GetKeyDown("a"))
        {
            p1row = false;
            p2row = true;
            rowchange = true;
        }
        if (Input.GetKeyDown("l"))
        {
            p1row = true;
            p2row = false;
            rowchange = true;
        }




        //attacks, basic   
        if (p1row && fencer1.attacking && fencer2.touch)
        {
            fencer2.otherplayer.score++;
            //instance of score
            p1row = false;
            p2row = false;
        }
        //counterattacks.check!
        else if (!p1row && fencer1.attacking && fencer2.touch)
        {
            fencer2.otherplayer.score++;
            //instance of score
        }

        if (p2row && fencer2.attacking && fencer1.touch)
        {
            fencer1.otherplayer.score++;
            //instance of score
            p2row = false;
            p1row = false;
        }
        //counterattacks.check!
        else if (!p2row && fencer2.attacking && fencer1.touch)
        {
            fencer1.otherplayer.score++;
            //instance of score
        }




        //throwing away an attack 
        //also accounts for blocking
        if (p1row && fencer1.attacking && fencer2.touch == false)
        {
            p1row = false;
            p2row = true;
            rowchange = true;
        }
        if (p2row && fencer2.attacking && fencer1.touch == false)
        {
            p1row = true;
            p2row = false;
            rowchange = true;
        }
        //detect distance between fencers and slow down time when attacking
        //striking distance is 2.0 on the X axis

        //if ()
        //{
        //    if (fencer1.attacking || fencer2.attacking)
        //    {//wait three seconds in realtime
        //        Debug.Log("fairy");
        //        Time.timeScale = 0.1f;
        //        slowdown = true;
        //        //StartCoroutine(waitThree());
        //        Time.fixedDeltaTime = 0.5f;
        //    }
        //}

        //else
        //{
        //    Time.timeScale = 1.0f;
        //    slowdown = false;
        //}


        //resets.check!
        if (fencer1.attacking || fencer2.attacking)
        {
            if (fencer1.touch || fencer2.touch)
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

