using System.Collections;
using System.Collections.Generic;
//using UnityEditor.TextCore.Text;
using UnityEngine;


public class Game : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Movement move;
    [SerializeField] private Node node;
    [SerializeField] private Clock clock;
    [SerializeField] private SceneChanger sceneChanger;



    private void Start()
    {
        move.TakeMovementInput();
    }

    private Events randomEvent;
    private void Update()
    {
        if (clock.GetDay() >= 3)
        {
            sceneChanger.Win();
        }   

        if(player.GetEnergy() <= 0)
        {
            sceneChanger.DeathEnergy();
        }
        if(player.GetAlcohol() >= 100)
        {
            sceneChanger.DeathAlcool();
        }
    }

    public void CheckForInteraction()
    {
        if (player.Position().GetComponent<ILocal>() is ILocal)
        {
            player.Position().GetComponent<ILocal>().localInteraction(player, clock);
        }

    }
    public void StartMovement()
    {
        move.TakeMovementInput();
    }


}
