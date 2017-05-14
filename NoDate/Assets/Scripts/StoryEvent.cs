using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class StoryEvent : MonoBehaviour {


    //立绘的标记
    private static int paint_flag = 0;
    private Object boss_object;
    private Object brother_object;
    private Object turtle_object;
    private Object biantai_object;
    private GameObject object_people;

    private GameObject animation_obj;

    public string time
    {
        get;
        set;
    }

    public string place
    {
        get;
        set;
    }

    private int count;

    public string namestring
    {
        get;
        set;
    }
    private Story s;
    //哪个故事
    public int storynumber = 0;
    public string answer {
        get;
        set; }


    float fSpeed = 0.05f;
    int curPos;
    Text Showtext;
    string sContent;//文本字符串
    private void Awake()
    {
        boss_object = Resources.Load("Prefabs/people/boss");
        brother_object = Resources.Load("Prefabs/people/brother");
        turtle_object = Resources.Load("Prefabs/people/turtle");
        biantai_object = Resources.Load("Prefabs/people/biantai");
        animation_obj = GameObject.Find("animation");
    }


    // Use this for initialization
    void Start () {
        transform.FindChild("Story").GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
        transform.FindChild("Story").GetComponent<Canvas>().worldCamera = Camera.main;
        transform.FindChild("Bcg").GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
        transform.FindChild("Bcg").GetComponent<Canvas>().worldCamera = Camera.main;
        transform.FindChild("People").GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
        transform.FindChild("People").GetComponent<Canvas>().worldCamera = Camera.main;


        s = LoadXml.lcstorylist[storynumber];
        initalize();
        string image_name =s.image_name;
        string  bcg_path = "file://" + Application.streamingAssetsPath + "/Scene/" + image_name;
        LoadByWWW(bcg_path);
        
        

    }


    
    public void next_story() {

        if (object_people != null)
        {
            Destroy(object_people);
        }
        count++;
        if (count < s.Items.Length)
        {
           
            initalize();
        }
        else {
            Camera.main.SendMessage("Create_Choose",storynumber+1,SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
       
    }

    void initalize() {
        animation_obj.SendMessage("DestroyPaint", paint_flag, SendMessageOptions.DontRequireReceiver);

        time =s.time;
        place = s.place;
        namestring = s.Items[count].name;

        if (namestring == "老板")
        {
            object_people = Instantiate(boss_object, null) as GameObject;
            object_people.transform.position = new Vector3(0, -1.3f, 0);
            object_people.transform.localScale = new Vector3(object_people.transform.localScale.x * -1.0f, object_people.transform.localScale.y, object_people.transform.localScale.z);
        }

        else if (namestring == "大哥")
        {
            object_people = Instantiate(brother_object, null) as GameObject;
            object_people.transform.position = new Vector3(0, -1.3f, 0);
            object_people.transform.localScale = new Vector3(object_people.transform.localScale.x * -1.0f, object_people.transform.localScale.y, object_people.transform.localScale.z);
        }
        else if (namestring == "海龟")
        {
            object_people = Instantiate(turtle_object, null) as GameObject;
            object_people.transform.position = new Vector3(0, -1.3f, 0);
            object_people.transform.localScale = new Vector3(object_people.transform.localScale.x * -1.0f, object_people.transform.localScale.y, object_people.transform.localScale.z);
        }
        else if (namestring == "变态")
        {
            object_people = Instantiate(biantai_object, null) as GameObject;
            object_people.transform.position = new Vector3(0, 0, 0);
            object_people.transform.localScale = new Vector3(object_people.transform.localScale.x * -1.0f, object_people.transform.localScale.y, object_people.transform.localScale.z);
        }
        answer = s.Items[count].answer;

        //当有结局字样变成红色

        if (answer.Contains("【"))
        {
            transform.FindChild("Story").FindChild("answer").FindChild("answer_text").GetComponent<Text>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
        else {
            transform.FindChild("Story").FindChild("answer").FindChild("answer_text").GetComponent<Text>().color = new Color(.0f, 0.0f, 0.0f, 1.0f);
        }

        Animationclick(answer);

        transform.FindChild("Story").FindChild("name").FindChild("name_text").GetComponent<Text>().text = namestring;
        if (namestring == "")
        {
            transform.FindChild("Story").FindChild("name").gameObject.SetActive(false);
          
        }
        else {
            transform.FindChild("Story").FindChild("name").gameObject.SetActive(true);
        }
        sContent = answer;
        Type();
        transform.FindChild("Story").FindChild("time").GetComponent<Text>().text = time;
        transform.FindChild("Story").FindChild("place").GetComponent<Text>().text = place;
    }

	// Update is called once per frame
	void Update () {
        
    }
    //图片的外部加载

    private void LoadByWWW(string path)
    {
        StartCoroutine(Load(path));
    }

    //打字机效果
    void Type() {
    
        Showtext= transform.FindChild("Story").FindChild("answer").FindChild("answer_text").GetComponent<Text>();
        SetContent();
    }

    void SetContent()
   {  
       curPos = 0;  
       //Debug.Log("lenth++" + sContent.Length);  
        Showtext.text = string.Empty;  
       InvokeRepeating("Typing", 0, fSpeed);  
    }

    void Typing()
    {  
        if (sContent.Length - 1 == curPos)//如果当前字符位置等于字符总长度前一个位置就停止调用打字方法  
           CancelInvoke("Typing");  
  
        Showtext.text += sContent.Substring(curPos, 1);//每次都截取到当前位置的下一个字符位置  
        curPos++;  
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
            transform.FindChild("Bcg").FindChild("bcg").GetComponent<Image>().sprite = sprite;
            transform.FindChild("Bcg").FindChild("bcg").GetComponent<Image>().DOFade(1.0f, 2.0f);
            startTime = (double)Time.time - startTime;
            Debug.Log("WWW加载用时:" + startTime);
        }
    }

    //跳到下一个选项
    public void NewSkip() {
        if (Manager.isfrontend == false)
        {
            animation_obj.SendMessage("DestroyPaint", paint_flag, SendMessageOptions.DontRequireReceiver);
            //count = s.Items.Length;
            if (object_people != null)
            {
                Destroy(object_people);
            }
            Camera.main.SendMessage("NewSkip", true, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
    public void Skip() {
        animation_obj.SendMessage("DestroyPaint", paint_flag, SendMessageOptions.DontRequireReceiver);
        //count = s.Items.Length;
        if (object_people != null)
        {
            Destroy(object_people);
        }
        Camera.main.SendMessage("Create_Choose", storynumber + 1, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
    public void Menu() {
        transform.FindChild("Story").gameObject.SendMessage("Move", true, SendMessageOptions.DontRequireReceiver);
    }

    public void Intoduce() {
        transform.FindChild("People").gameObject.SetActive(true);
    }

    //通知产生各种动画
    public void Animationclick(string answer) {

        //通知产生各种动画
        if (answer.Contains("血从我身上的好几个窟窿里奔涌而出"))
        {
            AnimationEvent.ANIM_NUMBER = 1;
        }
        if (answer.Contains("我看到有血从我身后的地上流淌到我面前"))
        {
            AnimationEvent.ANIM_NUMBER = 1;
        }
        else if (answer.Contains("妈妈……对不起……”早知道会这样，我就应该选择回老家了"))
        {
            AnimationEvent.ANIM_NUMBER = 2;
            Invoke("next_story", 3.0f);
        }
        else if (answer.Contains("在床上躺着躺着就困了"))
        {
            AnimationEvent.ANIM_NUMBER = 2;
            Invoke("next_story", 3.0f);
        }
        else if (answer.Contains("我紧紧的闭上了眼，大喊道"))
        {
            AnimationEvent.ANIM_NUMBER = 2;
            Invoke("next_story", 3.0f);
        }

        else if (answer.Contains("我渐渐失去了意识"))
        {
            AnimationEvent.ANIM_NUMBER = 2;
            Invoke("next_story", 3.0f);
        }

        else if (answer.Contains("而我闭上了眼睛，等待着未知的命运"))
        {
            AnimationEvent.ANIM_NUMBER = 2;
            Invoke("next_story", 3.0f);
        }

        else if (answer.Contains("困意逐渐袭来，我缓缓的闭上了眼"))
        {
            AnimationEvent.ANIM_NUMBER = 2;
            Invoke("next_story", 3.0f);
        }


        else if (answer.Contains("完了，要迟到了"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
        }
        else if (answer.Contains("咚咚咚"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
        }
        else if (answer.Contains("歹徒踢了踢脚下的麻袋"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
        }
        else if (answer.Contains("我回家处理吧，先走了"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
        }
        else if (answer.Contains("“臭流氓！”我热血上头"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
        }
        else if (answer.Contains("“滴——”手机振动了一下"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
        }
        else if (answer.Contains("一只手直接将我车进了屋内"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
        }
        else if (answer.Contains("哈哈哈哈"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
        }
        else if (answer.Contains("我的手机突然响了"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
        }
        else if (answer.Contains("手机突然响起，是一个陌生的号码"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
        }
        else if (answer.Contains("而周围的同事们也忍不住聚集过去想看看新同事的风采"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
        }
        else if (answer.Contains("背后突然有人撞了我一下"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
        }
        else if (answer.Contains("哎呀，我肚子好痛，这串里有毒"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
        }
        else if (answer.Contains("“哈哈哈哈哈哈哈哈！”一阵奇怪的笑声传来")) {
            AnimationEvent.ANIM_NUMBER = 3;
        }
        else if (answer.Contains("变态啊——”我大喊着，把手中的包包扔了出去"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
        }



        else if (answer.Contains("后脖子一痛"))
        {
            AnimationEvent.ANIM_NUMBER = 4;
            Invoke("next_story", 3.0f);
        }

        else if (answer.Contains("放我走！不然我就捅死你"))
        {
            AnimationEvent.ANIM_NUMBER = 4;
            Invoke("next_story", 3.0f);
        }
        else if (answer.Contains("一天我走在去觅食的路上"))
        {
            AnimationEvent.ANIM_NUMBER = 4;
            Invoke("next_story", 3.0f);
        }
        else if (answer.Contains("正打算站起来时，胸前一阵疼痛，心脏剧烈的跳动着"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
        }
        else if (answer.Contains("而这些，我再也看不到了"))
        {
            AnimationEvent.ANIM_NUMBER = 2;
            Invoke("next_story", 3.0f);
        }


        //立绘动画
        else if (answer.Contains("你看你看，这件裙子好看"))
        {
            paint_flag = 0;
            animation_obj.SendMessage("CreatePaint", paint_flag, SendMessageOptions.DontRequireReceiver);
        }
        else if (answer.Contains("我看上了一件纯黑色的连帽衫"))
        {
            paint_flag = 1;
            animation_obj.SendMessage("CreatePaint", paint_flag, SendMessageOptions.DontRequireReceiver);
        }
        else if (answer.Contains("你看那件怎么样？"))
        {
            paint_flag = 2;
            animation_obj.SendMessage("CreatePaint", paint_flag, SendMessageOptions.DontRequireReceiver);
        }
        else if (answer.Contains("我翻出一件小西服样式的外套"))
        {
            paint_flag = 3;
            animation_obj.SendMessage("CreatePaint", paint_flag, SendMessageOptions.DontRequireReceiver);
        }
        else if (answer.Contains("隔壁的小林"))
        {
            paint_flag = 4;
            animation_obj.SendMessage("CreatePaint", paint_flag, SendMessageOptions.DontRequireReceiver);
        }
        else if (answer.Contains("掀翻了桌上的茶杯"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
            paint_flag = 5;
            animation_obj.SendMessage("CreatePaint", paint_flag, SendMessageOptions.DontRequireReceiver);
        }
       
        else if (answer.Contains("我看着关闭的门"))
        {
            paint_flag = 7;
            animation_obj.SendMessage("CreatePaint", paint_flag, SendMessageOptions.DontRequireReceiver);
        }
        else if (answer.Contains("这个面子你都不给吗？”老板不依不饶"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
            paint_flag = 8;
            animation_obj.SendMessage("CreatePaint", paint_flag, SendMessageOptions.DontRequireReceiver);
        }
        else if (answer.Contains("一只手悄悄地从口袋里掏出手机，再用余光悄悄地打开了录音"))
        {
            paint_flag = 9;
            animation_obj.SendMessage("CreatePaint", paint_flag, SendMessageOptions.DontRequireReceiver);
        }
        else if (answer.Contains("手机振动了一下"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
            paint_flag = 10;
            animation_obj.SendMessage("CreatePaint", paint_flag, SendMessageOptions.DontRequireReceiver);
        }
        else if (answer.Contains("我的手机突然响了"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
            paint_flag = 11;
            animation_obj.SendMessage("CreatePaint", paint_flag, SendMessageOptions.DontRequireReceiver);
        }
        else if (answer.Contains("哎，等一下，给我倒酒"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
            paint_flag = 8;
            animation_obj.SendMessage("CreatePaint", paint_flag, SendMessageOptions.DontRequireReceiver);
        }
        else if (answer.Contains("手机突然响起，是一个陌生的号码"))
        {
            AnimationEvent.ANIM_NUMBER = 3;
            paint_flag = 11;
            animation_obj.SendMessage("CreatePaint", paint_flag, SendMessageOptions.DontRequireReceiver);
        }
        else if (answer.Contains("我直接寻找着兰兰指定要吃的五花肉"))
        {
            paint_flag = 12;
            animation_obj.SendMessage("CreatePaint", paint_flag, SendMessageOptions.DontRequireReceiver);
        }
    }
}
