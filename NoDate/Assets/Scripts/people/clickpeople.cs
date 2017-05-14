using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickpeople : MonoBehaviour {
    Vector3 lastPos = Vector3.zero;
    private Animator animator;
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 currentPos = Input.mousePosition;
        if (Vector3.Distance(currentPos, lastPos) > 15f)
        {
            lastPos = currentPos;
            clickevent(Input.mousePosition);
        }
    }


    void clickevent(Vector3 v)
    {
        Ray ray = Camera.main.ScreenPointToRay(v);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "people")
            {
                animator = hit.collider.gameObject.GetComponent<Animator>();
                BossClick();
            }
        }
    }

    public void BossClick()
    {
        if (animator != null)
        {
            animator.SetBool("isclick", true);
        }
        Invoke("DestoryBoss", 0.1f);

    }

    void DestoryBoss()
    {
        if (animator != null)
        {
            animator.SetBool("isclick", false);
        }
    }

    

}
