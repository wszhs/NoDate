using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class Appload
{
    static Appload()
    {
        bool hasKey = PlayerPrefs.HasKey("ActionWelcomeScreen");
        if (hasKey==false)
        {
            //EditorApplication.update += Update;
            PlayerPrefs.SetInt("ActionWelcomeScreen", 1);
            WelcomeScreen.ShowWindow();
        }
    }

    //static void Update() 
    //{
    //    bool isSuccess = EditorApplication.ExecuteMenuItem("Welcome Screen");
    //    if (isSuccess) EditorApplication.update -= Update;
    //}
}

public class WelcomeScreen : EditorWindow
{
    private Texture mSamplesImage;
    private Rect imageRect = new Rect(30f, 90f, 350f, 350f);
    private Rect textRect = new Rect(15f, 15f, 380f, 100f);

    public void OnEnable()
    {
        //this.mWelcomeScreenImage = EditorGUIUtility.Load("WelcomeScreenHeader.png") as Texture;
        //BehaviorDesignerUtility.LoadTexture("WelcomeScreenHeader.png", false, this);
        this.mSamplesImage = LoadTexture("wechat.jpg");
    }

    
    Texture LoadTexture(string name)
    {
        string path = "Assets/Demigiant/Editor/";
        return (Texture)AssetDatabase.LoadAssetAtPath(path + name, typeof(Texture));
    }

    public void OnGUI()
    {
        //GUI.DrawTexture(this.mWelcomeScreenImageRect, this.mWelcomeScreenImage);
        GUIStyle style = new GUIStyle();
        style.fontSize = 14;
        style.normal.textColor = Color.white;
        GUI.Label(this.textRect, "Action 欢迎你", style);
        GUI.DrawTexture(this.imageRect, this.mSamplesImage);
    }
    
    public static void ShowWindow()
    {
        WelcomeScreen window = EditorWindow.GetWindow<WelcomeScreen>(true, "Hello 你好 我是你们最亲爱的Action GG");
        window.minSize = window.maxSize = new Vector2(410f, 470f);
        UnityEngine.Object.DontDestroyOnLoad(window);
    }
}


