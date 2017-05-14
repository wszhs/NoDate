using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeBlack : MonoBehaviour {
    float time = 0;
	// Use this for initialization
	void Start () {

    }

    public void ChangeBlackEvent() {
        StartCoroutine(ChangeToBlack());
    }
    //逐渐黑屏
    IEnumerator ChangeToBlack() {
        yield return new WaitForSeconds(0.5f);
        while (true) {
            if (time >= 255.0f) {
                time = 0;
                GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f,0.0f);
                break;
            }
            time = time + 2;
            GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, time / 255.0f);
            yield return new WaitForSeconds(0.01f);
        }
     
    }
}
