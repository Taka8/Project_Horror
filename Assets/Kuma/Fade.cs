using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fade : MonoBehaviour {
    public Image image;
	// Use this for initialization
	void Start () {
        image.color = Color.white;
        image.DOFade(0, 3);
	}
	
	// Update is called once per frame
	void Update () {
       
	}
}
