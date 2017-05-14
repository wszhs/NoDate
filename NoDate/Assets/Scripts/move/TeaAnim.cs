using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaAnim : MonoBehaviour {
    public GameObject sprite1;
    public GameObject sprite2;
    float time = 0;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartTea() {
        sprite2.SetActive(false);
        sprite1.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        sprite2.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    public void MoveTea() {
        StartCoroutine(ChangeToSprite());
    }
    
    IEnumerator ChangeToSprite()
    {
        
      
        while (true)
        {
            if (time >= 255.0f)
            {
                time = 0;
                sprite1.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                sprite2.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                break;
            }
            time = time + 5;
            sprite2.SetActive(true);
            sprite2.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, time / 255.0f);
            sprite1.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1-(time / 255.0f));
            yield return new WaitForSeconds(0.01f);
        }

    }
}
