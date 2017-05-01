using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class instru : MonoBehaviour {
    public GameObject bluu;
    public GameObject reed;
    public AudioSource bloop;
	// Use this for initialization
	void Start () {
        reed.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("b"))
        {
            bloop.Play();
            reed.SetActive(false);
            bluu.SetActive(true);
        }
        if(Input.GetKey("r"))
        {
            bloop.Play();
            reed.SetActive(true);
            bluu.SetActive(false);
        }
	if(Input.GetKeyUp(KeyCode.Space))
        {
            SceneManager.LoadScene("En Garde");
        }
	}
}
