using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private Clock clock;
    [SerializeField]
    private DialogueAction dialogueAction;
    [SerializeField]
    private Events eventToCheat;
    [SerializeField]
    private PrimaryEventList primaryEventList;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.U)) 
        {
            player.ChangeStats(player, 10);
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            player.ChangeStats(player,0, 10);
        }
        if (Input.GetKeyUp(KeyCode.O))
        {
            player.ChangeStats(player, 0,0,0, 10);
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            player.ChangeStats(player, 0, 0, 10, 0);
        }

        if (Input.GetKeyUp(KeyCode.H))
        {
            player.ChangeStats(player, -10);
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            player.ChangeStats(player, 0, -10);
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            player.ChangeStats(player, 0, 0, 0, -10);
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            player.ChangeStats(player, 0, 0, -10, 0);
        }



        if(Input.GetKeyUp(KeyCode.M))
        {
            clock.UpdateTime(60);
        }
    }

}
