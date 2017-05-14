using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globel : MonoBehaviour {
    public const int value_number = 9;
    //智力值
    public static int intellect_value;
    //魅力值
    public static int charm_value;
    //健康值
    public static int health_value;
    //老板好感值
    public static int bossfavor_value;
    //老板san值
    public static int bosssan_value;
    //大哥好感值
    public static int brotherfavor_value;
    //大哥san值
    public static int brothersan_value;
    //海归好感值
    public static int turtlefavor_value;
    //海龟san值
    public static int turtlesan_value;

    public static long[] game_Value;

    //满足的升职条件个数
    public static int up_value = 0;
	// Use this for initialization
	void Start () {

        //静态成员初始化
        intellect_value = 0;
        charm_value = 0;
        health_value = 0;
        bossfavor_value = 0;
        bosssan_value = 0;
        brotherfavor_value = 0;
        brothersan_value = 0;
        turtlefavor_value = 0;
        turtlesan_value = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
