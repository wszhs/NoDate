using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class menuanim : MonoBehaviour {
    private GameObject save;
    private GameObject read;
    private GameObject intoduce;
    private GameObject back;
    private float time=0.5f;
	// Use this for initialization
	void Start () {
        
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move()
    {
        save = transform.FindChild("save").gameObject;
        read = transform.FindChild("read").gameObject;
        intoduce = transform.FindChild("intoduce").gameObject;
        back = transform.FindChild("back").gameObject;
        save.SetActive(true);
        read.SetActive(true);
        intoduce.SetActive(true);
        back.SetActive(true);
        save.transform.DOMove(transform.FindChild("save_point").transform.position, time).SetEase(Ease.OutBack);
        read.transform.DOMove(transform.FindChild("read_point").transform.position, time).SetEase(Ease.OutBack); 
        intoduce.transform.DOMove(transform.FindChild("intoduce_point").transform.position, time).SetEase(Ease.OutBack); 
        back.transform.DOMove(transform.FindChild("back_point").transform.position, time).SetEase(Ease.OutBack); 
    }

    public void BackAnim() {
       
        save.transform.DOLocalMove(new Vector3(636.0f,-200.0f), time);
        read.transform.DOLocalMove(new Vector3(636.0f, -200.0f), time);
        intoduce.transform.DOLocalMove(new Vector3(636.0f, -200.0f), time);
        back.transform.DOLocalMove(new Vector3(636.0f, -200.0f), time);
        Invoke("NoActive",0.4f);
       
    }

    void NoActive() {
        save.SetActive(false);
        read.SetActive(false);
        intoduce.SetActive(false);
        back.SetActive(false);
        SceneManager.LoadScene("front");
    }
}
