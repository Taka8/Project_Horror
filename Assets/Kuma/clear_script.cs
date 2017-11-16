using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clear_script : MonoBehaviour
{

    public void ButtonPush()
    {
        SceneManager.LoadScene("Start");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Submit"))
        {
            ButtonPush();
        }
    }
}
