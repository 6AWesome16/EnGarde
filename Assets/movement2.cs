using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movement2 : MonoBehaviour {

    float step = 0.5f;
    public movement otherplayer;
    public bool attacking = false;
    public int score = 0;
    public Text scoretext;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        scoretext.text = "points:" + score;

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
    }
    void OnTriggerEnter2D(Collider2D collisioninfo)
    {
        //Debug.Log("hiii");

        if (collisioninfo.gameObject.name == "blade")
        {
            if (otherplayer.attacking)

            {
                Debug.Log("hiii");
                otherplayer.score++;
            }
        }  
    }
}
