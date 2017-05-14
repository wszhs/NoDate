using UnityEngine;
using System.Collections;
using System.Xml;
using UnityEngine.SceneManagement;
using System.IO;
using System.Xml.Linq;
public class LoadXml : MonoBehaviour
{
    // Use this for initialization

    private const int  NUMBER= 147;
    public static string levelconfigString
    {
        get;
        set;
    }

    public static LevelConfig lclevelconfig
    {
        get;
        set;
    }

    //各个选项
    public static string choosequesString {
        get;
        set;
    }


    public static ChooseQues lcchooseques {
        get;
        set;
    }

    
    public static string storyString{
        get;
        set;
       }

    public static Story lcstory
    {
        get;
        set;
    }

    public static Story []lcstorylist {
        get;
        set;
    }
    void Awake()
    {

        lcstorylist = new Story[NUMBER];
        
        levelconfigString = XmlUtil.XML2String(Application.streamingAssetsPath + "/XMLS/LevelConfig.xml");
        lclevelconfig = XmlUtil.Deserialize<LevelConfig>(levelconfigString);

        choosequesString = XmlUtil.XML2String(Application.streamingAssetsPath + "/XMLS/ChooseQues.xml");
        lcchooseques = XmlUtil.Deserialize<ChooseQues>(choosequesString);

        for (int i = 0; i < NUMBER; i++)
        {
            storyString = XmlUtil.XML2String(Application.streamingAssetsPath + "/XMLS/Story_"+(i+1)+".xml");
            lcstory = XmlUtil.Deserialize<Story>(storyString);
            lcstorylist[i] = lcstory;
            
            
        }
       
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
  
   
}
