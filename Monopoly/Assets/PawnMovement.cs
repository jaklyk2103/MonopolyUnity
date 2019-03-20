using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum direction
{
    straight,
    left,
    right,
    backwards
};

//TODO: zrobić ruch na obiektach pól, nie na współrzędnych
public class PawnMovement : MonoBehaviour
{
    public Rigidbody rb;
    public int diceOutput; //TODO: ma być czytane z kostki
    public bool diceRolled; //TODO: dawane z góry pozwolenie na ruch

    int fieldsMoved = 0;
    float velocity = 300f;
    direction dir = direction.straight;

    // Start is called before the first frame update
    void Start()
    {
        diceOutput = 4;
        diceRolled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (move())
        {
            Vector3 pos = transform.position;

            if (pos.x >= 10 && dir == direction.straight)
            {
                dir = direction.right;

                Vector3 v = new Vector3();
                v.Set(0, 0, 0);
                rb.velocity = v;
            }
            else if (pos.z <= -1 && dir == direction.right)
            {
                dir = direction.backwards;

                Vector3 v = new Vector3();
                v.Set(0, 0, 0);
                rb.velocity = v;
            }
            else if (pos.x <= 0 && dir == direction.backwards)
            {
                dir = direction.left;

                Vector3 v = new Vector3();
                v.Set(0, 0, 0);
                rb.velocity = v;
            }
            else if (pos.z >= 9 && dir == direction.left)
            {
                dir = direction.straight;

                Vector3 v = new Vector3();
                v.Set(0, 0, 0);
                rb.velocity = v;
            }


            if (dir == direction.right)
            {
                Vector3 v = new Vector3();
                v.Set(0, 0, -velocity * Time.deltaTime);
                rb.velocity = v;
            }
            else if (dir == direction.straight)
            {
                Vector3 v = new Vector3();
                v.Set(velocity * Time.deltaTime, 0, 0);
                rb.velocity = v;
            }
            else if (dir == direction.left)
            {
                Vector3 v = new Vector3();
                v.Set(0, 0, velocity * Time.deltaTime);
                rb.velocity = v;
            }
            else if (dir == direction.backwards)
            {
                Vector3 v = new Vector3();
                v.Set(-velocity * Time.deltaTime, 0, 0);
                rb.velocity = v;
            }
        }
        else
        {
            Vector3 v = new Vector3();
            v.Set(0, 0, 0);
            rb.velocity = v;
        }
    }

    bool move()
    {
        if (diceRolled)
        {

            //TODO: liczyć ile pól pionek przebył
            if (fieldsMoved < diceOutput)
                return true;
        }

        fieldsMoved = 0;
        return false;
    }
}
