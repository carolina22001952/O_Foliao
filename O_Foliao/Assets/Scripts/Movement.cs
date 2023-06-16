using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Movement: MonoBehaviour
{
    public Game game;
    public Player player;
    private bool timetomove = true;
    private bool stillmoving = false;
    private bool moving = false;
    public Clock clock;


    List<Transform> waypoints = new List<Transform>();

    public void Move(Player player,GameObject nextpoint)
    {
        
        player.ChangePosition(nextpoint);
        
    }

    public bool IsMoving()
    {
        return timetomove;
    }

    public void TakeMovementInput()
    {
        timetomove = true;
    }

    public void StopTakingMovementInput()
    {
        timetomove = false;
    }
    public void Update()
    {
        if (timetomove)
        {
            var nodes = player.Position().GetComponent<Node>().GetOptions();
            foreach (var node in nodes)
            {
                if (node.target && node.target.gameObject.transform.parent.gameObject.activeSelf)
                {
                    node.target.HighLight();
                }
            }
            if (Input.GetMouseButtonUp(0) && stillmoving == false)
            {
                // Create a ray from the current mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))                {

                    if (hit.transform.tag == "Point")
                    {
                        foreach (var node in nodes)
                        {
                            if (node.target)
                            {
                                node.target.BacktoNormal();
                            }
                        }

                        Node hitNode = hit.transform.GetComponentInChildren<Node>();
                        foreach (var node in nodes)
                        {
                            if (node.target == hitNode)
                            {
                                waypoints.Clear();
                                if (node.waypoints != null)
                                {
                                    foreach (var w in node.waypoints)
                                    {
                                        waypoints.Add(w);
                                    }
                                }
                                waypoints.Add(node.target.transform);
                                Move(player, waypoints[waypoints.Count - 1].gameObject);
                                moving = true;

                                break;
                            }
                        }

                    }
                }
            }


            if ((moving) && (waypoints.Count  > 0))
            {
                player.gameObject.transform.position = Vector3.MoveTowards(player.gameObject.transform.position,
                                                                           waypoints[0].transform.position, 300 * Time.deltaTime);
                stillmoving = true;

                if (player.transform.position == waypoints[0].position)
                {
                    waypoints.RemoveAt(0);

                    if (waypoints.Count == 0)
                    {
                        clock.UpdateTime(4);
                        player.ChangeStats(player, 0, 0, 0, -10);
                        moving = false;
                        StopTakingMovementInput();
                        game.CheckForInteraction();
                        stillmoving = false;
                        
                    }
                }

            }            


        }
    }

   


}
