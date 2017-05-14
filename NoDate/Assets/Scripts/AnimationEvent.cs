using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour {
    private Object blood_object;
    private GameObject object_animation;
    public static int ANIM_NUMBER;
    // Use this for initialization
    void Start () {
        blood_object = Resources.Load("Prefabs/globel/Blood");
    }
	
	// Update is called once per frame
	void Update () {
        switch (ANIM_NUMBER) {
            //产生血流
            case 1:
                object_animation = Instantiate(blood_object, null) as GameObject;
                object_animation.transform.parent = GameObject.Find("Story(Clone)").transform;
                ANIM_NUMBER = 0;
                break;
            //黑屏
            case 2:
                transform.FindChild("Black").gameObject.SendMessage("ChangeBlackEvent", true, SendMessageOptions.DontRequireReceiver);
                ANIM_NUMBER = 0;
                break;
            //屏幕震动
            case 3:
                transform.FindChild("Bcg").FindChild("bcg").gameObject.SendMessage("ShakeEvent",true, SendMessageOptions.DontRequireReceiver);
                ANIM_NUMBER = 0;
                break;
                //屏幕震动变黑
            case 4:
                transform.FindChild("Black").gameObject.SendMessage("ChangeBlackEvent", true, SendMessageOptions.DontRequireReceiver);
                transform.FindChild("Bcg").FindChild("bcg").gameObject.SendMessage("ShakeEvent", true, SendMessageOptions.DontRequireReceiver);
                ANIM_NUMBER = 0;
                break;
         
        } 
    }
}
