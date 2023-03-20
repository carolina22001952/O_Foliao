using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Movement move;
    /*  [SerializeField] private EventsUi eventsUi;*/
    [SerializeField] private EventList eventsList;
    [SerializeField] private Node node;
    [SerializeField] private Clock clock;
    [SerializeField] private SceneChanger sceneChanger;



    private Events randomEvent;
    private void Update()
    {
        if (move.IsMoving() == true)
        {
            GetComponent<Movement>().enabled = true;

        }
        if (move.IsMoving() == false)
        {
            GetComponent<Movement>().enabled = false;

            if (player.Position().GetComponent<ILocal>() is ILocal)
            {
                player.Position().GetComponent<ILocal>().localInteraction(player, clock);
            }

            if (clock.GetDay() >= 3)
            {
                sceneChanger.Win();
            }

            StartMovement();
        }
    }

    public void StartMovement()
    {
        move.TakeMovementInput();
    }
}
