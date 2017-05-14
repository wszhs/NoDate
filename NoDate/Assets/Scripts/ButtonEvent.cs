using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonEvent : MonoBehaviour {

    public string Title {
        get;
        set;
    }
    public string Atext {
        get;
        set;
    }
    public string Btext {
        get;
        set;
    }
    public string Ctext {
        get;
        set;
    }
    public string Number {
        get;
        set;
    }
    public string Stage {
        get;
        set;
    }
    //背景图片路径
    private string bcg_path;

    //记录按下了什么键
    public string ClickChoose {
        get;
        set;
    }

    public delegate void ClickHandler(string click);   //声明点击委托
    public event ClickHandler ClickEvent;        //声明点击事件
                                                 // Use this for initialization

    void Awake()
    {
       
    }
    void Start () {
        int number = int.Parse(Number);
        string image_name = LoadXml.lcchooseques.Items[number].image_name;
        bcg_path = "file://" + Application.streamingAssetsPath + "/Scene/" + image_name;
        LoadByWWW(bcg_path);

        transform.FindChild("Title").GetComponent<Text>().text = Title;
        transform.FindChild("number").GetComponent<Text>().text = Number;
        transform.FindChild("stage").GetComponent<Text>().text = Stage;
        transform.FindChild("A_Button").FindChild("Text").GetComponent<Text>().text = Atext;
        transform.FindChild("B_Button").FindChild("Text").GetComponent<Text>().text = Btext;
        transform.FindChild("C_Button").FindChild("Text").GetComponent<Text>().text = Ctext;
        if (Ctext == "")
        {
            transform.FindChild("C_Button").gameObject.SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
    public void Abutton_evevt() {
        // Debug.Log("A");
        //向主相机发送信息按下了a键
        ClickChoose = "A";
        if (ClickEvent != null) {
            ClickEvent(ClickChoose);
        }
    }
    public void Bbutton_event() {

        // Debug.Log("B");
        ClickChoose = "B";
        if (ClickEvent != null)
        {
            ClickEvent(ClickChoose);
        }

    }
    public void Cbutton_event() {

        // Debug.Log("C");
        ClickChoose = "C";
        if (ClickEvent != null)
        {
            ClickEvent(ClickChoose);
        }

    }

    //图片的外部加载

    private void LoadByWWW(string path)
    {
        StartCoroutine(Load(path));
    }

    IEnumerator Load(string path)
    {
        double startTime = (double)Time.time;
        //请求WWW
        WWW www = new WWW(path);
        //Debug.Log(www!=null);
        yield return www;
        if (www != null && string.IsNullOrEmpty(www.error))
        {
            //获取Texture
            Texture2D texture = www.texture;

            //创建Sprite
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            transform.FindChild("bcg").GetComponent<Image>().sprite = sprite;
            transform.FindChild("bcg").GetComponent<Image>().DOFade(1.0f, 2.0f);
            startTime = (double)Time.time - startTime;
            Debug.Log("WWW加载用时:" + startTime);
        }
    }


}
