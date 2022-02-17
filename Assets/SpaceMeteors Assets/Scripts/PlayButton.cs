using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayButton : MonoBehaviour {
   
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Application.Quit();
            Debug.Log("Quit Game");
        }

    }
}
