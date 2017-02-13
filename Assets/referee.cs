using UnityEngine;
using System.Collections;

public class referee : MonoBehaviour {
    public movement fencers;
    public bool p1row;
    public bool p2row;
    //bool true for one player but false for the other

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	// if the player moved forward first, they get right of way.
    //if point scored, point in the direction of the player who scored
    //if playernumber==1 && row == true && attacking == true--->pointscored
    //if playernumber==2 && row == true && attacking == true--->pointscored
    //if playernumber==1 &&row ==false
    //blocking would just switch right of way
    //if row == true && attacking == true, but hitboxes don't overlap, row switches
    //when d or j is first pressed, row becomes true for that specific player
    //when a or l are pressed right of way is ceded. if row == true, a or l pressed--->row switches
    if(Input.GetKeyDown("d") && !p1row && !p2row)
        {
            p1row = true;
            p2row = false;
        }
    else if(Input.GetKeyDown("d") && p2row)
        {
            p1row = false;
            p2row = true;
        }
    //ensures right of way stays with the one who moved first for p2
    if(Input.GetKeyDown("j") && !p1row && !p2row)
        {
            p1row = false;
            p2row = true;
        }
    //"!" is meant to make it so that this only works at the first step
    else if(Input.GetKeyDown("j") && p1row)
        {
            p1row = true;
            p2row = false;
        }
    //ensures right of way stays with the one who moved first for p1
     if (Input.GetKeyDown("a"))
        {
            p1row = false;
            p2row = true;
        }
     if (Input.GetKeyDown("l"))
        {
            p1row = true;
            p2row = false;
        }

     //this almost works, but both players are sharing right of way, when one retreats row is false
     //two rows? or do I need to detect both players?
	}
}
