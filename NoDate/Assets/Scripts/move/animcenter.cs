﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class animcenter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Act_anim()
    {
        transform.DOLocalMove(new Vector3(0, 2.0f, 0), 0.8f).SetEase(Ease.OutBack);
    }
    public void Back_anim()
    {
        transform.localPosition = new Vector3(12.0f, 2.0f, 0.0f);
    }
}
