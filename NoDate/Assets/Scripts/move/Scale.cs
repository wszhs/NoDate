using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scale : MonoBehaviour {

    float time = 0.5f;
    float local = 1.1f;
    Vector3 v;
	// Use this for initialization
	void Start () {
        v = transform.localScale;
        transform.DOScale(v*local,time);
       Invoke("Back",time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Back() {
        transform.DOScale(v, time);
        Invoke("ToScale", time);
    }
    void ToScale() {
        transform.DOScale(v * local, time);
        Invoke("Back", time);
    }
}
