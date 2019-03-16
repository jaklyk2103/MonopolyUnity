using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSide : MonoBehaviour
{
    bool grounded;
    public int sideValue;

    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Ground")
        {
            grounded = true;
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Ground")
        {
            grounded = false;
        }
    }
    public bool IsGrounded()
    {
        return grounded;
    }
}
