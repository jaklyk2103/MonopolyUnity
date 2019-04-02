using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    CameraMovement camera;
    List<Player> players;
    public List<Property> properties;
    int numberOfTurns;
    int numberOfPlayers;
    int currentPlayerIndex;
    bool start;
    float timeLeft;

    public void SetNumberOfPlayers(int number)
    {
        numberOfPlayers = number;

        if ( number < 2)
            number = 2;
        if (number > 4)
            number = 4;

        if (number == 2)
        {
            players.Add((Player)GameObject.Find("Cat").GetComponent(typeof(Player)));
            players.Add((Player)GameObject.Find("Teapot").GetComponent(typeof(Player)));

            Player p = (Player)GameObject.Find("Dog").GetComponent(typeof(Player));
            p.Disable();
            p = (Player)GameObject.Find("Hat").GetComponent(typeof(Player));
            p.Disable();
        }

        if (number == 3)
        {
            players.Add((Player)GameObject.Find("Cat").GetComponent(typeof(Player)));
            players.Add((Player)GameObject.Find("Teapot").GetComponent(typeof(Player)));
            players.Add((Player)GameObject.Find("Dog").GetComponent(typeof(Player)));

            Player p = (Player)GameObject.Find("Hat").GetComponent(typeof(Player));
            p.Disable();
        }

        if(number == 4)
        {
            players.Add((Player)GameObject.Find("Cat").GetComponent(typeof(Player)));
            players.Add((Player)GameObject.Find("Teapot").GetComponent(typeof(Player)));
            players.Add((Player)GameObject.Find("Dog").GetComponent(typeof(Player)));
            players.Add((Player)GameObject.Find("Hat").GetComponent(typeof(Player)));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        numberOfTurns = 1;
        players = new List<Player>();
        camera = (CameraMovement)GameObject.Find("Main Camera").GetComponent(typeof(CameraMovement));
        currentPlayerIndex = 0;
        start = false;
        timeLeft = 8.0f;
        SetNumberOfPlayers(2);
    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
        {
            //camera.SetCircumnavigation();
            //timeLeft -= Time.deltaTime;
            //if (timeLeft < 0)
                start = true;
        }
        else
        {
            if (!players[currentPlayerIndex].IsMoving())
            {
                players[currentPlayerIndex].AllowRolling();
                camera.SetDiceCamera();
                timeLeft = 1.0f;
            }

            if (players[currentPlayerIndex].DiceRolled())
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0)
                {
                    players[currentPlayerIndex].AllowMovement();
                    camera.SetPawnFollowing(players[currentPlayerIndex].transform.position);
                }
                else
                    camera.SetPawnCamera(players[currentPlayerIndex].transform.position);
            }

            if (players[currentPlayerIndex].PawnMoved())
            {
                /*int currentPlayerPosition = players[currentPlayer].GetCurrentPosition();
                int currentPlayerId = players[currentPlayer].GetId();
                Property currentPlayerStandingProperty = properties[currentPlayerPosition];

                if (currentPlayerStandingProperty.HasOwner())
                {
                    if (currentPlayerStandingProperty.IsOwningBy(currentPlayerId))
                    {
                        HandleStandingOnOwnPosition();
                    }
                    else
                    {
                        HandleRentPay(currentPlayerStandingProperty, currentPlayerId);
                    }
                }
                else
                {
                  HandleAbleToBuyProperty(currentPlayerStandingProperty, currentPlayerId);
                }*/

                currentPlayerIndex++;
                if (currentPlayerIndex == numberOfPlayers)
                {
                    Debug.Log(currentPlayerIndex);

                    currentPlayerIndex = 0;
                    numberOfTurns++;
                }
            }
        }
    }
    void HandleRentPay(Property property, int payingPlayerId)
    {
        //TODO
    }
    void HandleStandingOnOwnPosition()
    {
        //JUST SHOW POPUP INFO?
    }
    void HandleAbleToBuyProperty(Property property, int playerId)
    {
        //TODO: decision making menu + calls to game logic based on player decision        
    }
}
