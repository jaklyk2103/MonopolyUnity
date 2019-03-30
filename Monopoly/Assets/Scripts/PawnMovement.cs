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

public enum Track
{
    a,
    b,
    c,
    d
}

//TODO: zrobić ruch na obiektach pól, nie na współrzędnych
public class PawnMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Track track;
    int destinationFieldId;
    bool canMove;
    bool destinationReached;
    bool moveToCenter;
    bool rotate;
    Vector3 fieldPosition;
    float targetRotation;
    float velocity = 300f;
    direction dir = direction.straight;
    float trackBonus;
    bool directionChanged;

    public void AllowMovement(int id)
    {
        destinationFieldId = id;
        canMove = true;
        destinationReached = false;
        moveToCenter = false;
    }

    public bool DestinationReached()
    {
        return destinationReached;
    }

    public void SetDestinationReached(bool b)
    {
        destinationReached = b;
    }

    // Start is called before the first frame update
    void Start()
    {
        destinationReached = false;
        canMove = false;
        moveToCenter = false;
        rotate = false;
        targetRotation = 0f;
        trackBonus = 0f;
        directionChanged = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rotate)
        {
            switch (track)
            {
                case Track.a:
                    trackBonus = -1.2f;
                    break;
                case Track.b:
                    trackBonus = -0.4f;
                    break;
                case Track.c:
                    trackBonus = 0.4f;
                    break;
                case Track.d:
                    trackBonus = 1.2f;
                    break;
            }

            Vector3 dest;
            if (!directionChanged)
            {
                switch (dir)
                {
                    case direction.straight:
                        dest = transform.position;
                        dest.z = fieldPosition.z + trackBonus;
                        if (transform.position.z >= dest.z)
                        {
                            dir = direction.right;
                            directionChanged = true;
                        }
                        break;
                    case direction.backwards:
                        dest = transform.position;
                        dest.z = fieldPosition.z - trackBonus;
                        if (transform.position.z <= dest.z)
                        {
                            dir = direction.left;
                            directionChanged = true;
                        }
                        break;
                    case direction.right:
                        dest = transform.position;
                        dest.x = fieldPosition.x + trackBonus;
                        if (transform.position.x >= dest.x)
                        {
                            dir = direction.backwards;
                            directionChanged = true;
                        }
                        break;
                    case direction.left:
                        dest = transform.position;
                        dest.x = fieldPosition.x - trackBonus;
                        if (transform.position.x <= dest.x)
                        {
                            dir = direction.straight;
                            directionChanged = true;
                        }
                        break;
                }
            }
        }
        if (moveToCenter)
        {
            Vector3 dest;
            switch (dir)
            {
                case direction.straight:
                    dest = transform.position;
                    dest.z = fieldPosition.z + trackBonus;
                    transform.position = Vector3.Lerp(transform.position, dest, Time.deltaTime * 2);
                    break;
                case direction.backwards:
                    dest = transform.position;
                    dest.z = fieldPosition.z - trackBonus;
                    transform.position = Vector3.Lerp(transform.position, dest, Time.deltaTime * 2);
                    break;
                case direction.right:
                    dest = transform.position;
                    dest.x = fieldPosition.x + trackBonus;
                    transform.position = Vector3.Lerp(transform.position, dest, Time.deltaTime * 2);
                    break;
                case direction.left:
                    dest = transform.position;
                    dest.x = fieldPosition.x - trackBonus;
                    transform.position = Vector3.Lerp(transform.position, dest, Time.deltaTime * 2);
                    break;
            }

            trackBonus = 0f;
        }

        if (Move())
        {

            Quaternion target = Quaternion.Euler(0, targetRotation, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5);

            Vector3 pos = transform.position;
            
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
                    v.Set(-velocity * Time.deltaTime, 0, 0);
                    rb.velocity = v;
                }
                else if (dir == direction.backwards)
                {
                    Vector3 v = new Vector3();
                    v.Set(0, 0, -velocity * Time.deltaTime);
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
        if (canMove && (col.GetComponentInParent<Property>().Id == 1 || col.GetComponentInParent<Property>().Id == 10 || col.GetComponentInParent<Property>().Id == 13 || col.GetComponentInParent<Property>().Id == 15)) //należy zmienić na poprawne później
        {
            rotate = false;
            directionChanged = false;
        }

        if (canMove && (col.GetComponentInParent<Property>().Id == 100 || col.GetComponentInParent<Property>().Id == 9 || col.GetComponentInParent<Property>().Id == 12 || col.GetComponentInParent<Property>().Id == 14)) //należy zmienić na poprawne później
        {
            rotate = true;
            targetRotation += 90f;
            fieldPosition = col.GetComponentInParent<Property>().transform.position;
        }

        if ( canMove && col.GetComponentInParent<Property>().Id == destinationFieldId )
        {
            fieldPosition = col.GetComponentInParent<Property>().transform.position;
            destinationReached = true;
            moveToCenter = true;
        }
    }
}
