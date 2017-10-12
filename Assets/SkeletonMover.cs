using UnityEngine;
using System.Collections;

public class SkeletonMover : MonoBehaviour
{

    public float chaseDistance = 5f;

    [SerializeField]
    Transform target;

    [SerializeField]
    UnityEngine.AI.NavMeshAgent nav;

    [SerializeField]
    State myState;

    private float timeleft;



    enum State
    {
        Wait,
        Chase
    }

    void Update()
    {

        switch (myState)
        {
            case State.Wait:

                if ((transform.position - target.position).sqrMagnitude < Mathf.Pow(chaseDistance, 2))
                {
                    myState = State.Chase;
                }


                break;

            case State.Chase:

                if ((transform.position - target.position).sqrMagnitude > Mathf.Pow(chaseDistance, 2))
                {
                    myState = State.Wait;
                    nav.ResetPath();//
                }

                //だいたい2秒ごとに処理を行う
                timeleft -= Time.deltaTime;

                if (timeleft <= 0.0)
                {
                    timeleft = 2.0f;

                    //ここに処理
                    Debug.Log("!");
                    nav.destination = target.position;  // 2秒に1回呼ばれるようにしたい
                }


                nav.Move(nav.nextPosition - transform.position);

                break;

            default:
                break;
        }
    }

    void ChangeState(State state)
    {

    }

    private void OnGUI()
    {
        GUILayout.Label("Destination" + nav.destination.ToString());
    }

}
