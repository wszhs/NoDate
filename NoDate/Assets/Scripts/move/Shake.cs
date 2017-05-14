using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shake : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.DOShakeScale(2.5f,0.5f,2,10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
