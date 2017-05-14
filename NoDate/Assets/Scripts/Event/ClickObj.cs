using UnityEngine;
using System.Collections;

public class ClickObj  {

    private int number;
    public delegate void ClickHandler(int i);   //声明点击委托
    public  event ClickHandler ClickEvent;        //声明点击事件
	// Use this for initialization
	void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void testevent() {
        if (ClickEvent != null)
       {
            ClickEvent(number);
        }
   
    }
}
