using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool startTurn = false;
    public PawnMovement pawn;
    public Dice dice;
    //TODO: obecna pozycja

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (startTurn)
        {
            dice.EnableRolling();
            startTurn = false;
        }

        if(dice.Rolled())
        {
            dice.GetRolledValue();
            pawn.allowMovement();
        }

        if( pawn.DestinationReached() == true)
        {
            //TODO: reszta tury
        }
    }
}
