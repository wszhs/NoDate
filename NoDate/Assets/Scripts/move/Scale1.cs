using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scale1 : MonoBehaviour {
    float time = 5.0f;
    float local = 1.5f;
    Vector3 v;
    // Use this for initialization
    void Start () {
        v = transform.localScale;
        transform.DOScale(v * local, time); 
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
