using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

    float step = .5f;
    public movement2 otherplayer;
    public bool attacking = false;
    public int score = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	if(Input.GetKeyDown("d"))
        {
            //Vector3 currentPos = transform.position;
            //currentPos.x += 5;
            //transform.position = currentPos;

            transform.position = new Vector3(transform.position.x + step, transform.position.y, transform.position.z);

        }
    if(Input.GetKeyDown("a"))
        {
            transform.position = new Vector3(transform.position.x - step, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown("s"))
        {
         //   GetComponent<SpriteRenderer>().sprite = lunge;
            GetComponent<Animator>().SetBool("attacking", true);
            attacking = true;
        }
        else if(Input.GetKeyUp("s"))
        {
           // GetComponent<SpriteRenderer>().sprite = engarde;
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
