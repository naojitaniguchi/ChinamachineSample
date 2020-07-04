using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollPlayer : MonoBehaviour
{
    public float speed = 10.0f;
    public float jump = 100.0f;
    bool grounded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, jump, 0.0f));
            }
            if (Mathf.Abs(gameObject.GetComponent<Rigidbody>().velocity.y) < 0.001f)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    gameObject.GetComponent<Rigidbody>().velocity = new Vector3(speed, 0.0f, 0.0f);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-1.0f * speed, 0.0f, 0.0f);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
