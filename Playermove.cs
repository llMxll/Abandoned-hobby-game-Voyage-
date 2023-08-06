using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    public static bool moveplayertospawn = false;
    public static bool playerismoving = false;

    Direction CurrentDir;
    Vector2 input;
    bool ismoving = false;
    Vector3 startpos;
    public Vector3 endpos;
    float t;

    public Material northmat;
    public Material eastmat;
    public Material southmat;
    public Material westmat;

    public float radius = 1;
    public static Collider[] objectsaroundplayer;
    public Collider[] objectsaroundplayercheck;
    bool canmove = true;

    public float walkspeed = 3f;

    Vector3 aboveplayer;

    public Inventory inventory;


    void LateUpdate()
    {

    }


    void Update()
    {
        //check for objects around player
        objectsaroundplayer = Physics.OverlapSphere((transform.position), radius);
        objectsaroundplayercheck = objectsaroundplayer;

        //move if new map made
        if (moveplayertospawn == true)
        {
            StartCoroutine(Move(transform));
        }


        // Change character facing

        if (!ismoving)
        {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
                input.y = 0;
            else
                input.x = 0;
            if (input != Vector2.zero)
            {

                if (input.x < 0)
                {
                    CurrentDir = Direction.West;
                }
                if (input.x > 0)
                {
                    CurrentDir = Direction.East;
                }
                if (input.y < 0)
                {
                    CurrentDir = Direction.South;
                }
                if (input.y > 0)
                {
                    CurrentDir = Direction.North;
                }

                switch (CurrentDir)
                {
                    case Direction.North:
                        gameObject.GetComponent<MeshRenderer>().material = northmat;
                        break;
                    case Direction.East:
                        gameObject.GetComponent<MeshRenderer>().material = eastmat;
                        break;
                    case Direction.South:
                        gameObject.GetComponent<MeshRenderer>().material = southmat;
                        break;
                    case Direction.West:
                        gameObject.GetComponent<MeshRenderer>().material = westmat;
                        break;
                }
                StartCoroutine(Move(transform));
            }
        }
    }
    public IEnumerator Move(Transform entity)
    {
        //move player to spawn
        if (moveplayertospawn == true)
        {
            entity.position = new Vector3(Mapgen.playerspawnpoint.x, Mapgen.playerspawnpoint.y, Mapgen.playerspawnpoint.z);
            moveplayertospawn = false;
        }
        else
        {
// set movement variables
            ismoving = true;
            canmove = true;
            startpos = entity.position;
            t = 0;

            endpos = new Vector3(Mathf.Round(startpos.x + System.Math.Sign(input.x)), Mathf.Round(startpos.y + System.Math.Sign(input.y)), Mathf.Round(startpos.z));

            //Findwall to block walking

            //objectsaroundplayer = Physics.OverlapSphere(entity.position, radius);
            //objectsaroundplayercheck = objectsaroundplayer;
            foreach (Collider col in objectsaroundplayer)
            {
                if (col.transform.position == endpos
                    && col.isTrigger == false)
                {
                    canmove = false;
                }
            }

            // Walk if able

            if (canmove == true)
            {
                playerismoving = true;
                while (t < 1f)
                {
                    t += Time.deltaTime * walkspeed;
                    entity.transform.position = Vector3.Lerp(startpos, endpos, t);
                    yield return null;
                }
                playerismoving = false;
            }
            else
            {
                yield return null;
            }
            ismoving = false;
            yield return 0;
        }    
    }
}

enum Direction
    {
        North,
        East,
        South,
        West,
}
