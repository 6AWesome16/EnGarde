using UnityEngine;
using System.Collections;

public class blade : MonoBehaviour
{
    public movement otherplayer;
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
            if (GetComponentInParent<Animator>().GetBool("attacking") || !GetComponentInParent<Animator>().GetBool("cross"))
            {
                Debug.Log("ting!");
                if(otherplayer.GetComponentInParent<Animator>().GetBool("cross"))
                {
                    GetComponentInParent<Animator>().SetBool("block", true);
                }
            }
            if (this.GetComponentInParent<Animator>().GetBool("attacking") && otherplayer.GetComponentInParent<Animator>().GetBool("attacking") ||
                this.GetComponentInParent<Animator>().GetBool("cross") && otherplayer.GetComponentInParent<Animator>().GetBool("cross"))
            {
                Debug.Log("blocked!");
                GetComponentInParent<Animator>().SetBool("block", true);
                otherplayer.GetComponentInParent<Animator>().SetBool("block", true);
                GetComponentInParent<Animator>().SetBool("attacking", false);
                otherplayer.GetComponentInParent<Animator>().SetBool("attacking", false);
                GetComponentInParent<Animator>().SetBool("cross", false);
                otherplayer.GetComponentInParent<Animator>().SetBool("cross", false);
                //if j and d pressed, both are blocked
                //if j and c pressed on overlap, j is blocked
                //if d and n pressed on overlap, d is blocked
                //if attacking == true send to blocked animation
            }
        }
    }
}
