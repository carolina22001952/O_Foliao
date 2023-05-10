using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class BenchLocal : MonoBehaviour, ILocal
{
    [SerializeField]
    private PrimaryEventList primaryEventList;

    [SerializeField]
    private EventListTools eventListTools;

    [SerializeField]
    private BenchUI benchUI;

    [SerializeField]
    private UIEvents uiEvents;

    [SerializeField]
    private DialogueAction dialogueAction;


    private List<Events> benchEvents;
    [SerializeField]
    private List<Events> alcoholEvents;
    [SerializeField]
    private Game game;
    

    public void localInteraction(Player player, Clock clock)
    {
        List<Events> events = new List<Events>();
        Events chosenEvent;
        //Get the events
        benchEvents = primaryEventList.GetBenchEvents();
        //Intersect the events

        if (player.GetAlcohol() > 80)
        {
            events = eventListTools.UnionEvents(benchEvents, alcoholEvents);
        }
        //Get only 1 type of events and choose a random one

        events = primaryEventList.GetAllEventsOfOneType(events, primaryEventList.CheckForEventType(events));
        chosenEvent = eventListTools.ChooseARandomEvent(events);

        primaryEventList.ChangeCurrentEvent(chosenEvent);

        uiEvents.OpenCanvas();
        uiEvents.ResetCanvas();
        dialogueAction.StartDialogue();
    }

    public void ChoiceBench(int choice)
    {
        switch (choice)
        {
            case 0:
                benchUI.OpenBenchUI();
                break;
            case 1:
                benchUI.CloseBenchUI();
                break;
        }
    }

    public void localChoice(bool more)
    {
        Debug.Log("LocalChoice");
        if (more)
        {
            dialogueAction.StartDialogue();
        }
        else
        {
            uiEvents.CloseCanvas();
            Restart();
        }
    }

    public void localDialogue(bool more)
    {
        Debug.Log("LocalDialogue");
        if (more)
        {
            dialogueAction.StartChoices();
        }
        else
        {
            Restart();
        }
    }

    public void Restart()
    {
        game.StartMovement();
    }
}