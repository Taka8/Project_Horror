using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class New_game_script : MonoBehaviour {

    public void ButtonPush()
    {
        SceneManager.LoadScene("Scene1");
    }
   
 
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Submit"))
        {
            ButtonPush();
        }
    }
}
