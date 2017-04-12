using UnityEngine;
using System.Collections;

public class scoremovement : MonoBehaviour {
    public float step = 0.1f;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 currentpos = transform.position;
        if (currentpos.x <= Camera.main.aspect * Camera.main.orthographicSize)
        {
            if (Input.GetKeyDown("s"))
            {
                currentpos.x += step * Time.deltaTime;
                transform.position = currentpos;
            }
            if (Input.GetKeyDown("a"))
            {
                currentpos.x -= step * Time.deltaTime;
                transform.position = currentpos;
            }
        }
    }
}
