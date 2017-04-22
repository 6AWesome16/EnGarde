using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class movement : MonoBehaviour {

    public float step = 0.1f;
    public float back = -2.0f;
    public movement otherplayer;
    public bool attacking = false;
    public bool blocking = false;
    public int score = 0;
    public TextMesh scoretext;
    public bool touch = false;
    public bool blocked = false;
    public int playerNumber;
    public Vector3 resetPos;
    public bool flip;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //scoretext.text = "" + score;

        //player 1
        if (playerNumber == 1)
        {
            Vector3 currentpos = transform.position;

            //code meant to flip the sprite, hitbox and animation when you pass another player
            if (this.transform.position.x > otherplayer.transform.position.x && !flip)
            {
                flip = true;
                if (flip)
                {
                    Vector3 theScale = transform.localScale;
                    theScale.x = -1;
                    transform.localScale = theScale;
                }
                //keeps flipping the sprite;
            }
            else if (this.transform.position.x < otherplayer.transform.position.x && flip)
            {
                Vector3 theScale = transform.localScale;
                theScale.x = 1;
                transform.localScale = theScale;
                flip = false;
            }

            if (currentpos.x <= Camera.main.aspect * Camera.main.orthographicSize)
            {
                if (Input.GetKey("s"))
                {
                    //Vector3 currentPos = transform.position;
                    //currentPos.x += 5;
                    //transform.position = currentPos;
                    //transform.position = new Vector3(transform.position.x + step * Time.deltaTime, transform.position.y, transform.position.z);
                    GetComponent<Animator>().SetBool("advancing", true);
                    currentpos.x += step * Time.deltaTime;
                    transform.position = currentpos;
                }
                else 
                {
                    GetComponent<Animator>().SetBool("advancing", false);
                }
            }
            if (currentpos.x >= -Camera.main.aspect * Camera.main.orthographicSize)
            {
                if (Input.GetKey("a"))
                {
                    GetComponent<Animator>().SetBool("retreating", true);
                    currentpos.x -= step * Time.deltaTime;
                    transform.position = currentpos;

                    //transform.position = new Vector3(transform.position.x - step * Time.deltaTime, transform.position.y, transform.position.z);
                }
                else 
                {
                    GetComponent<Animator>().SetBool("retreating", false);
                }
            }

            //attacking mid lo hi
            if (Input.GetKeyDown("d"))
            {
                //   GetComponent<SpriteRenderer>().sprite = lunge;
                GetComponent<Animator>().SetBool("attacking", true);
                attacking = true;
            }
            else if (Input.GetKeyUp("d"))
            {
                // GetComponent<SpriteRenderer>().sprite = engarde;
                GetComponent<Animator>().SetBool("attacking", false);
                attacking = false;
            }
            if (Input.GetKeyDown("c"))
            {
                GetComponent<Animator>().SetBool("cross", true);
                attacking = true;
            }
            else if (Input.GetKeyUp("c"))
            {
                GetComponent<Animator>().SetBool("cross", false);
                attacking = false;
            }
            //if (Input.GetKeyDown("e"))
            //{
            //    GetComponent<Animator>().SetBool("attackhi", true);
            //    attacking = true;
            //}
            //else if (Input.GetKeyUp("e"))
            //{
            //    GetComponent<Animator>().SetBool("attackhi", false);
            //    attacking = false;
            //}

            //blocking
            //if (Input.GetKeyDown("w"))
            //{
            //    GetComponent<Animator>().SetBool("blocking", true);
            //    blocking = true;
            //}
            //else if (Input.GetKeyUp("w"))
            //{
            //    GetComponent<Animator>().SetBool("blocking", false);
            //    blocking = false;
            //}


        }

        //player2
        else if (playerNumber == 2)
        {
            //code meant to flip sprite and hitbox when you pass the other player
            //if (this.transform.position.x < otherplayer.transform.position.x)
            //{
            //    GetComponent<SpriteRenderer>().flipX = false;
            //}
            //code meant to flip the sprite, hitbox and animation when you pass another player
            if (this.transform.position.x < otherplayer.transform.position.x && !flip)
            {
                flip = true;
                if (flip)
                {
                    Vector3 theScale = transform.localScale;
                    theScale.x = -1;
                    transform.localScale = theScale;
                }
                //keeps flipping the sprite;
            }
            else if (this.transform.position.x > otherplayer.transform.position.x && flip)
            {
                Vector3 theScale = transform.localScale;
                theScale.x = 1;
                transform.localScale = theScale;
                flip = false;
            }
            Vector3 currentpos = transform.position;

            if (currentpos.x >= -Camera.main.aspect * Camera.main.orthographicSize)
            {
                if (Input.GetKey("k"))
                {
                    GetComponent<Animator>().SetBool("advancing", true);
                    currentpos.x -= step * Time.deltaTime;
                    transform.position = currentpos;
                    //transform.position = new Vector3(transform.position.x - step * Time.deltaTime, transform.position.y, transform.position.z);
                }
                else
                {
                    GetComponent<Animator>().SetBool("advancing", false);
                }
            }
            if (currentpos.x <= Camera.main.aspect * Camera.main.orthographicSize)
            {
                if (Input.GetKey("l"))
                {
                    GetComponent<Animator>().SetBool("retreating", true);
                    currentpos.x += step * Time.deltaTime;
                    transform.position = currentpos;
                    //transform.position = new Vector3(transform.position.x + step * Time.deltaTime, transform.position.y, transform.position.z);
                }
                else
                {
                    GetComponent<Animator>().SetBool("retreating", false);
                }
                     
            }
            //attacking, mid lo hi
            if (Input.GetKeyDown("j"))
            {
                //GetComponent<SpriteRenderer>().sprite = lunge;
                GetComponent<Animator>().SetBool("attacking", true);
                attacking = true;
            }
            else if (Input.GetKeyUp("j"))
            {
                //GetComponent<SpriteRenderer>().sprite = engarde;
                GetComponent<Animator>().SetBool("attacking", false);
                attacking = false;
            }
            if (Input.GetKeyDown("n"))
            {
                GetComponent<Animator>().SetBool("cross", true);
                attacking = true;
            }
            else if (Input.GetKeyUp("n"))
            {
                GetComponent<Animator>().SetBool("cross", false);
                attacking = false;
            }
            //if (Input.GetKeyDown("u"))
            //{
            //    GetComponent<Animator>().SetBool("attackhi", true);
            //    attacking = true;
            //}
            //else if (Input.GetKeyUp("u"))
            //{
            //    GetComponent<Animator>().SetBool("attackhi", false);
            //    attacking = false;
            //}
            //blocking
            //if (Input.GetKeyDown("i"))
            //{
            //    GetComponent<Animator>().SetBool("blocking", true);
            //    blocking = true;
            //}
            //else if (Input.GetKeyUp("i"))
            //{
            //    GetComponent<Animator>().SetBool("blocking", false);
            //    blocking = false;
            //}


        }
    }
    void OnTriggerEnter2D(Collider2D collisioninfo)
    {
        if (collisioninfo.gameObject.name == "blade")
        {
            //if blade overlaps with player hitbox
            if (otherplayer.attacking && this.blocking)
            {
                //if attacking and you are blocking
                Debug.Log("heyyy");
                blocked = true;
                if (blocked)
                {
                    GetComponent<Animator>().SetBool("attacking", false);
                    if (this.transform.position.x > otherplayer.transform.position.x)
                    {
                        otherplayer.transform.position = new Vector3(otherplayer.transform.position.x + back * Time.deltaTime, otherplayer.transform.position.y, otherplayer.transform.position.z);
                    }
                    else if (this.transform.position.x < otherplayer.transform.position.x)
                    {
                        otherplayer.transform.position = new Vector3(otherplayer.transform.position.x - back * Time.deltaTime, otherplayer.transform.position.y, otherplayer.transform.position.z);
                    }
                    blocked = false;
                }
            }

            //where touch is altered
            if (otherplayer.attacking && !this.blocking)
            {
                touch = true;
                if (touch)
                {
                        //transform.position = resetPos;
                        //otherplayer.transform.position = otherplayer.resetPos;
                        //Vector3 theScale = transform.localScale;
                        //theScale.x = 1;
                        //transform.localScale = theScale;
                        //otherplayer.transform.localScale = theScale;
                        flip = false;
                    }
                }
            }

        }
    }
