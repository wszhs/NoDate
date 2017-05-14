using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animationpaint : MonoBehaviour {

    public static int number;
    public GameObject[] gameobject;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //产生立绘
    public void CreatePaint(int num) {
        gameobject[num].SetActive(true);
        gameobject[num].SendMessage("Act_anim", true, SendMessageOptions.DontRequireReceiver);
        StartCoroutine(Animationopen(num));
    }
    //销毁立绘
    public void DestroyPaint(int num) {
        gameobject[num].SendMessage("Back_anim", true, SendMessageOptions.DontRequireReceiver);
        gameobject[num].SendMessage("StartTea", true, SendMessageOptions.DontRequireReceiver);
        gameobject[num].SetActive(false);
    }

    IEnumerator Animationopen(int number) {
        yield return new WaitForSeconds(0.5f);
        gameobject[number].SendMessage("MoveTea", true, SendMessageOptions.DontRequireReceiver);
    }
}
