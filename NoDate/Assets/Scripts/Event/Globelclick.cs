using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globelclick : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Clicke clicke = new Clicke();
        ClickObj clickobj = new ClickObj();
        clickobj.ClickEvent += clicke.click_English;
        clickobj.testevent();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
