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
    private UIEventManager uiEventManager;



    private List<Events> batataEvents;
    private List<Events> dayEvents;
    private List<Events> resourceEvents;
    public void localInteraction(Player player, Clock clock)
    {
        List<Events> events = new List<Events>();
        Events chosenEvent;
        //Get the events
        batataEvents = primaryEventList.GetBatataZoneEvents();
        dayEvents = primaryEventList.GetDayDeck(clock);
        resourceEvents = primaryEventList.GetResourceEvents(player);
        //Intersect the events
        events = eventListTools.IntersectEventLists(batataEvents, dayEvents);
        events = eventListTools.UnionEvents(events, resourceEvents);
        //Get only 1 type of events and choose a random one
        //primaryEventList.GetAllEventsOfOneType(events, primaryEventList.CheckForEventType(events));
        chosenEvent = eventListTools.ChooseARandomEvent(events);   
        //Stop the movement of the player
        uiEventManager.StartDialogue(chosenEvent);
    }

}
