using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class clear_go : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider goal)
    {
        if (goal.CompareTag("Player"))
        {
            Destroy(gameObject);

            SceneManager.LoadScene("Clear");

            Debug.Log("$");
        }
    }
}
