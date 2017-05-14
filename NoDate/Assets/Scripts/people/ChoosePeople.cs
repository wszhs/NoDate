using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePeople : MonoBehaviour {
    public GameObject[] people;
    private int index;
	// Use this for initialization
	void Start () {
        
        index = 0;
        people[index].SetActive(true);
        ShowValue();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void Destroypeople() {
        for (int i = 0; i < 4; i++) {
            people[index].SetActive(false);
        }
    }
    public void next_people() {
        
        if (index < 3) {
            
            Destroypeople();
            index++;
            people[index].SetActive(true);
            ShowValue();
        }
    }

    public void last_people() {
        
        if (index > 0) {
            
            Destroypeople();
            index--;
            people[index].SetActive(true);
            ShowValue();
        }
    }

    public void back_people() {
        gameObject.SetActive(false);
    }

    
    void ShowValue() {
        if (index < 3)
        {
            people[index].transform.FindChild("likevalue").GetComponent<Slider>().value = ((float)Globel.game_Value[2 * index + 3]) / 6.0f;
            people[index].transform.FindChild("sanvalue").GetComponent<Slider>().value = ((float)Globel.game_Value[2 * index + 4]) / 6.0f;
        }
    }
}
