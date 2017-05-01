using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class movement : MonoBehaviour {

    public float step = 0.1f;
    public float back = -2.0f;
    public movement otherplayer;
    public bool attacking = false;
    public int score = 0;
    public TextMesh scoretext;
    public bool touch = false;
    public bool blocked = false;
    public int playerNumber;
    public Vector3 resetPos;
    public bool flip;
    public float knocktime;
    public float knockpow;
    public float knockacc;
    public ParticleSystem flipper;
    public AudioSource flippette;

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
                if (Input.GetKey("s") && attacking == false)
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
                if (Input.GetKey("a") && attacking == false)
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


            //blocking
            //if(playernumber == 1 && Input.getkeydown(attack) && playernumber ==2 && input.getkeydown(attack)) yeah this wouldnt work
            //or maybe
            //put it in the blade
            //if blade overlap, and both have attacking as true, send to block 

            if (GetComponent<Animator>().GetBool("block"))
            {
                if(knocktime > 0)
                {
                    if (flip)
                    {
                        currentpos.x = transform.position.x + knockpow * knockacc * knocktime * Time.deltaTime;
                        transform.position = currentpos;
                        knocktime -= Time.deltaTime;
                    }
                    else
                    {
                        currentpos.x = transform.position.x - knockpow * knockacc *knocktime * Time.deltaTime;
                        transform.position = currentpos;
                        knocktime -= Time.deltaTime;
                    }
                }
                else if(knocktime <= 0)
                {
                    GetComponent<Animator>().SetBool("block", false);
                    knocktime = .25f;
                }
            }
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
                    flipper.Play();
                    flippette.Play();
                    Vector3 theScale = transform.localScale;
                    theScale.x = -1;
                    transform.localScale = theScale;
                }
                //keeps flipping the sprite;
            }
            else if (this.transform.position.x > otherplayer.transform.position.x && flip)
            {
                flipper.Play();
                flippette.Play();
                Vector3 theScale = transform.localScale;
                theScale.x = 1;
                transform.localScale = theScale;
                flip = false;
            }
            Vector3 currentpos = transform.position;

            if (currentpos.x >= -Camera.main.aspect * Camera.main.orthographicSize)
            {
                if (Input.GetKey("k") && attacking == false)
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
                if (Input.GetKey("l") && attacking == false)
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

            //blocking
 
            if (GetComponent<Animator>().GetBool("block"))
            {
                if (knocktime > 0)
                {
                    if (flip)
                    {
                        currentpos.x = transform.position.x - knockpow * knockacc * knocktime * Time.deltaTime;
                        transform.position = currentpos;
                        knocktime -= Time.deltaTime;
                    }
                    else
                    {
                        currentpos.x = transform.position.x + knockpow * knockacc * knocktime * Time.deltaTime;
                        transform.position = currentpos;
                        knocktime -= Time.deltaTime;
                    }

                }
                else if (knocktime <= 0)
                {
                    GetComponent<Animator>().SetBool("block", false);
                    knocktime = .25f;
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collisioninfo)
    {
        if (collisioninfo.gameObject.name == "blade")
        {
            //if blade overlaps with player hitbox

            //where touch is altered
            if (otherplayer.attacking)
            {
                touch = true;
                if (touch)
                {
                        flip = false;
                    }
                }
            }
        }
    }
