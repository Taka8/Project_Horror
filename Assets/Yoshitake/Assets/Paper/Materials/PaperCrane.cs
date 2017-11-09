using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperCrane : MonoBehaviour
{
    public GameObject Enemy;

    // トリガーとの接触時に呼ばれるコールバック
    void OnTriggerEnter(Collider hit)
    {

        //接触対象はPlayerタグですか?
        if (hit.CompareTag("Player"))
        {
            //このコンポーネントを持つGameObjectを破棄する
            Destroy(gameObject);

            //Enemyを非表示
            Enemy.SetActive(false);

            Debug.Log("hello");
        }

    }
}
