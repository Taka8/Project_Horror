using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_control : MonoBehaviour
{

    private CharacterController charaCon;       // キャラクターコンポーネント用の変数
    
    private Vector3 move = Vector3.zero;    // キャラ移動量.
    private float speed = 5.0f;         // 移動速度
    private float jumpPower = 1.0f;        // 跳躍力.
    private const float GRAVITY = 9.8f;         // 重力
    private float rotationSpeed = 180.0f;   // プレイヤーの回転速度
    [SerializeField]
    private float maxLightTime = 60;
    private float lightTimer;

    GameObject spotLight;
    bool lightEnable = true;

    public float LightTimer { get { return lightTimer; } }

    public float MaxLightTime { get { return maxLightTime; } }

    // Use this for initialization
    void Start()
    {
        charaCon = GetComponent<CharacterController>();
        
        spotLight = transform.Find("Spotlight").gameObject;

        lightTimer = maxLightTime;

    }

    // Update is called once per frame
    void Update()
    {
        playerMove_1rdParson();
        lightControl();
    }

    private void lightControl()
    {
        // キーボード”Control”でライトをオン・オフ切り替え
        if (Input.GetButtonDown("Light"))
        {
            lightEnable = !lightEnable;
            spotLight.GetComponent<Light>().enabled = lightEnable;
        }

        if (lightEnable == true)
        {
            //1秒に1ずつ減らしていく
            lightTimer -= Time.deltaTime;
            //マイナスは表示しない
            if (lightTimer < 0) lightTimer = 0;
        }
        if (lightTimer == 0)
        {
            transform.Find("Spotlight").gameObject.SetActive(false);
        }
        if (lightTimer > 0)
        {
            transform.Find("Spotlight").gameObject.SetActive(true); 
        }

    }

    // ■■■１人称視点の移動■■■
    private void playerMove_1rdParson()
    {
        // ▼▼▼移動量の取得▼▼▼
        float y = move.y;
        move = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));      // 上下のキー入力を取得し、移動量に代入.

        

        move = transform.TransformDirection(move);                          // プレイヤー基準の移動方向へ修正する.
        move *= speed;              // 移動速度を乗算.

        // ▼▼▼重力／ジャンプ処理▼▼▼
        move.y += y;

        move.y -= GRAVITY * Time.deltaTime; // 重力を代入.

        // ▼▼▼プレイヤーの向き変更▼▼▼
        Vector3 playerDir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);       // 左右のキー入力を取得し、移動方向に代入.
        playerDir = transform.TransformDirection(playerDir);                    // プレイヤー基準の向きたい方向へ修正する.
        if (playerDir.magnitude > 0.1f)
        {
            Quaternion q = Quaternion.LookRotation(playerDir);          // 向きたい方角をQuaternionn型に直す .
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, rotationSpeed * Time.deltaTime);   // 向きを q に向けてじわ～っと変化させる.
        }

        // ▼▼▼移動処理▼▼▼
        charaCon.Move(move * Time.deltaTime);   // プレイヤー移動.
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SkeletonMover>())
        {
            SceneManager.LoadScene("Over");
        }
    }

    
    public void charge() {
        lightTimer = lightTimer + 20;
    }
}
