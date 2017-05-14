using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public GameObject boss;
    public GameObject brother;
    public GameObject turtle;
    public GameObject biantai;
    private Animator boss_animator;
    private Animator brother_animator;
    private Animator turtle_animator;
    private Animator biantai_animator;
	// Use this for initialization
	void Start () {
        boss_animator = boss.GetComponent<Animator>();
        brother_animator = brother.GetComponent<Animator>();
        turtle_animator = turtle.GetComponent<Animator>();
        biantai_animator = biantai.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void LoadGame() {
        SceneManager.LoadScene("next");
    }
    public void ExitGame() {
        Application.Quit();
    }
    public void BossClick() {
        boss_animator.SetBool("isclick", true);
        Invoke("DestoryBoss", 0.1f);

    }
    public void BrotherClick() {
        brother_animator.SetBool("isclick", true);
        Invoke("DestoryBrother", 0.1f);
    }
    public void TurtleClick() {
        turtle_animator.SetBool("isclick", true);
        Invoke("DestoryTurtle", 0.1f);
    }
    public void BiantaiClick()
    {
        biantai_animator.SetBool("isclick", true);
        Invoke("DestoryBiantai", 0.1f);
    }
    void DestoryBoss() {
        boss_animator.SetBool("isclick", false);
    }
    void DestoryBrother()
    {
        brother_animator.SetBool("isclick", false);
    }
    void DestoryTurtle()
    {
        turtle_animator.SetBool("isclick", false);
    }
    void DestoryBiantai() {
        biantai_animator.SetBool("isclick", false);
    }
}
