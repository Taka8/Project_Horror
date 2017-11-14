using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperCrane : MonoBehaviour
{

    [SerializeField]
    float time = 5f;

    private void Update()
    {
        //if (Enemy.activeSelf == false)
        //{
        //    time += Time.deltaTime;
        //    if (time >= 5.0f)
        //    {
        //        time = 0.0f;

        //        Enemy.SetActive(true);

        //    }
        //}
    }

    // トリガーとの接触時に呼ばれるコールバック
    void OnTriggerEnter(Collider hit)
    {

        //接触対象はPlayerタグですか?
        if (hit.CompareTag("Player"))
        {
            //このコンポーネントを持つGameObjectを破棄する
            Destroy(gameObject);

            SkeletonMover[] Enemies = FindObjectsOfType<SkeletonMover>();

            foreach (SkeletonMover e in Enemies)
            {
                e.Disappear(time);
            }

            Debug.Log("hello");
        }

    }
}
