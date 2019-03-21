using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    List<Player> players;
    int numberOfTurns;
    int numberOfPlayers;
    int currentPlayer;

    public void SetNumberOfPlayers(int number)
    {
        numberOfPlayers = number;

        if ( number < 2)
            number = 2;
        if (number > 4)
            number = 4;

        if (number == 2)
        {
            players.Add((Player)GameObject.Find("Teapot").GetComponent(typeof(Player)));
            players.Add((Player)GameObject.Find("Cat").GetComponent(typeof(Player)));

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
        SetNumberOfPlayers(2);
        currentPlayer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!players[currentPlayer].IsMoving())
        {
            players[currentPlayer].AllowRolling();
        }

        if(players[currentPlayer].PawnMoved())
        {
            //TODO: reszta tury
            currentPlayer++;
            if(currentPlayer == numberOfPlayers)
            {
                currentPlayer = 0;
                numberOfTurns++;
            }
        }
    }
}
