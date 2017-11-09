using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryImage : MonoBehaviour
{

    [SerializeField]
    Player_control playerControl;
    [SerializeField]
    Image batteryImage;

    void Update()
    {
        batteryImage.fillAmount = playerControl.LightTimer / playerControl.MaxLightTime;
    }

}
