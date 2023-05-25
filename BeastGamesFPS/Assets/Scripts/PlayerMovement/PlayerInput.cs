using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public Vector2 inputAxis
    {
        get
        {
            Vector2 i = Vector2.zero;
            i.x = Input.GetAxis("Horizontal");
            i.y = Input.GetAxis("Vertical");
            //i *= (i.x != 0.0f && i.y != 0.0f) ? .7071f : 1.0f;                                                                                                                         //FUCK IT WE'RE DOING STH, I DUNNO, TBH...
            return i;
        }
    }

    public Vector2 inputAxisRaw
    {
        get
        {
            Vector2 i = Vector2.zero;
            i.x = Input.GetAxisRaw("Horizontal");
            i.y = Input.GetAxisRaw("Vertical");
            //i *= (i.x != 0.0f && i.y != 0.0f) ? .7071f : 1.0f;
            return i;
        }
    }

    public bool keyCtrlLeft
    {
        get { return Input.GetKey(KeyCode.LeftControl); }
    }

    public bool keyShiftLeft 
    {
        get { return Input.GetKeyDown(KeyCode.LeftShift); }
    }

    public bool keyE
    {
        get { return Input.GetKeyDown(KeyCode.E); }
    }

    public bool keySpace
    {
        get { return Input.GetKeyDown(KeyCode.Space); }
    }
}
