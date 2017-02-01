using UnityEngine;
using System.Collections;

public class movement2 : MonoBehaviour {

    float step = 0.5f;
    public Sprite lunge;
    public Sprite engarde;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
        }
        else if (Input.GetKeyUp("k"))
        {
            GetComponent<SpriteRenderer>().sprite = engarde;
            GetComponent<Animator>().SetBool("attacking", false);
        }
    }
}
