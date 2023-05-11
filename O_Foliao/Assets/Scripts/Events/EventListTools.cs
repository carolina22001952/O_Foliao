using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class EventListTools : MonoBehaviour
{
    /// <summary>
    /// Intersects an undefined amount of EventLists to find shared events
    /// </summary>
    /// <param name="eventListsToIntersect"></param>
    /// <returns>An empty list or the list of shared events</returns>
    public List<Events> IntersectEventLists(params List<Events>[] eventListsToIntersect)
    {

        IEnumerable<Events> eventsAux = null; ;
        foreach (List<Events> eventlist in eventListsToIntersect)
        {
            if(eventsAux == null)
            {
                eventsAux = eventlist.AsQueryable();
            }
            else
            {
                eventsAux = eventsAux.AsQueryable().Intersect(eventlist);
                eventsAux.Intersect(eventlist);
            }
        }
        return eventsAux == null ? new List<Events>() : eventsAux.ToList();

    }

    /// <summary>
    /// Union between an undefined amount of EventList
    /// </summary>
    /// <param name="eventListsToUnite"></param>
    /// <returns>Combined List of Events</returns>
    public List<Events> UnionEvents(params List<Events>[] eventListsToUnite)
    {
        List<Events> unionList = new List<Events>();
        foreach (List<Events> list in eventListsToUnite)
        {
            if(list != null)
            {
                unionList = unionList.Union(list).ToList();
            }
        }

        return unionList;
            
        
    }
    /// <summary>
    /// Chooses a random event from a list
    /// </summary>
    /// <param name="eventList"></param>
    /// <returns>A single Event</returns>
    public Events ChooseARandomEvent(List<Events> eventList)
    {
        Random random = new Random();
        return eventList[random.Next(0, eventList.Count)];

    }
    /// <summary>
    /// Removes a specific event from the event lists given
    /// </summary>
    /// <param name="eventToRemove"></param>
    /// <param name="eventListToRemoveFrom"></param>
    public void RemoveEvent(Events eventToRemove, params List<Events>[] eventListsToRemoveFrom)
    {
        foreach (List<Events> list in eventListsToRemoveFrom)
        {
            list.Remove(eventToRemove);
        }
    }
     
    public void InsertAnEvent(Events eventToInsert, params List<Events>[] eventListsToInsert)
    {
        
        foreach (List<Events> list in eventListsToInsert)
        {
            list.Insert(0,eventToInsert);
        }
    }


}
