using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery_Control : MonoBehaviour
{

    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider hit)
    {

        //接触対象はPlayerタグですか?
        if (hit.CompareTag("Player"))
        {
            //このコンポーネントを持つGameObjectを破棄する
            Destroy(gameObject);

            Player_control player = FindObjectOfType<Player_control>();
            player.charge();
        }
    }
}