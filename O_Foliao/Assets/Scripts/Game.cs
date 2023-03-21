using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
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

    private bool interacting;

    private void Start()
    {
        move.TakeMovementInput();
        interacting = false;
    }

    private Events randomEvent;
    private void Update()
    {
        if (clock.GetDay() >= 3)
        {
            sceneChanger.Win();
        }   
    }

    public void CheckForInteraction()
    {
        if (player.Position().GetComponent<ILocal>() is ILocal)
        {
            Debug.Log("sup");
            player.Position().GetComponent<ILocal>().localInteraction(player, clock);
        }

    }
    public void StartMovement()
    {
        move.TakeMovementInput();
    }


}
