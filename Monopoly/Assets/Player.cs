using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PawnMovement pawn;
    public Dice dice;
    bool moving;
    bool diceRolled;
    int cash;
    //TODO: obecna pozycja
    //TODO: lista posiadanych pól

    public void AllowMovement()
    {
        pawn.allowMovement();
    }

    public bool IsMoving()
    {
        return moving;
    }

    public void AllowRolling()
    {
        dice.EnableRolling();
        moving = true;
    }

    public bool DiceRolled()
    {
        return diceRolled;
    }

    public bool PawnMoved()
    {
        if (pawn.DestinationReached())
        {
            moving = false;
            diceRolled = false;
        }
        return pawn.DestinationReached();
    }

    public void Disable()
    {
        transform.position = new Vector3(0.0f, -10.0f, 0.0f);
        GetComponent<Renderer>().enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        diceRolled = false;
        cash = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        if(dice.Rolled() && moving)
        {
            dice.GetRolledValue();
            diceRolled= true;
        }
    }
}
