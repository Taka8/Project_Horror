using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_gold : MonoBehaviour
{
    public GameObject door;

    void Start()
    {

    }

    // トリガーとの接触時に呼ばれるコールバック
    void OnTriggerEnter(Collider hit)
    {
        //接触対象はPlayerタグですか?
        if (hit.CompareTag("Player"))
        {
            //このコンポーネントを持つGameObjectを破棄し、ドアを破壊
            Destroy(gameObject);
            Destroy(door);
        }
    }
}
