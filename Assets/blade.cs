using UnityEngine;
using System.Collections;

public class blade : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collisioninfo)
    {
        if (collisioninfo.gameObject.name == "blade")
        {
            if (GetComponentInParent<Animator>().GetBool("attacking"))
            {
                Debug.Log("ting!");
                
                //if attacking == true send to blocked animation
            }
        }
    }
}
