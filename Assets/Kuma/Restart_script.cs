using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_script : MonoBehaviour
{

    public void ButtonPush()
    {
        SceneManager.LoadScene("Scene1");
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            ButtonPush();
        }
    }

}

