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
    
    // TODO: variable destination
    bool canMove = false;
    bool destinationReached;
    float velocity = 300f;
    direction dir = direction.straight;

    public void allowMovement()//TODO: add parameter destination
    {
        canMove = true;
        destinationReached = false;
    }

    public bool DestinationReached()
    {
        return destinationReached;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Move())
        {
            Vector3 pos = transform.position;

            //TODO: zamienić to na wykrywanie narożnych pól - dodanie ładnej zmiany kierunku
            if (pos.z >= 16 && dir == direction.straight)
            {
                dir = direction.right;

                Vector3 v = new Vector3();
                v.Set(0, 0, 0);
                rb.velocity = v;
            }
            else if (pos.x >= 20 && dir == direction.right)
            {
                dir = direction.backwards;

                Vector3 v = new Vector3();
                v.Set(0, 0, 0);
                rb.velocity = v;
            }
            else if (pos.z <= -5 && dir == direction.backwards)
            {
                dir = direction.left;

                Vector3 v = new Vector3();
                v.Set(0, 0, 0);
                rb.velocity = v;
            }
            else if (pos.x <= -3 && dir == direction.left)
            {
                dir = direction.straight;

                Vector3 v = new Vector3();
                v.Set(0, 0, 0);
                rb.velocity = v;
            }


            if (dir == direction.right)
            {
                Vector3 v = new Vector3();
                v.Set(velocity * Time.deltaTime, 0, 0);
                rb.velocity = v;
            }
            else if (dir == direction.straight)
            {
                Vector3 v = new Vector3();
                v.Set(0, 0, velocity * Time.deltaTime);
                rb.velocity = v;
            }
            else if (dir == direction.left)
            {
                Vector3 v = new Vector3();
                v.Set( - velocity * Time.deltaTime, 0, 0);
                rb.velocity = v;
            }
            else if (dir == direction.backwards)
            {
                Vector3 v = new Vector3();
                v.Set(0, 0, - velocity * Time.deltaTime);
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

    bool Move()
    {
        if(destinationReached)
        {
            canMove = false;
            return false;
        }
        else if (canMove)
        {
            return true;
        }
        return false;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag=="xd") // TODO: należy zmienić na coś innego niż tagi - ale kolizje wykrywa
        {
            destinationReached = true;
            // TODO: dorobić ładne ustawienie na polu
        }
    }
}
