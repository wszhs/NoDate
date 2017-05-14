using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {
    int count = 0;
    private int time = 0;
    public static bool isend = false;
	// Use this for initialization
	void Start () {
        //GetComponent<Rigidbody>().AddForce(new Vector3(100.0f, 0.0f));
        GetComponent<Rigidbody>().velocity = new Vector3(2.0f, 0.0f);
    }

    private void Update()
    {
        
        if (transform.position.x > 10.0f|| transform.position.y <-10.0f) {
            isend = true;
        }
    }
    // Update is called once per frame
    void FixedUpdate () {
         
        GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, -15.0f));
        if (isend == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                count = 0;
                GetComponent<Rigidbody>().velocity = new Vector3(2.0f, 8.0f);

            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "box" && isend ==false) {
            //GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f);
     
            isend = true;
        }
    }
}
