using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetInteger("turn", 2);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

        }
        if (!Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetInteger("turn", 1);
            anim.SetInteger("turn", 0);
        }
    }
        
}
