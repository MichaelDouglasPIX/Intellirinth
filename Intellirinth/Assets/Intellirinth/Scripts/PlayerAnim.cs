using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    float z;
    bool vJump;
    Animator anim;
    bool paused;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (paused == false) {
            if (vJump) {
                z = Input.GetAxis("Vertical");

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    z += 1f;
                    if (Input.GetKey(KeyCode.Space))
                        anim.SetBool("Jump", true);
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    z = 1f;
                }

                anim.SetFloat("Walk", z);

            }
            else
            {
                z = 0;
            }

            if (vJump)
            {
                if (Input.GetKey(KeyCode.Space))
                    anim.SetBool("Jump", true);
                else
                {
                    anim.SetBool("Jump", false);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == false)
            {                
                paused = true;
            }
            else
            {                
                paused = false;
            }

        }


    }

    private void OnCollisionStay(Collision collision)
    {
        vJump = collision.contacts[0].point.y < transform.position.y;
        vJump = true;

    }

    private void OnCollisionExit(Collision collision)
    {
        
       // vJump = false;
    }
}
