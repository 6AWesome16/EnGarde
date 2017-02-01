using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

    float step = .5f;
    public Sprite lunge;
    public Sprite engarde;

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
            GetComponent<SpriteRenderer>().sprite = lunge;
        }
        else if(Input.GetKeyUp("s"))
        {
            GetComponent<SpriteRenderer>().sprite = engarde;
        }
    }
}
