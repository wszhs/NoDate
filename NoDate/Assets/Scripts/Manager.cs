using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    private ArrayList a_result;
    private ArrayList b_result;
    private ArrayList c_result;
    private ArrayList question;
    private ArrayList id_list;
    private string click_number;

    //选项的个数
    private int choose_number;
    //承载选项的实体
    private Object choose_object;
    private GameObject object_choose;

    private Object choose_object1;
    private Object choose_object2;

    //故事情节载体
    private Object story_object;
    private GameObject object_story;
    private Object story_object1;
    private Object story_object2;

    private Object rain_object;
    private GameObject object_rain;

    //判断有没有结束
    public static bool isend = false;

    //判断是否为结束前夕
    public static bool isfrontend = false;

    //标记
    private int flag;

    void Awake()
    {

        Globel.game_Value = new long[Globel.value_number];
        choose_number = LoadXml.lcchooseques.Items.Length;
        a_result = new ArrayList();
        b_result = new ArrayList();
        c_result = new ArrayList();
        question = new ArrayList();
        id_list = new ArrayList();

        for (int i = 0; i < choose_number; i++)
        {
            a_result.Add(LoadXml.lcchooseques.Items[i].answer_a);
            b_result.Add(LoadXml.lcchooseques.Items[i].answer_b);
            c_result.Add(LoadXml.lcchooseques.Items[i].answer_c);
            question.Add(LoadXml.lcchooseques.Items[i].question);
            id_list.Add(LoadXml.lcchooseques.Items[i].id);
        }

        //从resources中找到需要的预制体
        choose_object = Resources.Load("Prefabs/globel/Choose");
        choose_object1 = Resources.Load("Prefabs/globel/Choose1");
        choose_object2 = Resources.Load("Prefabs/globel/Choose2");
        story_object = Resources.Load("Prefabs/globel/Story");
        story_object1 = Resources.Load("Prefabs/globel/Story1");
        story_object2 = Resources.Load("Prefabs/globel/Story2");
        rain_object = Resources.Load("Prefabs/globel/rain");

    }
    // Use this for initialization
    void Start() {

        flag = 0;
        CreateStory(1);
        //CreateChoose(flag);

    }

    public void NewSkip() {
        if (isfrontend == false)
        {
            CreateChoose(flag);
        }
        Debug.Log("skip");
    }
    //创建一个故事
    void CreateStory(int number) {
        Debug.Log("zhsbug" + number);
        if ((number >= 86 && number <= 92) || (number >= 103 && number <= 121)|| (number >= 137 && number <= 144))
        {
            object_story = Instantiate(story_object1, null) as GameObject;
        }
        else if ((number >= 93 && number <= 102) || (number >= 122 && number <= 132))
        {
            object_story = Instantiate(story_object2, null) as GameObject;
        }
        else
        {
            object_story = Instantiate(story_object, null) as GameObject;
        }
        object_story.GetComponent<StoryEvent>().storynumber = number - 1;
    }

    //创建一个选项
    void CreateChoose(int flag) {
        if (flag == 15 || flag == 16||flag==17)
        {
            object_choose = Instantiate(choose_object1, null) as GameObject;
        }
        else if (flag == 19 || flag == 20 || flag == 21)
        {
            object_choose = Instantiate(choose_object2, null) as GameObject;
        }
        else
        {
            object_choose = Instantiate(choose_object, null) as GameObject;
        }
        object_choose.GetComponent<ButtonEvent>().Atext = a_result[flag].ToString();
        object_choose.GetComponent<ButtonEvent>().Btext = b_result[flag].ToString();
        object_choose.GetComponent<ButtonEvent>().Ctext = c_result[flag].ToString();
        object_choose.GetComponent<ButtonEvent>().Title = question[flag].ToString();
        object_choose.GetComponent<ButtonEvent>().Number = id_list[flag].ToString();
        Road();
        object_choose.GetComponent<ButtonEvent>().ClickEvent += ChooseClick;
    }

    void Create_Choose(int s) {
        Debug.Log("ZHS" + s);
        if (s == 8 || s == 9 || s == 10)
        {
            CreateStory(11);
        }

        else if (s == 14 || s == 15)
        {
            CreateStory(16);
        }
        else if (s == 17)
        {
            CreateStory(32);
        }
        else if (s == 18 || s == 19)
        {
            CreateStory(20);
        }
        else if ((s == 24 || s == 25 || s == 26) && flag == 9)
        {
            CreateStory(27);
        }

        else if (s == 27)
        {
            if (Globel.game_Value[0] > 5)
            {
                CreateStory(28);
                flag = 11;
            }
            else
            if (Globel.game_Value[1] > 5)
            {
                CreateStory(29);
                flag = 11;
            }

            else
            {
                flag = 10;
                CreateStory(133);
                //CreateChoose(flag);
            }
        }

        else if (s == 28 || s == 29 || s == 12 || s == 13)
        {
            CreateStory(33);
        }
        else if (s == 33)
        {
            CreateStory(42);
        }
        else if (s == 42)
        {
            CreateStory(43);
        }
        else if (s == 43)
        {
            CreateStory(44);
        }
        else if (s == 44)
        {
            flag = 11;
            CreateChoose(flag);
        }
        else if (s == 45)
        {
            CreateStory(46);
        }
        else if (s == 47)
        {
            CreateStory(48);
        }
        else if (s == 49)
        {
            CreateStory(50);
        }
        else if (s == 46 || s == 48 || s == 50)
        {
            CreateStory(51);
        }
        else if (s == 51)
        {
            CreateStory(52);
        }
        else if (s == 52)
        {
            flag = 12;
            CreateChoose(flag);
        }

        else if (s == 53)
        {
            CreateStory(54);
        }
        else if (s == 55)
        {
            CreateStory(56);
        }
        else if (s == 57)
        {
            CreateStory(58);
        }
        else if (s == 54 || s == 56 || s == 58)
        {
            CreateStory(59);
        }
        else if (s == 59)
        {
            CreateStory(60);
        }
        else if (s == 60)
        {
            CreateStory(61);
        }

        else if (s == 61)
        {
            flag = 13;
            CreateChoose(flag);
        }
        else if (s == 62)
        {
            CreateStory(63);
        }
        else if (s == 63)
        {
            CreateStory(64);
        }
        else if (s == 65)
        {
            CreateStory(66);
        }
        else if (s == 66)
        {
            CreateStory(67);
        }
        else if (s == 68)
        {
            CreateStory(69);
        }
        else if (s == 69)
        {
            CreateStory(70);
        }




        else if (s == 64 || s == 67 || s == 70)
        {
            if (Globel.game_Value[3] > 3)
            {
                isfrontend = true;
                CreateStory(71);
            }
            else if (Globel.game_Value[4] > 3)
            {
                isfrontend = true;
                CreateStory(78);
            }
            else if ((Globel.game_Value[0] >= 4 || Globel.game_Value[1] >= 4) && Globel.game_Value[4] < 2)
            {
                Globel.up_value++;
                flag = 14;
                //CreateChoose(flag);
                CreateStory(85);
            }
            else
            {
                flag = 14;
                CreateStory(85);
                //CreateChoose(flag);
            }
        }

        else if (s == 71)
        {
            CreateStory(72);
        }
        else if (s == 72)
        {
            CreateStory(73);
        }
        else if (s == 73)
        {
            CreateStory(74);
        }
        else if (s == 74)
        {
            CreateStory(75);
        }
        else if (s == 75)
        {
            CreateStory(76);
        }
        else if (s == 76)
        {
            isend = true;
            Debug.Log("和老板在一起结局");
            CreateStory(77);
        }

        else if (s == 78)
        {
            CreateStory(79);
        }
        else if (s == 79)
        {
            CreateStory(80);
        }
        else if (s == 80)
        {
            CreateStory(81);
        }
        else if (s == 81)
        {
            CreateStory(82);
        }
        else if (s == 82)
        {
            CreateStory(83);
        }
        else if (s == 83)
        {
            isend = true;
            Debug.Log("进入被辞退后报复结局");
            CreateStory(84);
        }


        else if (s == 84)
        {
            CreateStory(40);
        }

        else if (s == 40) {
            CreateStory(41);
        }

        else if (s == 85)
        {
            //CreateChoose(flag);
            CreateStory(133);
        }

        else if (s == 86)
        {
            flag = 15;
            CreateChoose(flag);
        }

        else if (s == 87 || s == 88 || s == 89)
        {
            CreateStory(90);
        }
        else if (s == 90)
        {
            CreateStory(91);
        }
        else if (s == 91)
        {
            CreateStory(92);
        }
        else if (s == 92)
        {
            CreateStory(93);
        }
        else if (s == 93)
        {
            flag = 19;
            CreateChoose(flag);
        }
        else if (s == 94 || s == 95 || s == 96)
        {
            flag = 20;
            CreateChoose(flag);
        }
        else if (s == 97)
        {
            CreateStory(98);
        }
        else if (s == 99)
        {
            CreateStory(100);
        }
        else if (s == 101)
        {
            CreateStory(102);
        }

        else if (s == 98 || s == 100 || s == 102)
        {
            CreateStory(103);
        }
        else if (s == 103)
        {
            CreateStory(104);
        }
        else if (s == 104)
        {
            flag = 16;
            CreateChoose(flag);
        }

        else if (s == 105)
        {
            CreateStory(106);
        }
        else if (s == 107)
        {
            CreateStory(108);
        }
        else if (s == 109)
        {
            CreateStory(110);
        }
        else if (s == 106 || s == 108 || s == 110)
        {
            CreateStory(111);
        }
        else if (s == 111)
        {
            CreateStory(112);
        }
        else if (s == 112)
        {
            CreateStory(113);
        }
        else if (s == 113)
        {
            CreateStory(114);
        }
        else if (s == 114)
        {
            CreateStory(115);
        }
        else if (s == 115)
        {
            flag = 17;
            CreateChoose(flag);
        }


        else if (s == 116)
        {
            CreateStory(117);
        }

        else if (s == 118)
        {
            CreateStory(119);
        }

        else if (s == 120)
        {
            CreateStory(121);
        }

        else if (s == 117 || s == 119 || s == 121)
        {


            if (Globel.game_Value[7] > 3)
            {

                Debug.Log("进入五十度灰结局");
                isfrontend = true;
                CreateStory(137);
            }
            else
                  if (Globel.game_Value[8] > 3)
            {

                Debug.Log("进入被玩坏结局");
                isfrontend = true;
                CreateStory(141);
            }
            else if (Globel.game_Value[0] >= 8 || Globel.game_Value[1] >= 8)
            {

                Globel.up_value++;
                CreateStory(122);
            }
            else
            {
                CreateStory(122);
            }

        }
        else if (s == 122)
        {
            CreateStory(123);
        }
        else if (s == 123)
        {
            flag = 21;
            CreateChoose(flag);
        }

        else if (s == 124)
        {
            CreateStory(125);
        }

        else if (s == 125 || s == 126 || s == 127)
        {
            if (Globel.game_Value[5] > 3)
            {
                isfrontend = true;
                CreateStory(128);
            }
            else if (Globel.game_Value[6] > 3)
            {
                isfrontend = true;
                CreateStory(131);
            }
            else if (Globel.game_Value[0] >= 6 || Globel.game_Value[1] >= 6)
            {

                Globel.up_value++;
                flag = 22;
                CreateStory(133);

            }
            else
            {
                flag = 22;
                CreateStory(133);
            }
        }

        else if (s == 128)
        {
            isend = true;
            Debug.Log("进入大哥的女人结局");
            CreateStory(129);
        }
        else if (s == 131)
        {
            isend = true;
            Debug.Log("进入被小弟砍死结局");
            CreateStory(132);
        }

        else if (s == 133)
        {
            if (flag == 14 && Globel.game_Value[2] >= 10)
            {
                CreateStory(86);
            }
            else if (flag == 22 && Globel.game_Value[2] >= 10)
            {
                CreateStory(145);
                isfrontend = true;
                isend = true;
                Debug.Log("光荣的单身狗结局");
            }
            else
            {
                CreateChoose(flag);
            }
        }

        else if (s == 145)
        {
            isend = true;
            CreateStory(146);
        }

        else if (s == 137)
        {
            CreateStory(138);
        }
        else if (s == 138)
        {
            CreateStory(139);
        }
        else if (s == 139)
        {
            isend = true;
            CreateStory(140);
        }

        else if (s == 141)
        {
            CreateStory(142);
        }
        else if (s == 142)
        {
            CreateStory(143);
        }
        else if (s == 143)
        {
            isend = true;
            CreateStory(144);
        }

        else
        {
            if (isend != true)
            {
                CreateChoose(flag);
            }
        }
    }

   // 鼠标触发事件
   void ChooseClick(string s)
    {

        Debug.Log(flag+"选择"+s);
        ChooseResult(flag, s);

        printf_value();

        Destroy(object_choose);

       // flag++;
       // Debug.Log(flag);
       // StageChoose(s);
        StageStory(s);
        if (isend)
        {
            Debug.Log("end");
        }
        //else
        //{
        //    CreateChoose(flag);
        //}
        flag++;
    }

    //故事的分支点
    void StageStory(string click_number) {
        switch (flag)
        {

            case 0:

                if (click_number == "A")
                {
                    CreateStory(2);
                }
                else if (click_number == "B")
                {
                    CreateStory(3);
                }
                else {
                    CreateStory(4);
                }
                break;
            case 1:

                if (click_number == "A")
                {
                    CreateStory(5);
                }
                else if (click_number == "B")
                {
                    CreateStory(6);
                }
                else
                {
                    CreateStory(7);
                }
                break;

            case 2:

                if (click_number == "A")
                {
                    CreateStory(8);
                }
                else if (click_number == "B")
                {
                    CreateStory(9);
                }
                else
                {
                    CreateStory(10);
                }
                break;

            case 3:
                if ((Globel.game_Value[0] > 2) && click_number == "A")
                {
                    CreateStory(12);
                    flag = 10;
                }
                else
                if ((Globel.game_Value[1] > 2) && click_number == "A")
                {

                    CreateStory(13);
                    flag = 10;
                }
                else
                    if (click_number == "A")
                {
                    CreateStory(14);
                }
                else {
                    CreateStory(15);
                }
                break;
            case 4:
                if (click_number == "A")
                {
                    isfrontend = true;
                    isend = true;
                    Debug.Log("被快递员弄死结局");
                    CreateStory(17);

                }
                if (click_number == "B") {
                    CreateStory(18);
                }
                if (click_number == "C") {
                    CreateStory(19);
                }
                    break;
            case 5:
                if (click_number == "A") {
                    CreateStory(21);
                }
                if (click_number == "B")
                {
                    CreateStory(22);
                }
                if (click_number == "C")
                {
                    CreateStory(23);
                }
                break;
            case 6:
                if (click_number == "A")
                {
                    CreateStory(24);
                }
                if (click_number == "B")
                {
                    CreateStory(25);
                }
                if (click_number == "C")
                {
                    CreateStory(26);
                }
                break;
            case 7:
                if (click_number == "A")
                {
                    CreateStory(24);
                }
                if (click_number == "B")
                {
                    CreateStory(25);
                }
                if (click_number == "C")
                {
                    CreateStory(26);
                }
                break;
            case 8:
                if (click_number == "A")
                {
                    CreateStory(24);
                }
                if (click_number == "B")
                {
                    CreateStory(25);
                }
                if (click_number == "C")
                {
                    CreateStory(26);
                }
                break;
            case 9:
                if (click_number == "A")
                {
                    CreateStory(24);
                }
                if (click_number == "B")
                {
                    CreateStory(25);
                }
                if (click_number == "C")
                {
                    CreateStory(26);
                }
                break;
            case 10:
                if (click_number == "A")
                {
                    isend = true;
                    isfrontend = true;
                    Debug.Log("进入碌碌无为结局");
                    CreateStory(30);
                    object_rain = Instantiate(rain_object, null) as GameObject;
                }
                else
                {
                    isfrontend = true;
                    isend = true;
                    Debug.Log("进入病死结局");
                    CreateStory(136);
                }
                break;




                //新的场景
            case 11:
                if (click_number == "A")
                {
                    CreateStory(45);
                }
                if (click_number == "B")
                {
                    CreateStory(47);
                }
                if (click_number == "C")
                {
                    CreateStory(49);
                }
                break;
            case 12:
                if (click_number == "A")
                {
                    CreateStory(53);
                }
                if (click_number == "B")
                {
                    CreateStory(55);
                }
                if (click_number == "C")
                {
                    CreateStory(57);
                }
                break;
            case 13:
                if (click_number == "A")
                {
                    CreateStory(62);
                }
                if (click_number == "B")
                {
                    CreateStory(65);
                }
                if (click_number == "C")
                {
                    CreateStory(68);
                }
                break;
            case 14:
                if (click_number == "A")
                {
                    if (Globel.up_value == 1) {
                        CreateStory(86);
                    }
                    else
                    {
                        isfrontend = true;
                        isend = true;
                        Debug.Log("进入碌碌无为结局");
                        CreateStory(30);
                        object_rain = Instantiate(rain_object, null) as GameObject;
                    }
                }
                else
                {
                    isend = true;
                    isfrontend = true;
                    Debug.Log("进入病死结局");
                    CreateStory(136);
                }
                break;
            case 15:
                if (click_number == "A")
                {
                    CreateStory(87);
                }
                if (click_number == "B")
                {
                    CreateStory(88);
                }
                if (click_number == "C")
                {
                    CreateStory(89);
                }
                break;

            case 19:
                if (click_number == "A")
                {
                    CreateStory(94);
                }
                if (click_number == "B")
                {
                    CreateStory(95);
                }
                if (click_number == "C")
                {
                    CreateStory(96);
                }
                break;
            case 20:
                if (click_number == "A")
                {
                    CreateStory(97);
                }
                if (click_number == "B")
                {
                    CreateStory(99);
                }
                if (click_number == "C")
                {
                    CreateStory(101);
                }
                break;

            case 16:
                if (click_number == "A")
                {
                    CreateStory(105);
                }
                if (click_number == "B")
                {
                    CreateStory(107);
                }
                if (click_number == "C")
                {
                    CreateStory(109);
                }
                break;

            case 17:
                if (click_number == "A")
                {
                    CreateStory(116);
                }
                if (click_number == "B")
                {
                    CreateStory(118);
                }
                if (click_number == "C")
                {
                    CreateStory(120);
                }
                break;
            case 21:
                if (click_number == "A")
                {
                    
                    CreateStory(124);
                }
                if (click_number == "B")
                {
                    CreateStory(126);
                }
                if (click_number == "C")
                {
                    CreateStory(127);
                }
                break;
            case 22:
                if (click_number == "A")
                {
                    if (Globel.up_value == 3)
                    {
                        isfrontend = true;
                        isend = true;
                        CreateStory(145);

                        Debug.Log("光荣的单身狗结局");

                    }
                    else
                    {
                        isend = true;
                        isfrontend = true;
                        Debug.Log("进入碌碌无为结局");
                        CreateStory(30);
                        object_rain = Instantiate(rain_object, null) as GameObject;
                    }
                }
                else
                {
                    isfrontend = true;
                    isend = true;
                    Debug.Log("进入病死结局");
                    CreateStory(136);
                }
                break;

        }
    }
    //分支点选择
    //void StageChoose(string click_number) {

    //    switch (flag) {

    //        case 3:
    //            if ((Globel.game_Value[0]> 2 || Globel.game_Value[1] > 2) && click_number == "A")
    //            {
    //                flag = 11;
    //            }
    //            else {
    //                flag = 4;

    //            }
    //            break;
    //        case 4:
    //            if (click_number == "A") {
    //                isend = true;
    //                Debug.Log("被快递员弄死结局");
    //            }
    //            break;
    //        case 9:
    //            if (Globel.game_Value[0] > 5 || Globel.game_Value[1] > 5)
    //            {
    //                flag = 11;
    //            }
    //            break;
    //        case 10:
    //            if (click_number == "A")
    //            {
    //                isend = true;
    //                Debug.Log("进入碌碌无为结局");
    //            }
    //            else {
    //                isend = true;
    //                Debug.Log("进入病死结局");
    //            }
    //            break;
    //        case 13:
    //            if (Globel.game_Value[3] > 3)
    //            {
    //                isend = true;
    //                Debug.Log("和老板在一起结局");
    //            }
    //            else if (Globel.game_Value[4] > 3)
    //            {
    //                isend = true;
    //                Debug.Log("进入被辞退后报复结局");
    //            }
    //            else if ((Globel.game_Value[0] >= 4 || Globel.game_Value[1] >= 4) && Globel.game_Value[4] < 2)
    //            {
    //                Globel.up_value++;
    //                if (Globel.game_Value[2] < 10)
    //                {
    //                    flag = 14;
    //                }
    //                else
    //                {
    //                    flag = 15;
    //                }
    //            }
    //            else {
    //                if (Globel.game_Value[2] < 10)
    //                {
    //                    flag = 14;
    //                }
    //                else {
    //                    isend = true;
    //                    Debug.Log("进入碌碌无为结局");
    //                }
    //            }
    //            break;
    //        case 14:
    //            if (Globel.up_value == 1)
    //            {
    //                flag = 15;
    //            }
    //            else {
    //                isend = true;
    //                Debug.Log("进入碌碌无为结局");
    //            }
    //            break;
    //        case 17:
    //            if (Globel.game_Value[7] > 3)
    //            {
    //                isend = true;
    //                Debug.Log("进入五十度灰结局");
    //            }
    //            else
    //                if (Globel.game_Value[8] > 3)
    //            {
    //                isend = true;
    //                Debug.Log("进入被玩坏结局");
    //            }
    //            else if (Globel.game_Value[0] >= 8 || Globel.game_Value[1] >= 8)
    //            {
    //                Globel.up_value++;
    //                if (Globel.game_Value[2] < 10)
    //                {
    //                    flag = 18;
    //                }
    //                else
    //                {
    //                    flag = 19;
    //                }
    //            }
    //            else {
    //                if (Globel.game_Value[2] < 10)
    //                {
    //                    flag = 18;
    //                }
    //                else {
    //                    isend = true;
    //                    Debug.Log("进入碌碌无为结局");
    //                }
    //            }
    //            break;
    //        case 18:
    //            if (Globel.up_value == 2)
    //            {
    //                flag = 19;
    //            }
    //            else
    //            {
    //                if (Globel.game_Value[2] < 1)
    //                {
    //                    isend = true;
    //                    Debug.Log("进入进入病死结局");
    //                }
    //                else
    //                {
    //                    isend = true;
    //                    Debug.Log("进入碌碌无为结局");
    //                }
    //            }
    //            break;

    //        case 21:
    //            if (Globel.game_Value[5] > 3)
    //            {
    //                isend = true;
    //                Debug.Log("进入大哥的女人结局");
    //            }
    //            else
    //                if (Globel.game_Value[6] > 3)
    //            {

    //                isend = true;
    //                Debug.Log("进入被小弟砍死结局");
    //            }
    //            else
    //                if (Globel.game_Value[0] >= 6 || Globel.game_Value[1] >= 6)
    //            {
    //                Globel.up_value++;
    //                if (Globel.game_Value[2] < 10)
    //                {
    //                    flag = 22;
    //                }
    //                else
    //                {
    //                    isend = true;
    //                    Debug.Log("进入光辉的单身狗结局");
    //                }

    //            }
    //            else {
    //                if (Globel.game_Value[2] < 10)
    //                {
    //                    flag = 22;
    //                }
    //                else
    //                {
    //                    isend = true;
    //                    Debug.Log("进入碌碌无为结局");
    //                }
    //            }
    //            break;

    //        case 22:
    //            if (Globel.up_value == 3)
    //            {
    //                isend = true;
    //                Debug.Log("进入光辉的单身狗结局");
    //            }
    //            else
    //            {
    //                if (Globel.game_Value[2] < 1)
    //                {
    //                    isend = true;
    //                    Debug.Log("进入进入病死结局");
    //                }
    //                else
    //                {
    //                    isend = true;
    //                    Debug.Log("进入碌碌无为结局");
    //                }
    //            }
    //            break;

    //    }

    //}
    //选择不同的选项触发的结果
    void ChooseResult(int flag,string choose_result) {

        switch (choose_result) {

            case "A":
                {
                    long number = 0;
                    if (LoadXml.lcchooseques.Items[flag].value_a != "")
                    {
                        number= long.Parse(LoadXml.lcchooseques.Items[flag].value_a);
                    }
                    SaveValue(number);
                    break;
                }
            case "B":
                {
                    long number = 0;
                    if (LoadXml.lcchooseques.Items[flag].value_b!= "")
                    {
                        number = long.Parse(LoadXml.lcchooseques.Items[flag].value_b);
                    }
                    SaveValue(number);
                    break;
                }
            case "C":
                {
                    long number = 0;
                    if (LoadXml.lcchooseques.Items[flag].value_c != "")
                    {
                        number = long.Parse(LoadXml.lcchooseques.Items[flag].value_c);
                    }
                    SaveValue(number);
                    break;
                }
        }
    }

    void SaveValue(long number) {
        while (number != 0) {
            long value_flag = number % 1000;

            long []number_flag = new long[3];
            for (int i = 2; i>=0; i--) {
                number_flag[i] = value_flag % 10;
                value_flag /= 10;
            }

            if (number_flag[1] == 0)
            {
                Globel.game_Value[number_flag[0]] += number_flag[2];
            }
            else {
                Globel.game_Value[number_flag[0]] -= number_flag[2];
            }

            number /= 1000;
        }
    }

    //打印出当前的各个值
    void printf_value() {
        Debug.Log("智力值"+Globel.game_Value[0]);
        Debug.Log("魅力值" + Globel.game_Value[1]);
        Debug.Log("健康值" + Globel.game_Value[2]);
        Debug.Log("老板好感值" + Globel.game_Value[3]);
        Debug.Log("老板san值" + Globel.game_Value[4]);
        Debug.Log("大哥好感值" + Globel.game_Value[5]);
        Debug.Log("大哥san值" + Globel.game_Value[6]);
        Debug.Log("海龟好感值" + Globel.game_Value[7]);
        Debug.Log("海龟san值" + Globel.game_Value[8]);
    }

    //当前线路
    void Road() {
        if (flag < 4)
        {
            object_choose.GetComponent<ButtonEvent>().Stage = "面试前三天共通剧情";
        }
        else
            if (flag < 11)
        {
            object_choose.GetComponent<ButtonEvent>().Stage = "面试失败剧情";

        }
        else
            if (flag < 15)
        {
            object_choose.GetComponent<ButtonEvent>().Stage = "老板路线";

        }
        else if (flag < 19)
        {
            object_choose.GetComponent<ButtonEvent>().Stage = "海归路线";

        }
        else {
            object_choose.GetComponent<ButtonEvent>().Stage = "东北大哥路线";
        }

    }
}
