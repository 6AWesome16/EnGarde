using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movement : MonoBehaviour {

    float step = .5f;
    public movement otherplayer;
    public bool attacking = false;
    public bool blocking = false;
    public int score = 0;
    public Text scoretext;
    public bool touch = false;
    public bool blocked = false;
    public int playerNumber;
    public Vector3 resetPos;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        scoretext.text = "points:" + score;
        if (playerNumber == 1)
        {
            //if(transform.position <= camera.main.aspect * camera.main.orthographicsize)
            if (Input.GetKeyDown("d"))
            {
                //Vector3 currentPos = transform.position;
                //currentPos.x += 5;
                //transform.position = currentPos;

                transform.position = new Vector3(transform.position.x + step, transform.position.y, transform.position.z);
            }
            if (Input.GetKeyDown("a"))
            {
                transform.position = new Vector3(transform.position.x - step, transform.position.y, transform.position.z);
            }
            if (Input.GetKeyDown("s"))
            {
                //   GetComponent<SpriteRenderer>().sprite = lunge;
                GetComponent<Animator>().SetBool("attacking", true);
                attacking = true;
            }
            else if (Input.GetKeyUp("s"))
            {
                // GetComponent<SpriteRenderer>().sprite = engarde;
                GetComponent<Animator>().SetBool("attacking", false);
                attacking = false;
            }
            if(Input.GetKeyDown("w"))
            {
                GetComponent<Animator>().SetBool("blocking", true);
                blocking = true;
            }
            else if(Input.GetKeyUp("w"))
            {
                GetComponent<Animator>().SetBool("blocking", false);
                blocking = false;
            }
            if (attacking == false && score > 4)
            {
                score = 0;
                otherplayer.score = 0;
            }
        }
        else if(playerNumber == 2)
        {

            if (Input.GetKeyDown("j"))
            {
                transform.position = new Vector3(transform.position.x - step, transform.position.y, transform.position.z);
            }
            if (Input.GetKeyDown("l"))
            {
                transform.position = new Vector3(transform.position.x + step, transform.position.y, transform.position.z);
            }

            if (Input.GetKeyDown("k"))
            {
                //GetComponent<SpriteRenderer>().sprite = lunge;
                GetComponent<Animator>().SetBool("attacking", true);
                attacking = true;
            }
            else if (Input.GetKeyUp("k"))
            {
                //GetComponent<SpriteRenderer>().sprite = engarde;
                GetComponent<Animator>().SetBool("attacking", false);
                attacking = false;
            }
            if(Input.GetKeyDown("i"))
            {
                GetComponent<Animator>().SetBool("blocking", true);
                blocking = true;
            }
            else if(Input.GetKeyUp("i"))
            {
                GetComponent<Animator>().SetBool("blocking", false);
                blocking = false;
            }
            if ( score > 4)
            {
                score = 0;
                otherplayer.score = 0;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collisioninfo)
    {
        //Debug.Log("hiii");
        if (collisioninfo.gameObject.name == "blade")
        {
            if (otherplayer.attacking)
            {
                Debug.Log("hiii");
                //otherplayer.score++;
                touch = true;
                if (touch)
                {
                    transform.position = resetPos;
                    otherplayer.transform.position = otherplayer.resetPos;
                }
            }
            if(otherplayer.blocking)
            {
                Debug.Log("heyyy");
                blocked = true;
                if(blocked)
                {
                    GetComponent<Animator>().SetBool("attacking", false);
                }
            }
        }
    }
}
