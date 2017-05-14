using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testwww : MonoBehaviour {
    public GameObject image;
	// Use this for initialization
	void Start () {
        LoadByWWW();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 以WWW方式进行加载
    /// </summary>
    private void LoadByWWW()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        double startTime = (double)Time.time;
        //请求WWW
        WWW www = new WWW("file://" +Application.streamingAssetsPath +"/1.png");
        //Debug.Log(www!=null);
        yield return www;
        if (www != null && string.IsNullOrEmpty(www.error))
        {
            //获取Texture
            Texture2D texture = www.texture;

            //创建Sprite
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
           image.GetComponent<Image>().sprite = sprite;

            startTime = (double)Time.time - startTime;
            Debug.Log("WWW加载用时:" + startTime);
        }
    }
}
