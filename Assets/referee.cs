﻿using UnityEngine;
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
    bool p1point = false;
    bool p2point = false;
    public TextMesh scoretext1;
    public TextMesh scoretext2;
    public int score1 = 0;
    public int score2 = 0;

    float timeUntilStart = 3f;
    float timeUntilReset = 3f;

    int fencingState = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fencingState == 0)
        {
            if (timeUntilStart > 0)
            {
                timeUntilStart -= Time.deltaTime;

                fencer1.enabled = false;
                fencer2.enabled = false;

                fencer1.GetComponent<Animator>().enabled = true;
                fencer2.GetComponent<Animator>().enabled = true;

                fencer1.GetComponent<Animator>().SetBool("attacking", false);
                fencer1.GetComponent<Animator>().SetBool("cross", false);
                fencer1.GetComponent<Animator>().SetBool("advancing", false);
                fencer1.GetComponent<Animator>().SetBool("retreating", false);
                fencer2.GetComponent<Animator>().SetBool("attacking", false);
                fencer2.GetComponent<Animator>().SetBool("cross", false);
                fencer2.GetComponent<Animator>().SetBool("advancing", false);
                fencer2.GetComponent<Animator>().SetBool("retreating", false);


                scoretext1.transform.position = new Vector3(scoretext1.transform.position.x, scoretext1.transform.position.y, -2);
                scoretext2.transform.position = new Vector3(scoretext2.transform.position.x, scoretext2.transform.position.y, -2);
                Debug.Log(Mathf.FloorToInt(timeUntilStart));
                if (timeUntilStart <= 0)
                {
                    fencer1.enabled = true;
                    fencer2.enabled = true;

                    timeUntilReset = 3f;
                    scoretext1.transform.position = new Vector3(scoretext1.transform.position.x, scoretext1.transform.position.y, scoretext1.transform.position.z + 5);
                    scoretext2.transform.position = new Vector3(scoretext2.transform.position.x, scoretext2.transform.position.y, scoretext2.transform.position.z + 5);
                    fencingState = 1;
                }
            }
        }

        AudioSource crowd = GameObject.Find("crowdsounds").GetComponent<AudioSource>();
        if (fencingState == 1)
        {

            if (rowchange)
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
                p1point = true;
                //instance of score
                p1row = false;
                p2row = false;
            }
            //counterattacks.check!
            else if (!p1row && fencer1.attacking && fencer2.touch)
            {
                p1point = true;
                //instance of score
            }

            if (p2row && fencer2.attacking && fencer1.touch)
            {
                p2point = true;
                //instance of score
                p2row = false;
                p1row = false;
            }
            //counterattacks.check!
            else if (!p2row && fencer2.attacking && fencer1.touch)
            {
                p2point = true;
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

            //resets.check!

            if (fencer1.attacking || fencer2.attacking)
            {
                if (fencer1.touch || fencer2.touch)
                {
                    p1row = false;
                    p2row = false;
                    fencer1.touch = false;
                    fencer2.touch = false;
                    fencingState = 2;
                }
            }
        }
                if (fencingState == 2)
                {
                    if (timeUntilReset > 0)
                    {
                        Debug.Log(Mathf.FloorToInt(timeUntilReset));
                scoretext1.text = "" + score1;
                scoretext2.text = "" + score2;

                if (p1point)
                {
                    score1++;
                    scoretext1.transform.position = new Vector3(scoretext1.transform.position.x, scoretext1.transform.position.y, scoretext1.transform.position.z - 5);
                    //fencer1.score++;
                    p1point = false;
                }
                if(p2point)
                {
                    score2++;
                    scoretext2.transform.position = new Vector3(scoretext2.transform.position.x, scoretext2.transform.position.y, scoretext2.transform.position.z - 5);
                    //fencer2.score++;
                    p2point = false;
                }
                        timeUntilReset -= Time.deltaTime;
                        fencer1.enabled = false;
                        fencer2.enabled = false;
                        fencer1.GetComponent<Animator>().enabled = false;
                        fencer2.GetComponent<Animator>().enabled = false;
                        timeUntilStart = 3f;
                        if (timeUntilReset <= 0)
                        {
                            fencer1.enabled = true;
                            fencer2.enabled = true;

                            fencer1.transform.position = fencer1.resetPos;
                            fencer1.otherplayer.transform.position = fencer1.otherplayer.resetPos;
                            Vector3 theScale = transform.localScale;
                            theScale.x = 1;
                            transform.localScale = theScale;
                            fencer1.otherplayer.transform.localScale = theScale;

                            fencer2.transform.position = fencer2.resetPos;
                            fencer2.otherplayer.transform.position = fencer2.otherplayer.resetPos;
                            fencer2.otherplayer.transform.localScale = theScale;

                    if (score2 == 5)
                    {
                        score1 = 0;
                        score2 = 0;
                        SceneManager.LoadScene("Blue Wins");
                    }
                    if (score1 == 5)
                    {
                        score1 = 0;
                        score2 = 0;
                        SceneManager.LoadScene("Red Wins");
                    }
                    fencingState = 0;
                        }
                    }
                }
            }
            //all these numbers are confusing. fix that
        }
    

