using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatataLocal : MonoBehaviour, ILocal
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

    private List<Events> batataEvents;
    private List<Events> dayEvents;
    private List<Events> timeOfDayEvents;
    private List<Events> resourceEvents;
    public void localInteraction(Player player, Clock clock)
    {
        List<Events> events = new List<Events>();
        Events chosenEvent;
        //Get the events
        batataEvents = primaryEventList.GetBatataZoneEvents();
        dayEvents = primaryEventList.GetDayDeck(clock);
        resourceEvents = primaryEventList.GetResourceEvents(player);
        timeOfDayEvents = primaryEventList.GetTimeOfDayDeck(clock);
        //Intersect the events
        events = eventListTools.IntersectEventLists(batataEvents, dayEvents, timeOfDayEvents);
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
        if (more)
        {
            dialogueAction.StartDialogue();
        }else
        {
            uiEvents.CloseCanvas();
            Restart();
        }
    }
    public void localDialogue(bool more)
    {
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
