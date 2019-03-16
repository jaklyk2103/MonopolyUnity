using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    Rigidbody rigidBody;
    bool hasLanded;
    bool wasThrown;
    bool valueRead;
    Vector3 initialPosition;
    int rollValue;
    public DiceSide [] diceSides ;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody=GetComponent<Rigidbody>();
        initialPosition = transform.position;
        rigidBody.useGravity = false;
        hasLanded = false;
        wasThrown = false;
        
    }
     void OnMouseDown()
    {
        if (!wasThrown && !hasLanded) Roll();
        else Reset();
    }

    void Roll()
    {
        
            wasThrown = true;
            rigidBody.useGravity = true;
            rigidBody.AddTorque(300, 100, 200);
        
        

    }
    // Update is called once per frame
    void Update()
    {
        if (wasThrown && !hasLanded && rigidBody.IsSleeping())
        {
            hasLanded = true;
            rigidBody.useGravity = false;
            rigidBody.isKinematic = true;
        }
        if (wasThrown && hasLanded && !valueRead)
        {
            CheckValue();
        }
        if (wasThrown && hasLanded && valueRead)
        {
            Reset();
        }
      
        
    }
    void Reset()
    {
        transform.position = initialPosition;
        wasThrown = false;
        hasLanded = false;
        valueRead = false;
        rigidBody.useGravity = false;
        rigidBody.isKinematic = false;
    }
    void CheckValue()
    {
        rollValue = 0;
        foreach (DiceSide side in diceSides)
        {
            if (side.IsGrounded())
            {
                rollValue = side.sideValue;
                Debug.Log("result of the roll = " + rollValue);
                valueRead = true;
            }
        }
    }


}
