using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class startscreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("hbrrbr");
            SceneManager.LoadScene("En Garde");
        }
	}
}
