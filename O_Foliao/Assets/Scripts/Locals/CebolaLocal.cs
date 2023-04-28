using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class CebolaLocal : MonoBehaviour, ILocal
{
    [SerializeField]
    private PrimaryEventList primaryEventList;

    [SerializeField]
    private EventListTools eventListTools;

    [SerializeField]
    private DialogueAction dialogueAction;

    [SerializeField]
    private UIEvents uiEvents;

    [SerializeField]
    private Game game;



    private bool cebola = false;

    private List<Events> cebolaEvents;
    private List<Events> dayEvents;
    private List<Events> resourceEvents;

    private Events chosenEvent;
    public void localInteraction(Player player, Clock clock)
    {
        List<Events> events = new List<Events>();
        Events chosenEvent;
        //Get the events
        cebolaEvents = primaryEventList.GetCebolaZoneEvents();
        dayEvents = primaryEventList.GetDayDeck(clock);
        resourceEvents = primaryEventList.GetResourceEvents(player);
        //Intersect the events
        events = eventListTools.IntersectEventLists(cebolaEvents, dayEvents);
        events = eventListTools.UnionEvents(events, resourceEvents);
        //Get only 1 type of events and choose a random one

        events = primaryEventList.GetAllEventsOfOneType(events, primaryEventList.CheckForEventType(events));
        chosenEvent = eventListTools.ChooseARandomEvent(events);
        primaryEventList.ChangeCurrentEvent(chosenEvent);

        uiEvents.OpenCanvas();
        uiEvents.ResetCanvas();
        dialogueAction.StartDialogue();




    }

    public void localChoice(bool more)
    {
        Debug.Log("LocalChoice");
        if (more)
        {
            dialogueAction.StartDialogue();
        }else
        {
            uiEvents.CloseCanvas();
            game.StartMovement();
        }
    }

    public void localDialogue(bool more)
    {
        Debug.Log("LocalDialogue");
        if (more)
        {
            dialogueAction.StartChoices();
        }else
        {
            Restart();
        }
    }

    public void Restart()
    {
        game.StartMovement();
    }

}
